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
using ProjectTeamFour.ViewModels.ForMemberView;

namespace ProjectTeamFour.Service
{
    public class BackingService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public System.Web.HttpResponse Response { get; }

        public BackingService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }


        public BackingRecordsViewModel QueryOrder(int member) //撈資料庫資料 用登入會員id找order訂單紀錄  畫面資料 == 資料庫資料 先找出現在的memberid => memberid找尋 orderId (foreach) =>再找od
        {
            var session = HttpContext.Current.Session;
            member = ((MemberViewModel)session["Member"]).MemberId; //現在登入的id
            var backorder = new BackingRecordsViewModel();                                          
            var ordermodel = _repository.GetAll<Order>().Where((x) => x.MemberId == member).Select((x) => x); //找到匹配memberid的訂單

            


            var od = ordermodel.SelectMany(x => x.OrderDetails.Select(y => y)); //訂單的詳細(好幾筆)          
            foreach (var i in od)
            {
                foreach (var items in backorder.MyOrdersList)
                {
                    items.OrderPrice = i.OrderPrice;
                    items.PlanId = i.PlanId;
                    items.PlanTitle = i.PlanTitle;
                    items.OrderQuantity = i.OrderQuantity;
                    items.OrderDetailDes = i.OrderDetailDes;
                }
                backorder.MyOrdersList.Add(i);
            }
            return backorder;

            //foreach(var item in ordermodel)
            //{
            //    var od = _repository.GetAll<OrderDetail>().Where(x => x.OrderId == item.OrderId).Select((x) => x).ToList();
            //    foreach(var i in od)
            //    {
            //        foreach(var o in backorder.MyOrdersList)
            //        {
            //            o.OrderPrice = i.OrderPrice;
            //            o.OrderQuantity = i.OrderQuantity;
            //        }                    
            //    }                
            //}
            //return backorder;
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
                MemberConEmail = member.MemberConEmail,
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
            if (session["Member"] == null || session["Cart"] == null)
            {
                return 0;
            }

            var x = ((MemberViewModel)session["Member"]);
            return ((MemberViewModel)session["Member"]).MemberId;
        }

        public int SaveData()
        {
            var session = HttpContext.Current.Session;
            var memberSession = ((MemberViewModel)session["Member"]);
            var cartSession = ((CartItemListViewModel)session["Cart"]);
            var member = _repository.GetAll<Member>().FirstOrDefault(x => x.MemberId == memberSession.MemberId); //從會員資料庫抓           
            var order = new Order
            {
                MemberId = member.MemberId,
                OrderName = member.MemberName,
                OrderAddress = member.MemberAddress,
                OrderPhone = member.MemberPhone,
                OrderConEmail = member.MemberConEmail,
                OrderTotalAccount = cartSession.TotalAccount,
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
                    OrderDetailDes = cartSession.Comment
                };
                od.Add(o);
            }

            foreach (var item in od)
            {
                item.OrderId = order.OrderId;
                _repository.Create(item);
            }
            return order.OrderId;
        }



        //回傳訂單資料給資料庫
        public void CreateOrderToDB(string RtnCode, string MerchantTradeNo, string orderId) //把購物車的資料&member回傳給資料庫
        {
            var orderint = Convert.ToInt32(orderId);
            var rtnCode = Convert.ToInt32(RtnCode);


            using (var transaction = _context.Database.BeginTransaction())
            {

                var result = _repository.GetAll<Order>().Where((x) => x.OrderId == orderint).FirstOrDefault();
                try
                {
                    result.condition = "已付款";
                    result.RtnCode = rtnCode;
                    result.TradeNo = MerchantTradeNo;
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

        public string ConnectECPay(int orderId)
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
                    oPayment.Send.ReturnURL = "https://localhost:44300/Pay/CheckECPayFeedBack";//付款完成通知回傳的網址
                    oPayment.Send.ClientBackURL = "https://localhost:44300/Home/Index";//瀏覽器端返回的廠商網址
                    oPayment.Send.OrderResultURL = "https://localhost:44300/pay/Result";//瀏覽器端回傳付款結果網址
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
                    oPayment.Send.CustomField2 = "";
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
                            URL = $"/ProjectDetail/Index/{order.ProjectId}",//商品的說明網址
                        });
                        /* 產生訂單 */
                        enErrors.AddRange(oPayment.CheckOut());
                        oPayment.CheckOutString(ref html);
                        /* 產生訂單 */
                        enErrors.AddRange(oPayment.CheckOut());
                        oPayment.CheckOutString(ref html);
                    }
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

        public BackingRecordsViewModel OrderRecord(MemberViewModel records) //回寫回歷史訂單紀錄
        {
            var session = HttpContext.Current.Session;
            records = (MemberViewModel)session["Member"]; //該會員資料
            var re = new BackingRecordsViewModel();
            var memberRecords = _repository.GetAll<Order>().Where((x) => x.MemberId == records.MemberId).FirstOrDefault(); //order的memberid 匹配 該登入的會員
            var orderRecords = _repository.GetAll<OrderDetail>().Where((x) => x.OrderId == memberRecords.OrderId).ToList(); //該會員詳細訂單資料
            foreach (var item in orderRecords)
            {
                foreach (var i in re.MyOrdersList)
                {
                    i.OrderPrice = item.OrderPrice;
                    i.OrderQuantity = item.OrderQuantity;
                    i.PlanTitle = item.PlanTitle;
                }
                re.TradeNo = memberRecords.TradeNo;
            }
            return re;
        }
    }
}                