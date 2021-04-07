using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Interfaces
{
    public interface ICarCarPlanService
    {
        Task<CarCarPlanViewModel.CarCarPlanListResult> GetAll();
        /// <summary>
        /// (非同步)將前端修改後的資料以交易方式，變更資料庫資料。回傳為字串形式:"查無此筆資料"、"修改成功"、Exception.Message
        /// </summary>
        /// <param name="singleCarCarPlan"></param>
        /// <returns></returns>
        Task<string> EditCarCarPlan(CarCarPlanViewModel.CarCarPlanSingleResult singleCarCarPlan);
    }
}
