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

        //public ActionResult GetCategory(string category,string projectStatus, string id) //排序狀態  
        //{
        //    var all = _projectsService.GetAllTotal();   //找全部的方法                      //後端寫三層過濾 前端用js湊出網址 ex:/Projects/GetCategory/?{id}&&{id2}&&{id3}
        //    var result = all.ProjectItems.AsEnumerable();    //延遲執行               //湊出網址後window.onload刷新網址 點進新網址
        //    result = result.Where(x => x.Category == category);  
        //    result = result.Where(x => x.ProjectStatus == projectStatus);
        //    if (id == "募資金額")
        //    {
        //        result = result.OrderBy(x => x.FundingAmount).AsEnumerable();
        //    }
        //    return View(result);
        //}
        

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
        public ActionResult Index(string category, string projectStatus , string id) //過濾
        {
            category = category ?? "科技設計";
            projectStatus = projectStatus ?? "集資中";
            id = id ?? "Fundedpeople";
            var projectService = new ProjectsService(); //呼叫service
            var project = new ProjectListViewModel
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            var GetAll = projectService.GetAllTotal123(category, projectStatus , id);

            ViewData["category"] = category;
            ViewData["status"] = projectStatus;
            ViewData["id"] = id;
            return View(GetAll);
        }

        public ActionResult Main() //主畫面 呼叫全部資料
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

        public ActionResult GetAll()
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


    }
}