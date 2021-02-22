using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class HomeController : Controller
    {

        private HomeService _homeService;
        public HomeController()
        {
            _homeService = new HomeService();
        }
        public ActionResult Index()
        {

            var homeService = new HomeService();

            HomeViewModel homeviewmodel = new HomeViewModel()
            {
                ProjectItem = new ProjectListViewModel()
                {
                    ProjectItems = new List<ProjectViewModel>()
                },

                CarCarPlanItem = new CarCarPlanListViewModel()
                {
                    CarCarPlanItems = new List<CarCarPlanViewModel>()
                }
            };

            var GetAll = homeService.GetAllTotal();
            foreach (var item in GetAll.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }
            
            foreach (var item in GetAll.CarCarPlanItem.CarCarPlanItems)
            {
                homeviewmodel.CarCarPlanItem.CarCarPlanItems.Add(item);
            }

            return View(homeviewmodel);
        }




        public ActionResult Search()
        {

            var homeService = new HomeService();

            HomeViewModel homeviewmodel = new HomeViewModel()
            {
                ProjectItem = new ProjectListViewModel()
                {
                    ProjectItems = new List<ProjectViewModel>()
                },

                CarCarPlanItem = new CarCarPlanListViewModel()
                {
                    CarCarPlanItems = new List<CarCarPlanViewModel>()
                }
            };


            var GetAll = homeService.GetAllTotal();
            foreach (var item in GetAll.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }

            foreach (var item in GetAll.CarCarPlanItem.CarCarPlanItems)
            {
                homeviewmodel.CarCarPlanItem.CarCarPlanItems.Add(item);
            }

            return View(homeviewmodel);
        }

    }
}