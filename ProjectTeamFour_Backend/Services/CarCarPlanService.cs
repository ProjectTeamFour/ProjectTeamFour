using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Services
{
    public class CarCarPlanService:ICarCarPlanService
    {
        private readonly IRepository _dbRepository;

        public CarCarPlanService(IRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public Task<CarCarPlanViewModel.CarCarPlanListResult> GetAll()
        {
            return Task.Run(() =>
            {
                CarCarPlanViewModel.CarCarPlanListResult result = new CarCarPlanViewModel.CarCarPlanListResult();
                result.MemberList = _dbRepository.GetAll<Plan>().Where(p => p.AddCarCarPlan == true).Select(P => new CarCarPlanViewModel.CarCarPlanSingleResult()
                {
                    AddCarCarPlan = P.AddCarCarPlan,
                    PlanDescription = P.PlanDescription,
                    PlanFundedPeople = P.PlanFundedPeople,
                    PlanId = P.PlanId,
                    PlanImgUrl = P.PlanImgUrl,
                    PlanPrice = P.PlanPrice,
                    PlanShipDate = P.PlanShipDate,
                    PlanTitle = P.PlanTitle,
                    ProjectId = P.ProjectId,
                    ProjectName = P.ProjectName,
                    ProjectPlanId = P.ProjectPlanId,
                    QuantityLimit = P.QuantityLimit,
                    SubmitLimit =P.SubmitLimit
                }).ToList();
                return result;
            });
        }
    }
}
