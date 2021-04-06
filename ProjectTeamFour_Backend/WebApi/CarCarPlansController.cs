using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Interfaces;
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
    }
}
