using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class HomeService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public HomeService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
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

            foreach (var item in _repository.GetAll<Project>())
            {

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
                    QuantityLimit = item.QuantityLimit
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
                    QuantityLimit = item.QuantityLimit
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