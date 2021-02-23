using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class CarCarPlanController : Controller
    {
        // GET: CarCarPlan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var carcarPlanService = new CarCarPlanService();

            //CarCarPlanViewModel cpvm = new CarCarPlanViewModel();

            var planDetail = carcarPlanService.GetPlanId(id);
            
            return View(planDetail);
        }
    }
}