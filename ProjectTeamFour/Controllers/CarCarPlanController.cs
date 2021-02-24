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
        private CarCarPlanService _carcarplanservice;
        public CarCarPlanController()
        {
            _carcarplanservice = new CarCarPlanService();
        }
        // GET: CarCarPlan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id, string Category)
        {
            var carcarPlanService = new CarCarPlanService();

            CarCarPlanListViewModel CarCarPlanListVM = new CarCarPlanListViewModel
            {
                CarCarPlanItems = new List<CarCarPlanViewModel>(),

                SelectCarCarPlanItem =  new CarCarPlanViewModel()
            };

            var planDetail = carcarPlanService.GetPlanId(id);

            CarCarPlanListVM.SelectCarCarPlanItem = planDetail;


            var getplans = carcarPlanService.GetAllTotal();

            foreach (var item in getplans)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            //var allPlan = carcarPlanService.GetOtherPlan(Category);

            //foreach (var item in allPlan)
            //{
            //    CarCarPlanListVM.CarCarPlanItems.Add(item);
            //}

            return View(CarCarPlanListVM);
        }
    }
}