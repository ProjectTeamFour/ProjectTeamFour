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
    }
}
