//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using ProjectTeamFour.Service;
//using ProjectTeamFour.Models;

//namespace ProjectTeamFour.Controllers
//{
//    public class ProjectController : Controller
//    {
//        private ProjectService _projectService;
//        public ProjectController()
//        {
//            _projectService = new ProjectService();
//        }
//        // GET: Project
//        public ActionResult Index()
//        {
//            var result = _projectService.getAll();
//            return View(result);
//        }
//    }
//}