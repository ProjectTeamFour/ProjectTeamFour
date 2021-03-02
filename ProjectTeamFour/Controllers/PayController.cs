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
        public PayController()
        {
            _PayService = new PayService();
        }

        // GET: pay
        public ActionResult Index() //從session抓Id&Qty
        {

            var cart = (CartItemListViewModel)Session["Cart"];

            var cartt=_PayService.QueryByPlanId(cart);

            return View(cartt);
        }       

    }
}