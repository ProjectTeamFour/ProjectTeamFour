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




        public List<CarCarPlanViewModel> GetOtherPlan(string Category)
        {
            return GetOtherPlan(x => x.Project.Category == Category);
        }


        public List<CarCarPlanViewModel> GetOtherPlan(Expression<Func<Plan, bool>> Category)
        {

            List<CarCarPlanViewModel> lccpvm = new List<CarCarPlanViewModel>();

            var carcarPlans = _repository.GetAll<Plan>().Where(Category);
            foreach (var item in carcarPlans)
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
    }
}
