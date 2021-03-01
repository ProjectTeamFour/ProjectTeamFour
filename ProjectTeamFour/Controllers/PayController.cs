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

        //public PayViewModel GetPlanIdAndQty(int Id) //從session抓方案的id&數量
        //{
        //    var cartList = (CartItemListViewModel)Session["Cart"];
            
        //}

    }
}