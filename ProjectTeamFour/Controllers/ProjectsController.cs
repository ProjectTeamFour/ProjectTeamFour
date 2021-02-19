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

        public ActionResult GetCategory(string id)
        {
            
            var fliter = _projectsService.GetByWhere(p => p.ProjectStatus == id);            
            return View(fliter);
        }

        public ActionResult GetByFundingAmount(string id)
        {
            var fliter = _projectsService.GetByWhere(p => p.FundingAmount.ToString() == id);
            return View(fliter);
        }       
     


        // GET: Products
        public ActionResult Index()
        {
            var projectsService = new ProjectsService();
            List<ProjectViewModel> products = new List<ProjectViewModel>();
            var GetAll = projectsService.GetByWhere(x=>x.ProjectId!=0);
            foreach(var item in GetAll.ProjectItems)
            {
                products.Add(item);
            }
               
            
            return View(products);
        }
        

    }
}