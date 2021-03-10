using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Service;
using System.Net;

namespace ProjectTeamFour.Controllers
{
    public class PayController : Controller
    {

        private PayService _PayService;
        private MemberService _MemberService;
        
        public PayController()
        {
            _PayService = new PayService();
            _MemberService = new MemberService();
        }

        // GET: pay
        public ActionResult Index() //從session抓Id&Qty
        {

            

            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }     
            
            var cart = (CartItemListViewModel)Session["Cart"];

            var cartt=_PayService.QueryByPlanId(cart);
            
            return View(cartt);
        }
        
        public ActionResult ConnectECPay()
        {
            var orderId = _PayService.SaveData();
            //string RtnCode = "1";   //測試用
            //string MerchantTradeNo = "1";
            //_PayService.CreateOrderToDB(RtnCode, MerchantTradeNo);
            
            var result = _PayService.ConnectECPay(orderId);
            ViewData["result"] = result;
            return View();
        }

        [HttpPost]
        public ActionResult CheckECPayFeedBack()
        {

            _PayService.CheckECPayFeedBack();

            return null;
        }
        

        //public ActionResult SaveData()
        //{
            
        //    TempData["orderId"] = _PayService.SaveData();
        //    return RedirectToAction("Result");

        //}
       

        [HttpPost]
        public ActionResult Result(FormCollection form)
        {
            //if (!TempData.ContainsKey("orderId"))
            //{
            //    return null;
            //}
            //TempData.Keep();
            string RtnCode = form["RtnCode"];
            string MerchantTradeNo = form["MerchantTradeNo"];
            string OrderId = form["CustomField1"];
            TempData["RtnCode"] = RtnCode;
            TempData["OrderId"] = OrderId;
            if (ModelState.IsValid)
            {
                if (Convert.ToInt32(RtnCode) == 1)
                {
                    _PayService.CreateOrderToDB(RtnCode, MerchantTradeNo,OrderId);
                }                
            }
            return RedirectToAction("Index", "Home");
        }        
    }
}