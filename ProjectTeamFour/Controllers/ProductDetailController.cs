using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class ProductDetailController : Controller
    {

        // GET: ProductDetail
        public ActionResult Index()
        {
            //ViewData.Model = productDetails;
            //return View(productDetails);
            return View();
        }
        public ActionResult Summary()
        {

            return View();
        }

        //static void IfSucceed()
        //{
        //    foreach(var item in productDetails)
        //    {

        //    }
        //}

       
    }
}
