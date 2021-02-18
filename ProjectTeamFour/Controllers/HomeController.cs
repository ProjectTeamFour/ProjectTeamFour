using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.Controllers
{
    public class HomeController : Controller
    {

        private ProjectsService _projectsService;
        public HomeController()
        {
            _projectsService = new ProjectsService();
        }
        public ActionResult Index()

        {
            List<ProjectViewModel> projects = new List<ProjectViewModel>
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
                }
            };

            List<CarCarPlanViewModel> carcarplan = new List<CarCarPlanViewModel>()
            {
                new CarCarPlanViewModel
                {
                    PlanImgUrl ="https://i.imgur.com/dmoLRa1.png",
                    Category = "科技設計",
                    ProjectName = "窩窩睏床墊｜從工廠到你家！你的第一張全方位好床墊",
                    PlanTitle = "【台制 單人標準 1 張】",
                    CreatorName = "窩窩睏",
                    PlanPrice = 11800m,
                },
                 new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/eCm2xgg.jpg",
                    Category = "生活",
                    ProjectName = "不讓土地哭泣——預購手工木餐具・讓這片土地不受農藥污染",
                    PlanTitle = "【單純贊助，不需要任何回饋！】",
                    CreatorName = "魟魚與貓",
                    PlanPrice = 500m,
                },
                  new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/S0pVvGNm.jpg",
                    Category = "公共在地",
                    ProjectName = "#先浪狗變少——相信動物協會「紮女養成計」，前進桃園！",
                    PlanTitle = "【 隨喜贊助 】",
                    CreatorName = "FaithForAnimals",
                    PlanPrice = 100m,
                },
                   new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/l1PaFfwm.jpg",
                    Category = "科技設計",
                    ProjectName = "Cheerpod 智慧滑鼠 | 一片在手，螢幕隨控",
                    PlanTitle = "CheerPod x1",
                    CreatorName = "cheerdots TW",
                    PlanPrice = 1590m,
                },
                    new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/Pm8tb4dm.jpg",
                    Category = "遊戲出版",
                    ProjectName = "開啟與孩子的第一場程式冒險 《解碼傳說 CO·DECODE》",
                    PlanTitle = "額外收錄《Coding Ocean：海霸》以及四本藏寶圖擴充",
                    CreatorName = "Papacode-程式老爹",
                    PlanPrice = 3280m,
                },
                     new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/Z6uzD7Xm.jpg",
                    Category = "科技設計",
                    ProjectName = "SWOL 雙水箱旋轉拖把 | 分離淨水和污水，才是真正的乾淨",
                    PlanTitle = "SWOL 雙水箱旋轉拖把 1 組",
                    CreatorName = "SWOL",
                    PlanPrice = 949m,
                },
                      new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/TebfrQ4m.png",
                    Category = "公共在地",
                    ProjectName = "一場集結展現消費端聲音的「珍惜 ‧ 真食物蹲點募資計畫」",
                    PlanTitle = "【單純贊助，感謝有你】",
                    CreatorName = "致理未來超市",
                    PlanPrice = 300m,
                },
                       new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/vxeNl2mm.jpg",
                    Category = "藝術影視",
                    ProjectName = "《小狗大盜》| 淡江大傳第35屆畢業製作拍攝計畫",
                    PlanTitle = "回饋內容：✓ 明信片1款 ✓ 片尾感謝",
                    CreatorName = "半獸人工作室 ORC Studio",
                    PlanPrice = 180m,
                },
                        new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/60FYPzRm.png",
                    Category = "科技設計",
                    ProjectName = "拍拍打｜SWDK無線吸塵除螨機",
                    PlanTitle = "► 限量優惠價 ",
                    CreatorName = "潤益國際",
                    PlanPrice = 2480m,
                },
                         new CarCarPlanViewModel
                {
                    PlanImgUrl = "https://i.imgur.com/tKxVktQm.jpg",
                    Category = "公共在地",
                    ProjectName = "一個把廢物變寶物的塑膠資源再生計畫-不垃圾場",
                    PlanTitle = "塑膠再生寶石耳環x1對 ",
                    CreatorName = "不垃圾場",
                    PlanPrice = 450m,
                },
            };


            HomePageViewModel homepageview = new HomePageViewModel()
            {
                ProjectItem = new List<ProjectListViewModel>()
                {
                     new ProjectListViewModel()
                    {
                          ProjectItems = new List<ProjectViewModel>()
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
                                }
                          },
                    },
                },

                CarCarPlanItem = new List<CarCarPlanListViewModel>()
                {
                    new CarCarPlanListViewModel()
                    {
                        CarCarPlanItems = carcarplan
                    },
                },
            };

            


            //ViewData["carcarplan"] = carcarplan;

            return View(projects);
        }
    }
}