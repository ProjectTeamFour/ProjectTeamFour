using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;
namespace ProjectTeamFour.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Project> products = new List<Project>
            {
                new Project
                {
                    ProjectMainUrl = "https://i.imgur.com/fEmjPny.png",
                    Category = "科技設計",
                    ProjectStatus = "集資中",
                    ProjectName = "窩窩睏床墊｜從工廠到你家！你的第一張全方位好床墊",
                    CreatorName = "窩窩睏",
                    FundingAmount = 2053000m,
                    AmountThreshold = 1000000m,
                    EndDate = new DateTime(2021, 3, 11),
                    StartDate = new DateTime(2021, 2, 1)
                },
                new Project
                {
                    ProjectMainUrl = "https://i.imgur.com/fY4fvf2.jpg",
                    Category = "生活",
                    ProjectStatus = "集資中",
                    ProjectName = "不讓土地哭泣——預購手工木餐具・讓這片土地不受農藥污染",
                    CreatorName = "魟魚與貓",
                    FundingAmount = 105760m,
                    AmountThreshold = 400000m,
                    EndDate = new DateTime(2021, 3, 22),
                    StartDate = new DateTime(2021, 2, 1)
                }
            };
            return View(products);
        }
    }
}