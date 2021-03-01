using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Service;

namespace ProjectTeamFour.Controllers
{
    public class PayController : Controller
    {

        private PayService _PayService;
        public PayController()
        {
            _PayService = new PayService();
        }

        // GET: pay
        public ActionResult Index()
        {
            
            
            return View();
        }

        public PayViewModel GetPlanIdAndQty(CarCarPlanViewModel carcarPlanVM) //從session抓方案的id&數量
        {
            //var cartList = new CartItemListViewModel
            //{ CartItems = new List<CarCarPlanViewModel>() };

            var cart = (CartItemListViewModel)Session["Cart"];

            var payList = new PayViewModel
            {
                CarCarPlanItems = new List<CarCarPlanViewModel>()
            };
            foreach(var p in payList.CarCarPlanItems)
            {
                foreach (var c in cart.CartItems)
                {
                    p.PlanId = c.PlanId;
                    p.Quantity = c.Quantity;
                };
            }
            return payList;            
        }

    }
}