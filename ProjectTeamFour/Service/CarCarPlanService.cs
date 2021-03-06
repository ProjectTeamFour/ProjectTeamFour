﻿using ProjectTeamFour.Models;
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
    public class CarCarPlanService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public CarCarPlanService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        //public CarCarPlanListViewModel GetPlanPage(int PlanId)
        //{
        //    CarCarPlanListViewModel CarCarPlanListVM = new CarCarPlanListViewModel
        //    {
        //        CarCarPlanItems = new List<CarCarPlanViewModel>()
        //    };
        //    return CarCarPlanListVM;
        //}



        //連到詳細頁
        public CarCarPlanViewModel GetPlanId(int PlanId)
        {
            return GetCarCarPlan(x => x.PlanId == PlanId);
        }

        public CarCarPlanViewModel GetCarCarPlan(Expression<Func<Plan, bool>> PlanId)
        {
            //List<CarCarPlanViewModel> lcpvm = new List<CarCarPlanViewModel>();

            var planCard = _repository.GetAll<Plan>().FirstOrDefault(PlanId);
           
               CarCarPlanViewModel cv = new CarCarPlanViewModel()
                {
                    PlanId = planCard.PlanId,
                    PlanImgUrl = planCard.PlanImgUrl,
                    Category = planCard.Project.Category,
                    ProjectName = planCard.ProjectName,
                    PlanTitle = planCard.PlanTitle,
                    PlanDescription = planCard.PlanDescription,
                    PlanPrice = (int)planCard.PlanPrice,
                    CreatorName = planCard.Project.CreatorName
                };
            
            return cv;
        }


        //全部
        public List<CarCarPlanViewModel> GetAllTotal()
        {

            List<CarCarPlanViewModel> CarCarPlanItems = new List<CarCarPlanViewModel>();

            foreach (var item in _repository.GetAll<Plan>().ToList())
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
                    PlanDescription = item.PlanDescription
                };
                CarCarPlanItems.Add(cv);
            }
            return CarCarPlanItems;
        }




        //之後依照選取類別去推薦車車卡片，待處理 -phil
        public List<CarCarPlanViewModel> GetOtherPlan(string Category)
        {
            return GetOtherPlan(x => x.Project.Category == Category);
        }


        //條件
        public List<CarCarPlanViewModel> GetOtherPlan(Expression<Func<Plan, bool>> Category)
        {

            List<CarCarPlanViewModel> lccpvm = new List<CarCarPlanViewModel>();

            var carcarPlans = _repository.GetAll<Plan>().Where(Category);
            foreach (var item in carcarPlans.ToList())
            {
                var cv = new CarCarPlanViewModel()
                {
                    PlanImgUrl = item.PlanImgUrl,
                    ProjectName = item.ProjectName,
                    Category = item.Project.Category,
                    PlanTitle = item.PlanTitle,
                    CreatorName = item.Project.CreatorName,
                    PlanPrice = (int)item.PlanPrice,
                    PlanId = item.PlanId,
                    PlanDescription = item.PlanDescription

                };
                lccpvm.Add(cv);
            }

            return lccpvm;
        }


        public List<CarCarPlanViewModel> SearchPlanTitle(string searchString)
        {
            return GetOtherPlan(x => x.PlanTitle.Contains(searchString));
        }

        public List<CarCarPlanViewModel> SearchPlanDescription(string searchString)
        {
            return GetOtherPlan(x => x.PlanDescription.Contains(searchString));
        }

        public List<CarCarPlanViewModel> SearchProjectName(string searchString)
        {
            return GetOtherPlan(x => x.ProjectName.Contains(searchString));
        }

        public List<CarCarPlanViewModel> SearchCategory(string searchString)
        {
            return GetOtherPlan(x => x.Project.Category.Contains(searchString));
        }

    }
}
