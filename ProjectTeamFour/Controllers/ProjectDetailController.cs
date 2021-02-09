using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class ProjectDetailController : Controller
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
