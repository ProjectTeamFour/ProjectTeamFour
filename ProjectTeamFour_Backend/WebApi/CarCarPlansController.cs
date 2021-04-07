using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarCarPlansController : ControllerBase
    {
        private readonly ICarCarPlanService _carCarPlanService;
        private readonly ILogger<CarCarPlansController> _logger;

        public CarCarPlansController(ICarCarPlanService carCarPlanService, ILogger<CarCarPlansController> logger)
        {
            _carCarPlanService = carCarPlanService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<BaseModel.BaseResult<CarCarPlanViewModel.CarCarPlanListResult>> GetAll()
        {
            var result = new BaseModel.BaseResult< CarCarPlanViewModel.CarCarPlanListResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongDateString() + "CarCarPlansController GetAll方法被呼叫");

            try
            {
                result.Body = await _carCarPlanService.GetAll();
                return result;
            }
            catch(Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;
                return result;
            }
        }
        [HttpPut]
        /// <summary>
        /// 從前端修改資料庫會員資料，回傳型式為字串。共有三種型式"查無此筆資料"、"修改成功"及例外的資訊
        /// </summary>
        /// <param name="backendSingle"></param>
        /// <returns></returns>
        public async Task<ActionResult<BaseModel.BaseResult<CarCarPlanViewModel.CarCarPlanSingleResult>>> PutCarCarPlan(CarCarPlanViewModel.CarCarPlanSingleResult carCarPlanVM)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " CarCarPlans控制器PutCarCarPlan方法被呼叫 ,傳入的資料為:" + $"Product controller Get called ,Parameter is {nameof(carCarPlanVM.PlanId)} " + carCarPlanVM.PlanId);

            var result = new BaseModel.BaseResult<CarCarPlanViewModel.CarCarPlanSingleResult>();
            if (!ModelState.IsValid)
            {
                result.Msg = "查無此筆資料";
                result.IsSuccess = false;

                return result;
            }

            var editResult = await _carCarPlanService.EditCarCarPlan(carCarPlanVM);

            result.Msg = editResult;

            if (result.Msg == "查無此筆資料")
            {

                result.IsSuccess = false;
                return result;
            }
            else if (result.Msg == "修改成功")
            {

                result.IsSuccess = true;
                return result;
            }
            else
            {

                result.IsSuccess = false;
                return result;
            }

        }
    }
}
