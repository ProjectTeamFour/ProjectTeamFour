using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.Models;
using System.Data.Entity;
using System.Net.Http;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;

namespace ProjectTeamFour.Service
{
    public class ProjectDetailMockService : IProjectDetailService
    {

        public ProjectDetailMockService()
        {

        }

        public ProjectDetailViewModel GetProjectDetail(int projectId)
        {

            var projectdetailVM = new ProjectDetailViewModel()
            {
                Category = "Category",
                ProjectStatus = "ProjectStatus",
                ProjectName = "ProjectName",
                CreatorName = "CreatorName",
                FundingAmount = 100,
                Fundedpeople = 10,
                ProjectDescription = "ProjectDescription",
                ProjectImgUrl = "ProjectImgUrl",
                ProjectVideoUrl = "ProjectVideoUrl",
                AmountThreshold = 2000,
                Project_Question = "Project_Question",
                Project_Answer = "Project_Answer",
                EndDate = new DateTime(2021, 3, 11),
                StartDate = new DateTime(2021, 2, 1)
            };
            return projectdetailVM;
        }

        public ProjectPageViewModel GetPageViewModel(int projectID)
        {
            ProjectPageViewModel projectPageViewModel = new ProjectPageViewModel
            {
                projectDetailViewModel = GetProjectDetail(projectID),
                PlanCardItems = GetPlanCards(projectID)
            };
            return projectPageViewModel;
        }


        public List<SelectPlanViewModel> GetPlanCards(int projectId)
        {
            List<SelectPlanViewModel> PlanCardItems = new List<SelectPlanViewModel>()
            {
                            new SelectPlanViewModel
                            {
                                ProjectId = 1,
                                PlanId = 1,
                                ProjectPlanId = 1,
                                PlanTitle = "【台制 單人標準 1 張】",
                                PlanDescription = "台制單人｜90 x 188 x 26 cm±1cm 原價 20,800 元(現省 9, 000元)► 免費搬運舊床墊至管理處或巷口► 全台灣寄送免運費(台灣本島)► 偏遠地區須加運費",
                                PlanFundedPeople = 1,
                                PlanShipDate = new DateTime(2021, 3, 29),
                                PlanImgUrl = "https://i.imgur.com/dmoLRa1.png",
                                PlanPrice = 11800m,
                                QuantityLimit = 0
                            },
                            new SelectPlanViewModel
                                {ProjectId=1,PlanTitle="【基礎方案，現省380元】",PlanPrice=1580,PlanFundedPeople=6,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP，帶給你一趟精彩絕倫的程式解謎故事！", PlanShipDate=new DateTime(2021, 5, 1)},
                            new SelectPlanViewModel
                                {ProjectId=2,PlanTitle="【2+1完整方案，現省490元】",PlanPrice=1820,PlanFundedPeople=88,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP＋額外收錄解碼手冊：內含額外的擴充APP挑戰，將解密40個程式關卡以及彩蛋，跟著老爹一起完整探索九大程式航道！", PlanShipDate=new DateTime(2021, 5, 1)},
                            new SelectPlanViewModel
                                {ProjectId=3,PlanTitle=" ",PlanPrice=3280,PlanFundedPeople=228,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP，帶給你一趟精彩絕倫的程式解謎故事！", PlanShipDate=new DateTime(2021, 5, 1)},
                            new SelectPlanViewModel
                                {ProjectId=4,PlanTitle=" ",PlanPrice=3480,PlanFundedPeople=11,PlanDescription="額外收錄《Coding Ocean：海霸》以及四本藏寶圖擴充，把冦丁海洋全部一起帶回家！！！", PlanShipDate=new DateTime(2021, 5, 1)},
                            new SelectPlanViewModel
                                {ProjectId=5,PlanTitle=" ",PlanPrice=6800,PlanFundedPeople=3,PlanDescription="《解碼傳說 CO·DECODE》4組與4本完整大解析，揪團挑戰最佳方案！！", PlanShipDate=new DateTime(2021, 5, 1)},
                            new SelectPlanViewModel
                                {ProjectId=6,PlanTitle=" ",PlanPrice=16400,PlanFundedPeople=3,PlanDescription="《解碼傳說 CO·DECODE》10組與10本完整大解析，揪團挑戰最佳方案！！", PlanShipDate=new DateTime(2021, 5, 1)}
            };
            return PlanCardItems;
        }
    }
}
