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
    }
}
