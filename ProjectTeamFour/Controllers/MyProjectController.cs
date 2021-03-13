using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class MyProjectController : Controller
    {
        // GET: MyProject
        public ActionResult OverView()
        {
            return View();
        }

        // GET: MyProject/Details/5
        public ActionResult Details(int Id)
        {
            return View();
        }
        
    }
}
