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

            var getPlans = _carcarplanservice.GetPlanWithProjectStatusForCarCarPlan();

            foreach (var item in getPlans)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            return View(CarCarPlanListVM);
        }

        //這個action的原始設計就有點像自訂路由的需求，因此不新增find/type - kang

        public ActionResult Type(string id)
        {
            CarCarPlanListViewModel CarCarPlanListVM = new CarCarPlanListViewModel
            {
                CarCarPlanItems = new List<CarCarPlanViewModel>(),

                SelectCarCarPlanItem = new CarCarPlanViewModel()
            };

            var getPlans = _carcarplanservice.GetOtherPlan(id);
            

            if (getPlans.Count == 0)
            {

                ViewBag.ErrMsg = "找不到此類型專案";
            
            }

            foreach (var item in getPlans)
            {
                CarCarPlanListVM.CarCarPlanItems.Add(item);
            }

            return View(CarCarPlanListVM);

        }
        // 依據產品名稱搜尋的自訂路由，取得商品的邏輯與search相同 - kang
        // "CarCarPlan/Product/產品名稱",
        public ActionResult FindProjectName(string id)
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

            
            var getPlans = _carcarplanservice.GetPlanWithProjectStatusForCarCarPlan();

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