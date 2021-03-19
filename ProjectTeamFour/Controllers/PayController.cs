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
        
        public ActionResult ConnectECPay(PayViewModel oVM) //這裡不能放PayViewModel:因為PayViewModel的範圍太大。CartItems為空，所以totalAccount就會報錯
        {
            var order = Convert.ToInt32(TempData["orderId"]);
            var o = _PayService.CreateANewMemberData(oVM);
            var memberId = (MemberViewModel)Session["Member"];
            //var orderId = _PayService.SaveData(oVM); //傳更改的viewmodel當參數
            var result = _PayService.ConnectECPay(order, memberId);
            ViewData["result"] = result;

            return View();
        }

        [HttpPost]
        public ActionResult test(PayViewModel oVM)
        {

            var o = _PayService.CreateANewMemberData(oVM);
            //var memberId = (MemberViewModel)Session["Member"];
            var orderId = _PayService.SaveData(o); //傳更改的viewmodel當參數
            TempData["orderId"] = orderId ;

            return RedirectToAction("ConnectECPay");
        }


        [HttpPost]
        public ActionResult CheckECPayFeedBack()
        {

            _PayService.CheckECPayFeedBack();

            return null;
        }
        

        [HttpPost]
        public ActionResult Result(FormCollection form)
        {           
            string RtnCode = form["RtnCode"];
            string MerchantTradeNo = form["MerchantTradeNo"];
            string OrderId = form["CustomField1"];
            string memberId = form["CustomField2"];
            //var member = (MemberViewModel)Session["Member"];
            Session["Member"] = null;
            ((MemberViewModel)Session["Member"]).MemberId = Int32.Parse(memberId);
            TempData["RtnCode"] = RtnCode;
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