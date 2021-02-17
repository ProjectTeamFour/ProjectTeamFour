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
        


        // GET: Products
        public ActionResult Index()
        {
            List<ProjectViewModel> products = new List<ProjectViewModel>
            {
                new ProjectViewModel
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
                new ProjectViewModel
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
                },
                new ProjectViewModel
                {
                    ProjectMainUrl = "https://i.imgur.com/OQB8O5P.jpg",
                    Category = "公共在地",
                    ProjectStatus = "集資中",
                    ProjectName = "#先浪狗變少——相信動物協會「紮女養成計」，前進桃園！",
                    CreatorName = "FaithForAnimals",
                    FundingAmount = 4790327m,
                    AmountThreshold = 5200000m,
                    EndDate = new DateTime(2021, 4, 7),
                    StartDate = new DateTime(2021, 2, 7)
                },
                new ProjectViewModel
                {
                    ProjectMainUrl = "https://i.imgur.com/8hymepqm.jpg",
                    Category = "科技設計",
                    ProjectStatus = "集資中",
                    ProjectName = "Cheerpod 智慧滑鼠 | 一片在手，螢幕隨控",
                    CreatorName = "cheerdots TW",
                    FundingAmount = 50000m,
                    AmountThreshold = 761209m,
                    EndDate = new DateTime(2021, 4, 10),
                    StartDate = new DateTime(2021, 2, 10)
                },
                new ProjectViewModel
                {
                    ProjectMainUrl = "https://i.imgur.com/FTTAIvIm.png",
                    ProjectName = "開啟與孩子的第一場程式冒險 《解碼傳說 CO·DECODE》",
                    Category = "遊戲出版",
                    ProjectStatus = "集資中",
                    StartDate = new DateTime(2021, 2, 8),
                    EndDate = new DateTime(2021, 4, 8),
                    FundingAmount = 2320000m,
                    AmountThreshold = 140000m,
                    CreatorName = "Papacode-程式老爹"
                },
                new ProjectViewModel
                {
                    ProjectName = "SWOL 雙水箱旋轉拖把 | 分離淨水和污水，才是真正的乾淨",
                    Category = "科技設計",
                    ProjectStatus = "集資中",
                    StartDate = new DateTime(2021, 2, 10),
                    EndDate = new DateTime(2021, 4, 10),
                    FundingAmount = 1473828m,
                    AmountThreshold = 100000m,
                    CreatorName = "SWOL",
                    ProjectMainUrl = "https://i.imgur.com/YwrOaYYm.jpg"
                },
                new ProjectViewModel
                {
                    ProjectName = "一場集結展現消費端聲音的「珍惜 ‧ 真食物蹲點募資計畫」",
                    Category = "公共在地",
                    ProjectStatus = "集資中",
                    StartDate = new DateTime(2021, 2, 13),
                    EndDate = new DateTime(2021, 4, 13),
                    FundingAmount = 37300m,
                    AmountThreshold = 200000m,
                    CreatorName = "致理未來超市",
                    ProjectMainUrl = "https://i.imgur.com/RocoEApm.png"
                },
                new ProjectViewModel
                {
                    ProjectName = "《小狗大盜》| 淡江大傳第35屆畢業製作拍攝計畫",
                    Category = "藝術影視",
                    ProjectStatus = "集資中",
                    StartDate = new DateTime(2021, 2, 15),
                    EndDate = new DateTime(2021, 4, 15),
                    FundingAmount = 10251m,
                    AmountThreshold = 100000m,
                    CreatorName = "半獸人工作室 ORC Studio",
                    ProjectMainUrl = "https://i.imgur.com/ObjlmhQm.png"
                },
                new ProjectViewModel
                {
                    ProjectName = "拍拍打｜SWDK無線吸塵除螨機",
                    Category = "科技設計",
                    ProjectStatus = "集資中",
                    StartDate = new DateTime(2021, 2, 6),
                    EndDate = new DateTime(2021, 4, 6),
                    FundingAmount = 681820m,
                    AmountThreshold = 100000m,
                    CreatorName = "潤益國際",
                    ProjectMainUrl = "https://i.imgur.com/3QZROEUm.jpg"
                },
                new ProjectViewModel
                {
                    ProjectName = "一個把廢物變寶物的塑膠資源再生計畫-不垃圾場",
                      Category = "公共在地",
                      ProjectStatus = "集資中",
                      StartDate = new DateTime(2021, 2, 7),
                      EndDate = new DateTime(2021, 4, 7),
                      FundingAmount = 90040m,
                      AmountThreshold = 350000m,
                      CreatorName = "不垃圾場",
                      ProjectMainUrl = "https://i.imgur.com/BItzv0vm.jpg"
                }
            };
            return View(products);
        }
     

    }
}