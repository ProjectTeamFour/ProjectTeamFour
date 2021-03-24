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

            CarCarPlanListViewModel CarCarPlanListVM = new CarCarPlanListViewModel
            {
                CarCarPlanItems = new List<CarCarPlanViewModel>(),

                SelectCarCarPlanItem = new CarCarPlanViewModel()
            };

            var getPlans = _carcarplanservice.GetAllTotal();

            foreach (var item in getPlans)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            return View(CarCarPlanListVM);
        }




        public ActionResult Type(string id)
        {
            CarCarPlanListViewModel CarCarPlanListVM = new CarCarPlanListViewModel
            {
                CarCarPlanItems = new List<CarCarPlanViewModel>(),

                SelectCarCarPlanItem = new CarCarPlanViewModel()
            };


            var getPlans = _carcarplanservice.GetOtherPlan(id);

            foreach (var item in getPlans)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            return View(CarCarPlanListVM);

        }


        public ActionResult Search(string id)
        {

            CarCarPlanListViewModel CarCarPlanListVM = new CarCarPlanListViewModel
            {
                CarCarPlanItems = new List<CarCarPlanViewModel>(),

                SelectCarCarPlanItem = new CarCarPlanViewModel()
            };

            var searchPlanTitle = _carcarplanservice.SearchPlanTitle(id);
            var searchPlanDescription = _carcarplanservice.SearchPlanDescription(id);
            var searchProjectName = _carcarplanservice.SearchPlanTitle(id);
            var searchCategory = _carcarplanservice.SearchCategory(id);


            foreach (var item in searchPlanTitle)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            foreach (var item in searchPlanDescription)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            foreach (var item in searchProjectName)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            foreach (var item in searchCategory)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            CarCarPlanListVM.CarCarPlanItems.GroupBy(x => x.PlanTitle).Select(x => x.First());

            return View(CarCarPlanListVM);

        }

        public ActionResult Detail(int id, string Category)
        {
            //var carcarPlanService = new CarCarPlanService();

            CarCarPlanListViewModel CarCarPlanListVM = new CarCarPlanListViewModel
            {
                CarCarPlanItems = new List<CarCarPlanViewModel>(),

                SelectCarCarPlanItem =  new CarCarPlanViewModel()
            };

            var planDetail = _carcarplanservice.GetPlanId(id);

            CarCarPlanListVM.SelectCarCarPlanItem = planDetail;

            
            var getPlans = _carcarplanservice.GetAllTotal();

            foreach (var item in getPlans)
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