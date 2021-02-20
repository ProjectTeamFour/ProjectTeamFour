using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Service;
using ProjectTeamFour.Models;
using System.Linq.Expressions;
using ProjectTeamFour.Repositories;

namespace ProjectTeamFour.Controllers
{
    public class ProjectsController : Controller
    {
        private ProjectsService _projectsService;
        public ProjectsController()
        {
            _projectsService = new ProjectsService();
        }

        public ActionResult GetCategory(string id) //排序狀態  
        {

            var fliter = _projectsService.GetByWhere(p => p.ProjectStatus == id);

            return View(fliter);
        }
        

        public ActionResult GetType(string id) //排序類別
        {
            var type = _projectsService.GetByWhere(p => p.Category == id);
            return View(type);
        }

        public ActionResult OrderByPeople() //排序人數 
        {
            var Fundedpeople = _projectsService.OrderBy(x => x.Fundedpeople);
            return View(Fundedpeople);
        }
        public ActionResult OrderByFundingAmount() //排序金錢
        {

            var FundingAmount = _projectsService.OrderBy(x => x.FundingAmount);
            return View(FundingAmount);
        }

        public ActionResult OrderByNew() //排序時間
        {

            //var dateLine = _projectsService.OrderBy(x => (decimal)x.dateLine);
            var dateLine = _projectsService.OrderByTime();
            return View(dateLine);
        }

        // GET: Products
        public ActionResult Index() //主畫面
        {
            
            List<ProjectViewModel> products = new List<ProjectViewModel>();
            var GetAll = _projectsService.GetByWhere(x=>x.ProjectId!=0);
            foreach(var item in GetAll.ProjectItems)
            {
                products.Add(item);
            }                           
            return View(products);
        }

        public ActionResult GetItem(string projectStatus , string category , string id)
        {
            var result= _projectsService.GetByWhere(x => x.ProjectStatus == projectStatus && x.Category == category);
            return View(result);
                           

        }
        

    }
}