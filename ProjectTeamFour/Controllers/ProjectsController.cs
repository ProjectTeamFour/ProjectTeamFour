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

            var projectService = new ProjectsService(); //呼叫service

            var project = new ProjectListViewModel 
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            var GetAll = projectService.GetAllTotal();
            foreach (var item in GetAll.ProjectItems)
            {
                project.ProjectItems.Add(item);
            }

            return View(project);
        }
//--------------------------------------tempdata-------------------------------------------
        //public ActionResult GetStatus(string id)
        //{

        //    var result= _projectsService.GetByWhere(x => x.ProjectStatus == id);
        //    TempData["ProjectStatus"] = result;
        //    return RedirectToAction("GetItem", "Projects");          
        //}        

        //public ActionResult GetClass(string id)
        //{
        //    var fliter = _projectsService.GetByWhere(p => p.Category == id);
        //    TempData["Category"] = fliter;
        //    return RedirectToAction("GetItem", "Projects");
        //}
        
        //public ActionResult OrderPeople() //排序人數 
        //{
        //    var Fundedpeople = _projectsService.OrderBy(x => x.Fundedpeople);
        //    return RedirectToAction("GetItem", "Projects");
        //}
        //public ActionResult OrderFundingAmount() //排序金錢
        //{

        //    var FundingAmount = _projectsService.OrderBy(x => x.FundingAmount);
        //    return RedirectToAction("GetItem" , "Projects");
        //}

        //public ActionResult OrderNew() //排序時間
        //{

        //    //var dateLine = _projectsService.OrderBy(x => (decimal)x.dateLine);
        //    var dateLine = _projectsService.OrderByTime();
        //    return RedirectToAction("GetItem", "Projects");
        //}

        public ActionResult GetItem()
        {
            return View();
        }
        //----------------------api改寫---------------------------------
        public ActionResult Getalll()
        {
            var projectService = new ProjectsService(); //呼叫service

            var project = new ProjectListViewModel
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            var GetAll = projectService.GetAllTotal();
            foreach (var item in GetAll.ProjectItems)
            {
                project.ProjectItems.Add(item);
            }

            return Json(project, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetSingle(string id)
        {
            var fliter = _projectsService.GetByWhere(p => p.ProjectStatus == id);

            return Json(fliter, JsonRequestBehavior.AllowGet);
        }
    }
}