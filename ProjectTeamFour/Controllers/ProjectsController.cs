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
       
        
        // GET: Products
        public ActionResult Index(string category, string projectStatus , string id) //過濾
        {
            //category = category ?? "科技設計";
            //projectStatus = projectStatus ?? "集資中";
            //id = id ?? "Fundedpeople";
            var projectService = new ProjectsService(); //呼叫service
            var project = new ProjectListViewModel
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            var GetAll = projectService.GetAllTotalFliter(category, projectStatus , id);

            ViewData["category"] = category;
            ViewData["status"] = projectStatus;
            ViewData["id"] = id;
            return View(GetAll);
        }

        //依據集資類型的自訂路由 - kang
        // "Projects/Category/類型/集資狀態/商品

        public ActionResult Category(string type, string projectStatus, string id) //過濾
        {
            
            var projectService = new ProjectsService(); //呼叫service
            var project = new ProjectListViewModel
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            var GetAll = projectService.GetAllTotalFliter(type, projectStatus, id);

            ViewData["category"] = type;
            ViewData["status"] = projectStatus;
            ViewData["id"] = id;
            return View(GetAll);
        }


        public ActionResult GetAll(int id = 1) //換頁
        {
            
            var projectService = new ProjectsService(); //呼叫service
            
            int activePage = id; //目前所在頁
            int pageRows = 9; //每頁幾筆資料
            int totalRows = _projectsService.GetAllTotal().ProjectItems.Count(); //總筆數

            //計算page頁面
            int Pages = 0;
            Pages = (totalRows % pageRows == 0) ? (totalRows / pageRows) : (totalRows / pageRows + 1);

            int starRows = (activePage - 1) * pageRows; //起始紀錄index
            
            ViewData["Active"] = id; //頁碼
            ViewData["Pages"] = Pages; //頁數

            var project = new ProjectListViewModel
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            var GetAll = projectService.GetAllTotal().ProjectItems.OrderBy((x) => x.ProjectId).Skip(starRows).Take(pageRows).ToList();
            foreach (var item in GetAll)
            {
                project.ProjectItems.Add(item);
            }

            return View(project);
        }
    }
}