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
        private AnnouncementService _announcementService;
        public HomeController()
        {
            _homeService = new HomeService();
            _announcementService = new AnnouncementService();
        }
        public ActionResult Index()
        {
           
            if (!TempData.ContainsKey("RtnCode"))
            {
                
            }
            else
            {
                TempData.Keep("RtnCode");

            }

            var homeService = new HomeService();
            homeService.UpdateProjectStatus();
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
            homeviewmodel.Announcements = _announcementService.GetAnnouncement(28);
            return View(homeviewmodel);
        }




        public ActionResult Search(string id)
        {
            
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

            var resultCardProjectName = _homeService.GetSearchProjectName(id);
            var resultCardCategory = _homeService.GetSearchCategory(id);
            var resultCardCreatorName = _homeService.GetSearchCreatorName(id);
            var resultCardProjectDescription = _homeService.GetSearchProjectDescription(id);
            var resultCardProjectQuestion= _homeService.GetSearchProjectQuestion(id);
            var resultCardProjectAnswer = _homeService.GetSearchProjectAnswer(id);
            var resultCardPlanTitle = _homeService.GetSearchPlanTitle(id);
            var resultCardPlanDescription = _homeService.GetSearchPlanDescription(id);


            foreach (var item in resultCardProjectName.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }

            foreach (var item in resultCardCategory.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }

            foreach (var item in resultCardCreatorName.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }

            foreach (var item in resultCardProjectDescription.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }

            foreach (var item in resultCardProjectQuestion.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }

            foreach (var item in resultCardProjectAnswer.ProjectItem.ProjectItems)
            {
                homeviewmodel.ProjectItem.ProjectItems.Add(item);
            }

            //foreach (var item in resultCardPlanTitle.CarCarPlanItem.CarCarPlanItems)
            //{
            //    homeviewmodel.CarCarPlanItem.CarCarPlanItems.Add(item);
            //}

            //foreach (var item in resultCardPlanDescription.CarCarPlanItem.CarCarPlanItems)
            //{
            //    homeviewmodel.CarCarPlanItem.CarCarPlanItems.Add(item);
            //}

            var result = homeviewmodel.ProjectItem.ProjectItems.GroupBy(x => x.ProjectName).Select(y => y.First());

            //homeviewmodel.ProjectItem.ProjectItems.Count();
            //homeviewmodel.CarCarPlanItem.CarCarPlanItems.GroupBy(x => x.ProjectName).Select(y => y.First()).ToList();

            return View(result);
        }

    }
}