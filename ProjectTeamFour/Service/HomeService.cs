using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class HomeService
    {
        private DbContext _context;
        private BaseRepository _repository;
        private ProjectContext _prContext;

        public HomeService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
            _prContext = new ProjectContext();
        }

        public HomeViewModel GetAllTotal()
        {
            HomeViewModel homeviewmodel = new HomeViewModel()
            {
                ProjectItem = new ProjectListViewModel()
                {
                    ProjectItems = new List<ProjectViewModel>()
                },

                CarCarPlanItem = new CarCarPlanListViewModel()
                {
                    CarCarPlanItems = new List<CarCarPlanViewModel>()
                }
            };

            foreach (var item in _repository.GetAll<Project>().ToList())
            {
                //UpdateProjectStatus(item);
                ProjectViewModel pv = new ProjectViewModel()
                {
                    ProjectMainUrl = item.ProjectMainUrl,
                    Category = item.Category,
                    ProjectStatus = item.ProjectStatus,
                    ProjectName = item.ProjectName,
                    CreatorName = item.CreatorName,
                    FundingAmount = (int)item.FundingAmount,
                    AmountThreshold = item.AmountThreshold,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    ProjectId = item.ProjectId,
                    ApprovingStatus = item.ApprovingStatus,
                    Fundedpeople = item.Fundedpeople,
                };
                homeviewmodel.ProjectItem.ProjectItems.Add(pv);
            }


            foreach (var item in _repository.GetAll<Plan>())
            {

                CarCarPlanViewModel cv = new CarCarPlanViewModel()
                {
                    PlanImgUrl = item.PlanImgUrl,
                    ProjectName = item.ProjectName,
                    Category = item.Project.Category,
                    PlanTitle = item.PlanTitle,
                    CreatorName = item.Project.CreatorName,
                    PlanPrice = (int)item.PlanPrice,
                    PlanId = item.PlanId,
                    PlanDescription = item.PlanDescription,
                    ProjectId = item.ProjectId,
                    QuantityLimit = item.QuantityLimit,
                    AddCarCarPlan = item.AddCarCarPlan
                };
                if (cv.QuantityLimit > 0)
                {
                    homeviewmodel.CarCarPlanItem.CarCarPlanItems.Add(cv);
                }
            }

            return homeviewmodel;

        }


        public HomeViewModel GetSearchProjectName(string searchString)
        {
            return GetSearchCardProject(x => x.ProjectName.Contains(searchString));
        }

        public HomeViewModel GetSearchCategory(string searchString)
        {
            return GetSearchCardProject(x => x.Category.Contains(searchString));
        }

        public HomeViewModel GetSearchProjectDescription(string searchString)
        {
            return GetSearchCardProject(x => x.ProjectDescription.Contains(searchString));
        }

        public HomeViewModel GetSearchProjectQuestion(string searchString)
        {
            return GetSearchCardProject(x => x.Project_Question.Contains(searchString));
        }

        public HomeViewModel GetSearchProjectAnswer(string searchString)
        {
            return GetSearchCardProject(x => x.Project_Answer.Contains(searchString));
        }

        public HomeViewModel GetSearchCreatorName(string searchString)
        {
            return GetSearchCardProject(x => x.CreatorName.Contains(searchString));
        }

        public HomeViewModel GetSearchPlanTitle(string searchString)    //待處理 -phil
        {
            return GetSearchCardPlan(x => x.PlanTitle.Contains(searchString));
        }

        public HomeViewModel GetSearchPlanDescription(string searchString)  //待處理 -phil
        {
            return GetSearchCardPlan(x => x.PlanDescription.Contains(searchString));
        }


        //設定時鐘
        //public void setTaskAtFixedTime()
        //{
        //    DateTime now = DateTime.Now;
        //    DateTime oneOClock = DateTime.Today.AddHours(1.0); //凌晨1：00
        //    if (now > oneOClock)
        //    {
        //        oneOClock = oneOClock.AddDays(1.0);
        //    }
        //    int msUntilOne = (int)(oneOClock - now).TotalMilliseconds;

        //    var t = new Timer(UpdateProjectStatus); //這裡呼
        //    t.Change(msUntilOne, Timeout.Infinite);
        //}

        //回呼要做的事情

        //public void UpdateProjectStatus(object state)
        public void UpdateProjectStatus()
        {
            //var result = _repository.GetAll<Project>().ToList();
            var result = _prContext.Projects.ToList();
            
            //using (SqlConnection oConn = CreateMARSConnection())
            //{
            foreach (var item in result)
            {                   
                DateTime today = DateTime.Now;
                double dateLine = Convert.ToInt32(new TimeSpan(item.EndDate.Ticks - today.Ticks).TotalDays);

                if (item.ApprovingStatus == 1)
                {
                    item.ProjectStatus = "審核中";
                }
                else if (dateLine <= 0 && item.FundingAmount > item.AmountThreshold)
                {
                    item.ProjectStatus = "結束且成功";
                }
                else if (dateLine <= 0 && item.FundingAmount < item.AmountThreshold)
                {
                    item.ProjectStatus = "結束且失敗";
                    var od = _repository.GetAll<OrderDetail>().Where(x => x.ProjectId == item.ProjectId).Select(x => x).ToList();
                    foreach (var i in od)
                    {
                        var o = _repository.GetAll<Order>().Where(x => x.OrderId == i.OrderId).FirstOrDefault();
                        if(o != null)
                        {
                            if (i.condition == "已付款")
                            {
                                i.condition = "已付款(退款)";
                                _repository.Update(i);
                                o.condition = "已付款(退款)";
                                _repository.Update(o);
                            }
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        
                    }                    

                }
                else if (dateLine > 0 && item.FundingAmount > item.AmountThreshold)
                {
                    item.ProjectStatus = "集資成功";
                }
                else if (dateLine > 0 && item.FundingAmount < item.AmountThreshold)
                {
                    item.ProjectStatus = "集資中";
                }
                
            }

            _prContext.SaveChanges();

            //重新設定
            //setTaskAtFixedTime();
        }




        //public void pushPlanToCarCarPlan()
        //{
        //    var result = _prContext.Projects.Where(x => x.ProjectStatus == "結束且成功");

        //    foreach (var item in result)
        //    {
        //        DateTime today = DateTime.Now;
        //        double dateLine = Convert.ToInt32(new TimeSpan(item.EndDate.Ticks - today.Ticks).TotalDays);

        //        var projectPlan = _prContext.Plans.Where(x => x.ProjectId == item.ProjectId && x.AddCarCarPlan == true);
        //    }
        //}




        //搜尋 project

        public HomeViewModel GetSearchCardProject(Expression<Func<Project, bool>> Keyselector)
        {

            var result = _repository.GetAll<Project>().Where(Keyselector);

            HomeViewModel homeviewmodel = new HomeViewModel()
            {
                ProjectItem = new ProjectListViewModel()
                {
                    ProjectItems = new List<ProjectViewModel>()
                },

                CarCarPlanItem = new CarCarPlanListViewModel()
                {
                    CarCarPlanItems = new List<CarCarPlanViewModel>()
                }
            };

            foreach (var item in result)
            {
                var projectbox = new ProjectViewModel()
                {
                    ProjectMainUrl = item.ProjectMainUrl,
                    Category = item.Category,
                    ProjectStatus = item.ProjectStatus,
                    ProjectName = item.ProjectName,
                    CreatorName = item.CreatorName,
                    FundingAmount = item.FundingAmount,
                    AmountThreshold = item.AmountThreshold,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    ProjectId = item.ProjectId
                };
                homeviewmodel.ProjectItem.ProjectItems.Add(projectbox);
            }
            return homeviewmodel;
        }



        //搜尋 plan
        public HomeViewModel GetSearchCardPlan(Expression<Func<Plan, bool>> Keyselector)
        {

            var result = _repository.GetAll<Plan>().Where(Keyselector).ToList();

            HomeViewModel homeviewmodel = new HomeViewModel()
            {
                ProjectItem = new ProjectListViewModel()
                {
                    ProjectItems = new List<ProjectViewModel>()
                },

                CarCarPlanItem = new CarCarPlanListViewModel()
                {
                    CarCarPlanItems = new List<CarCarPlanViewModel>()
                }
            };

            foreach (var item in result)
            {
                var planbox = new CarCarPlanViewModel()
                {
                    PlanImgUrl = item.PlanImgUrl,
                    ProjectName = item.ProjectName,
                    Category = item.Project.Category,
                    PlanTitle = item.PlanTitle,
                    CreatorName = item.Project.CreatorName,
                    PlanPrice = (int)item.PlanPrice,
                    PlanId = item.PlanId,
                    PlanDescription = item.PlanDescription,
                    QuantityLimit = item.QuantityLimit,
                    AddCarCarPlan = item.AddCarCarPlan
                };
                if (planbox.QuantityLimit > 0)
                {
                    homeviewmodel.CarCarPlanItem.CarCarPlanItems.Add(planbox);
                }
            }
            return homeviewmodel;
        }
    }


    public class CommonEqualityComparer<T, V> : IEqualityComparer<T>  // -phil
    {
        private Func<T, V> keySelector;

        public CommonEqualityComparer(Func<T, V> keySelector)
        {
            this.keySelector = keySelector;
        }

        public bool Equals(T x, T y)
        {
            return EqualityComparer<V>.Default.Equals(keySelector(x), keySelector(y));
        }

        public int GetHashCode(T obj)
        {
            return EqualityComparer<V>.Default.GetHashCode(keySelector(obj));
        }
    }


    public static class DistinctExtensions   //-phil
    {
        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector)
        {
            return source.Distinct(new CommonEqualityComparer<T, V>(keySelector));
        }
    }
}