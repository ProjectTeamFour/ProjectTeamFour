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

        public ActionResult GetCategory()
        {
            
            var fliter = _projectsService.GetByProjectStatus("集資中");            
            return View(fliter);
        }

        public ActionResult GetCategoryFail()
        {

            var fail = _projectsService.GetByProjectStatus("集資失敗");
            return View(fail);
        }

        public ActionResult GetCategorySuccess()
        {

            var success = _projectsService.GetByProjectStatus("集資成功");
            return View(success);
        }

        //public ActionResult GetByPopular()
        //{
        //    var popular = _projectsService.GetByWhere((x) => x.)
        //}


        //public ActionResult GetByMoney(decimal fundingAmount) //排序金錢
        //{
        //    decimal maxPrice = 0m;
        //    var money = _projectsService.GetByWhere((X) => X.FundingAmount == fundingAmount);//還缺orderby
        //    foreach (var item in money.ProjectItems)
        //    {
        //        if (item.FundingAmount > maxPrice)
        //        {
        //            maxPrice = item.FundingAmount;
        //        }
        //    }
        //    return View(money);
        //}

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