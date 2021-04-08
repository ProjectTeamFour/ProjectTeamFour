﻿using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Context;

namespace ProjectTeamFour_Backend.Services
{
    public class CarCarPlanService:ICarCarPlanService
    {
        private readonly IRepository _dbRepository;
        private readonly LabContext _labContext;

        public CarCarPlanService(IRepository dbRepository,LabContext labContext)
        {
            _dbRepository = dbRepository;
            _labContext = labContext;
        }

        public Task<CarCarPlanViewModel.CarCarPlanListResult> GetAll()
        {
            return Task.Run(() =>
            {
                CarCarPlanViewModel.CarCarPlanListResult result = new CarCarPlanViewModel.CarCarPlanListResult();
                result.CarCarPlanList = _dbRepository.GetAll<Plan>().Where(p => p.AddCarCarPlan == true).Select(P => new CarCarPlanViewModel.CarCarPlanSingleResult()
                {
                    AddCarCarPlan = P.AddCarCarPlan,
                    PlanDescription = P.PlanDescription,
                    PlanFundedPeople = P.PlanFundedPeople,
                    PlanId = P.PlanId,
                    PlanImgUrl = P.PlanImgUrl,
                    PlanPrice = P.PlanPrice,
                    PlanShipDate = P.PlanShipDate.ToString("d"),
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
        /// <summary>
        /// (非同步)將前端修改後的資料以交易方式，變更資料庫資料。回傳為字串形式:"查無此筆資料"、"修改成功"、Exception.Message
        /// </summary>
        /// <param name="singleCarCarPlan"></param>
        /// <returns></returns>
        public Task<string> EditCarCarPlan(CarCarPlanViewModel.CarCarPlanSingleResult singleCarCarPlan)
        {
            return Task.Run(() =>
            {

                var queryResult = _dbRepository.GetAll<Plan>().FirstOrDefault(P => P.PlanId == singleCarCarPlan.PlanId);
                if(queryResult==default)
                {
                    return "查無此筆資料";
                }
                queryResult.QuantityLimit = (int)singleCarCarPlan.SubmitLimit;

                queryResult.SubmitLimit = 0;
                using (var transaction = _labContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbRepository.Update<Plan>(queryResult);
                        transaction.Commit();
                        return "修改成功";
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        return ex.Message;
                    }
                }

            });
        }
    }
}