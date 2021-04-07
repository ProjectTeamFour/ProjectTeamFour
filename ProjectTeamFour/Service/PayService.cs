using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;
using ECPay.Payment.Integration;
using System.Collections;

namespace ProjectTeamFour.Service
{
    public class PayService
    {
        private DbContext _context;
        private BaseRepository _repository;

        

        public System.Web.HttpResponse Response { get; }

        public PayService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }        
        
        
        public PayViewModel QueryByPlanId(CartItemListViewModel cart) //撈資料庫資料 用購物車的planId找到資料庫的planId
        {

            var session = HttpContext.Current.Session;
            var memberSession = ((MemberViewModel)session["Member"]);
            var member = _repository.GetAll<Member>().FirstOrDefault(x => x.MemberId == memberSession.MemberId);

            var viewmodel = new PayViewModel
            {
                MemberName = member.MemberName,
                MemberAddress = member.MemberAddress,
                MemberPhone = member.MemberPhone,
                MemberConEmail = member.MemberRegEmail,
                MemberId = member.MemberId,
                CartItems = new List<CarCarPlanViewModel>() //先給他一個空的集合 讓viewmodel知道我需要這筆資料
            };

            foreach (var item in cart.CartItems) //先撈session
            {                                
                var plan = _repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == item.PlanId); //資料庫id==sessionId 之後要移出foreach          

                var CartItem = new CarCarPlanViewModel
                {                    
                    PlanId = plan.PlanId,
                    Quantity = item.Quantity,
                    PlanPrice = plan.PlanPrice,
                    PlanImgUrl = plan.PlanImgUrl,
                    PlanTitle = plan.PlanTitle,
                    ProjectId = plan.ProjectId,                      
                };
                viewmodel.CartItems.Add(CartItem);                                                                            
            }
            return viewmodel;
        }        

        public int ReturnLoginnerId()
        {
            var session = HttpContext.Current.Session;
            if (session["Member"] == null ||session["Cart"]==null)
            {
                return 0;
            }

            var x = ((MemberViewModel)session["Member"]);
            return ((MemberViewModel)session["Member"]).MemberId;
        }


        public PayViewModel CreateANewMemberData(PayViewModel odVM)
        {

            var o = new PayViewModel
            {
                OrderName = odVM.OrderName,
                OrderAddress = odVM.OrderAddress,
                OrderPhone = odVM.OrderPhone,
                OrderConEmail = odVM.OrderConEmail
            };

            return o;
        }

        //public PayViewModel UpdateOrderMember(PayViewModel odVM) //更改訂單寄送資料
        //{
        //    var result = 
        //}
        public int SaveData(PayViewModel orderMem) //要抓到修改的pay頁面 會員資料
        {

            var session = HttpContext.Current.Session;
            var memberSession = ((MemberViewModel)session["Member"]);
            var cartSession = ((CartItemListViewModel)session["Cart"]);            
            var member = _repository.GetAll<Member>().FirstOrDefault(x => x.MemberId == memberSession.MemberId); //從會員資料庫抓             
            var order = new Order //會員註冊時的資料
            {
                MemberId = member.MemberId,
                OrderName = orderMem.OrderName,
                OrderAddress = orderMem.OrderAddress,
                OrderPhone = orderMem.OrderPhone,
                OrderConEmail = orderMem.OrderConEmail,
                OrderTotalAccount = cartSession.TotalAccount,
                OrderDate = DateTime.Now,
                condition = "未付款",
            };
            _repository.Create(order);
           
           


            List<OrderDetail> od = new List<OrderDetail>();
            foreach (var i in cartSession.CartItems)
            {
                var plan = _repository.GetAll<Plan>().Where((x) => x.PlanId == i.PlanId).Select((X) => X).FirstOrDefault(); //從PLAN資料庫抓
                var o = new OrderDetail()
                {
                    PlanTitle = plan.PlanTitle,
                    PlanId = plan.PlanId,
                    OrderPrice = plan.PlanPrice,
                    OrderQuantity = i.Quantity,
                    OrderDetailDes = cartSession.Comment,
                    ProjectId = plan.ProjectId,
                    OrderPlanImgUrl = plan.PlanImgUrl,
                    PlanShipDate = plan.PlanShipDate
                };
                od.Add(o);
            }

            foreach (var item in od)
            {
                item.OrderId = order.OrderId;
                item.condition = order.condition;
                _repository.Create(item);
            }
            return order.OrderId;
           
        }
      

        //回傳訂單資料給資料庫
        public void CreateOrderToDB(string RtnCode , string MerchantTradeNo ,string orderId) //把購物車的資料&member回傳給資料庫
        {
            
            var orderint = Convert.ToInt32(orderId);
            var rtnCode = Convert.ToInt32(RtnCode);             
            
            using (var transaction = _context.Database.BeginTransaction())
            {

                var result = _repository.GetAll<Order>().Where((x) => x.OrderId == orderint).FirstOrDefault();
                var odData = _repository.GetAll<OrderDetail>().Where((x) => x.OrderId == orderint).Select(X => X).ToList();
                
                //抓出od DB 的資料 匹配給Project& plan DB 以projectId 分群
                

                try
                {
                    result.OrderDate = DateTime.Now;
                    result.condition = "已付款";
                    result.RtnCode = rtnCode;
                    result.TradeNo = MerchantTradeNo;
                    foreach (var item in odData)
                    {
                        item.condition = result.condition;
                        var projectview = _repository.GetAll<Project>().Where((x) => x.ProjectId == item.ProjectId);
                        var planview = _repository.GetAll<Plan>().Where((x) => x.PlanId == item.PlanId);
                        foreach(var pj in projectview)
                        {

                            pj.Fundedpeople = pj.Fundedpeople + 1;
                            pj.FundingAmount = pj.FundingAmount + item.OrderPrice;
                        }
                        foreach(var p in planview)
                        {
                            p.QuantityLimit = p.QuantityLimit - 1;
                            p.PlanFundedPeople = p.PlanFundedPeople + 1;
                        }
                    }                    
                    _repository.Update<Order>(result);
                    transaction.Commit(); //交易確認     

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex);
                }
            }
        }

        public string ConnectECPay(int orderId, MemberViewModel member)
        {
            var session = HttpContext.Current.Session;
            List<string> enErrors = new List<string>();
            string html = string.Empty;
            var cartSession = ((CartItemListViewModel)session["Cart"]);
            PayViewModel readyToPay = QueryByPlanId(cartSession);
            var TotalAmount = (Convert.ToInt32(readyToPay.TotalAccount)).ToString();
            try
            {
                using (AllInOne oPayment = new AllInOne())
                {
                    /* 服務參數 */
                    oPayment.ServiceMethod = HttpMethod.HttpPOST;//介接服務時，呼叫 API 的方法
                    oPayment.ServiceURL = "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5";//要呼叫介接服務的網址
                    oPayment.HashKey = "5294y06JbISpM5x9";//ECPay提供的Hash Key
                    oPayment.HashIV = "v77hoKGq4kWxNNIS";//ECPay提供的Hash IV
                    oPayment.MerchantID = "2000132";//ECPay提供的特店編號

                    /* 基本參數 */
                    oPayment.Send.ReturnURL = "https://mycarplanwebsite.azurewebsites.net/Pay/CheckECPayFeedBack";//付款完成通知回傳的網址
                    oPayment.Send.ClientBackURL = "https://mycarplanwebsite.azurewebsites.net/Home/Index";//瀏覽器端返回的廠商網址
                    oPayment.Send.OrderResultURL = "https://mycarplanwebsite.azurewebsites.net/pay/Result";//瀏覽器端回傳付款結果網址
                    oPayment.Send.MerchantTradeNo = "ECPay" + new Random().Next(0, 99999).ToString();//廠商的交易編號
                    oPayment.Send.MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");//廠商的交易時間
                    oPayment.Send.TotalAmount = Decimal.Parse(TotalAmount);
                    oPayment.Send.TradeDesc = "交易描述";//交易描述
                    oPayment.Send.ChoosePayment = PaymentMethod.ALL;//使用的付款方式
                    oPayment.Send.Remark = "";//備註欄位
                    oPayment.Send.ChooseSubPayment = PaymentMethodItem.None;//使用的付款子項目
                    oPayment.Send.NeedExtraPaidInfo = ExtraPaymentInfo.No;//是否需要額外的付款資訊
                    oPayment.Send.DeviceSource = DeviceType.PC;//來源裝置
                    oPayment.Send.IgnorePayment = ""; //不顯示的付款方式
                    oPayment.Send.PlatformID = "";//特約合作平台商代號
                    oPayment.Send.HoldTradeAMT = HoldTradeType.Yes;
                    oPayment.Send.CustomField1 = orderId.ToString();
                    oPayment.Send.CustomField2 = member.MemberId.ToString();
                    oPayment.Send.CustomField3 = "";
                    oPayment.Send.CustomField4 = "";
                    oPayment.Send.EncryptType = 1;

                    foreach (var order in readyToPay.CartItems)
                    {
                        //訂單的商品資料
                        oPayment.Send.Items.Add(new Item()
                        {

                            Name = order.PlanTitle,//商品名稱
                            Price = order.PlanPrice,//商品單價
                            Currency = "新台幣",//幣別單位
                            Quantity = order.Quantity,//購買數量
                            Unit = "件",
                            URL = $"/ProjectDetail/Index/{order}",//商品的說明網址
                        });
                    }



                    //            /*************************非即時性付款:ATM、CVS 額外功能參數**************/

                    //            #region ATM 額外功能參數

                    //            //oPayment.SendExtend.ExpireDate = 3;//允許繳費的有效天數
                    //            //oPayment.SendExtend.PaymentInfoURL = "";//伺服器端回傳付款相關資訊
                    //            //oPayment.SendExtend.ClientRedirectURL = "";//Client 端回傳付款相關資訊

                    //            #endregion


                    //            #region CVS 額外功能參數

                    //            //oPayment.SendExtend.StoreExpireDate = 3; //超商繳費截止時間 CVS:以分鐘為單位 BARCODE:以天為單位
                    //            //oPayment.SendExtend.Desc_1 = "test1";//交易描述 1
                    //            //oPayment.SendExtend.Desc_2 = "test2";//交易描述 2
                    //            //oPayment.SendExtend.Desc_3 = "test3";//交易描述 3
                    //            //oPayment.SendExtend.Desc_4 = "";//交易描述 4
                    //            //oPayment.SendExtend.PaymentInfoURL = "";//伺服器端回傳付款相關資訊
                    //            //oPayment.SendExtend.ClientRedirectURL = "";///Client 端回傳付款相關資訊

                    //            #endregion

                    //            /***************************信用卡額外功能參數***************************/

                    //            #region Credit 功能參數

                    //            //oPayment.SendExtend.BindingCard = BindingCardType.No; //記憶卡號
                    //            //oPayment.SendExtend.MerchantMemberID = ""; //記憶卡號識別碼
                    //            //oPayment.SendExtend.Language = "ENG"; //語系設定

                    //            #endregion Credit 功能參數

                    //            #region 一次付清

                    //            //oPayment.SendExtend.Redeem = false;   //是否使用紅利折抵
                    //            //oPayment.SendExtend.UnionPay = true; //是否為銀聯卡交易

                    //            #endregion

                    //            #region 分期付款

                    //            //oPayment.SendExtend.CreditInstallment = 3;//刷卡分期期數

                    //            #endregion 分期付款

                    //            #region 定期定額

                    //            //oPayment.SendExtend.PeriodAmount = 1000;//每次授權金額
                    //            //oPayment.SendExtend.PeriodType = PeriodType.Day;//週期種類
                    //            //oPayment.SendExtend.Frequency = 1;//執行頻率
                    //            //oPayment.SendExtend.ExecTimes = 2;//執行次數
                    //            //oPayment.SendExtend.PeriodReturnURL = "";//伺服器端回傳定期定額的執行結果網址。

                    //            #endregion


                    /* 產生訂單 */
                    enErrors.AddRange(oPayment.CheckOut());
                    oPayment.CheckOutString(ref html);
                }
            }
            catch (Exception ex)
            {
                // 例外錯誤處理。
                enErrors.Add(ex.Message);
            }
            finally
            {
                // 顯示錯誤訊息。
                if (enErrors.Count() > 0)
                {
                    // string szErrorMessage = String.Join("\\r\\n", enErrors);
                }
            }
            return html;

        }

        public void CheckECPayFeedBack()
        {
            List<string> enErrors = new List<string>();
            Hashtable htFeedback = null;

            try
            {
                using (AllInOne oPayment = new AllInOne())
                {
                    oPayment.HashKey = "5294y06JbISpM5x9";//ECPay 提供的 HashKey
                    oPayment.HashIV = "v77hoKGq4kWxNNIS";//ECPay 提供的 HashIV
                    /* 取回付款結果 */
                    enErrors.AddRange(oPayment.CheckOutFeedback(ref htFeedback));
                }
                // 取回所有資料
                if (enErrors.Count() == 0)
                {
                    /* 支付後的回傳的基本參數 */
                    string szMerchantID = String.Empty;
                    string szMerchantTradeNo = String.Empty;
                    string szPaymentDate = String.Empty;
                    string szPaymentType = String.Empty;
                    string szPaymentTypeChargeFee = String.Empty;
                    string szRtnCode = String.Empty;
                    string szRtnMsg = String.Empty;
                    string szSimulatePaid = String.Empty;
                    string szTradeAmt = String.Empty;
                    string szTradeDate = String.Empty;
                    string szTradeNo = String.Empty;
                    // 取得資料
                    foreach (string szKey in htFeedback.Keys)
                    {
                        switch (szKey)
                        {
                            /* 支付後的回傳的基本參數 */
                            case "MerchantID": szMerchantID = htFeedback[szKey].ToString(); break;
                            case "MerchantTradeNo": szMerchantTradeNo = htFeedback[szKey].ToString(); break;
                            case "PaymentDate": szPaymentDate = htFeedback[szKey].ToString(); break;
                            case "PaymentType": szPaymentType = htFeedback[szKey].ToString(); break;
                            case "PaymentTypeChargeFee": szPaymentTypeChargeFee = htFeedback[szKey].ToString(); break;
                            case "RtnCode": szRtnCode = htFeedback[szKey].ToString(); break;
                            case "RtnMsg": szRtnMsg = htFeedback[szKey].ToString(); break;
                            case "SimulatePaid": szSimulatePaid = htFeedback[szKey].ToString(); break;
                            case "TradeAmt": szTradeAmt = htFeedback[szKey].ToString(); break;
                            case "TradeDate": szTradeDate = htFeedback[szKey].ToString(); break;
                            case "TradeNo": szTradeNo = htFeedback[szKey].ToString(); break;
                            default: break;
                        }
                    }
                }
                else
                {
                    // 其他資料處理。
                }
            }
            catch (Exception ex)
            {
                // 例外錯誤處理。
                enErrors.Add(ex.Message);
            }
            finally
            {
                this.Response.Clear();
                // 回覆成功訊息。
                if (enErrors.Count() == 0)
                { this.Response.Write("1|OK"); }
                // 回覆錯誤訊息。
                else
                {
                    this.Response.Write(String.Format("0|{0}", String.Join("\\r\\n", enErrors)));
                    this.Response.Flush();
                    this.Response.End();
                }
            }
        }

        
    }
}