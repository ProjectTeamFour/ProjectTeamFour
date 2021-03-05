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
            //var cartlist = new CarCarPlanViewModel();
            if (true)
            {                
               
                _PayService.CreateOrderToDB();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}