using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
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
                    FundingAmount = item.FundingAmount,
                    AmountThreshold = item.AmountThreshold,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate
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
                    PlanPrice = item.PlanPrice,
                    PlanId = item.PlanId
                };
                homeviewmodel.CarCarPlanItem.CarCarPlanItems.Add(cv);
            }

            return homeviewmodel;

        }

    }
}