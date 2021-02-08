using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class SelectPlanController : Controller
    {
        // GET: SelectPlan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlanCards()
        {

            List<SelectPlan> plans = new List<SelectPlan>
            {
                new SelectPlan{Id=1,PlanTitle="【基礎方案，現省380元】",PlanPrice=1580,FundedPeople=6,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP，帶給你一趟精彩絕倫的程式解謎故事！", ExpectShipDate=new DateTime(2021, 5, 1),PlaceAllowedShippng="寄送至特定地區"},
                new SelectPlan{Id=2,PlanTitle="【2+1完整方案，現省490元】",PlanPrice=1820,FundedPeople=88,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP＋額外收錄解碼手冊：內含額外的擴充APP挑戰，將解密40個程式關卡以及彩蛋，跟著老爹一起完整探索九大程式航道！", ExpectShipDate=new DateTime(2021, 5, 1),PlaceAllowedShippng="寄送至特定地區"},
                new SelectPlan{Id=3,PlanTitle=" ",PlanPrice=3280,FundedPeople=228,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP，帶給你一趟精彩絕倫的程式解謎故事！", ExpectShipDate=new DateTime(2021, 5, 1),PlaceAllowedShippng="寄送至特定地區"},
                new SelectPlan{Id=4,PlanTitle=" ",PlanPrice=3480,FundedPeople=11,PlanDescription="額外收錄《Coding Ocean：海霸》以及四本藏寶圖擴充，把冦丁海洋全部一起帶回家！！！", ExpectShipDate=new DateTime(2021, 5, 1),PlaceAllowedShippng="寄送至特定地區"},
                new SelectPlan{Id=5,PlanTitle=" ",PlanPrice=6800,FundedPeople=3,PlanDescription="《解碼傳說 CO·DECODE》4組與4本完整大解析，揪團挑戰最佳方案！！", ExpectShipDate=new DateTime(2021, 5, 1),PlaceAllowedShippng="寄送至特定地區"},
                new SelectPlan{Id=6,PlanTitle=" ",PlanPrice=16400,FundedPeople=3,PlanDescription="《解碼傳說 CO·DECODE》10組與10本完整大解析，揪團挑戰最佳方案！！", ExpectShipDate=new DateTime(2021, 5, 1),PlaceAllowedShippng="寄送至特定地區"}
            };

            return View(plans);
        }
    }
}