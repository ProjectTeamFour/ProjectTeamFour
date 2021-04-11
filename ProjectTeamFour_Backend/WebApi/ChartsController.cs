using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Context;
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
    public class ChartsController : ControllerBase
    {
        private readonly CarCarPlanContext _context;
        private readonly ILogger<ChartsController> _logger;
        private readonly IProjectService _projectService;
        private readonly IOrderService _orderService;

        public ChartsController(CarCarPlanContext context, ILogger<ChartsController> logger, IProjectService projectService,IOrderService orderService)
        {
            _context = context;
            _logger = logger;
            _projectService = projectService;
            _orderService = orderService;
        }


        //拿全部
        // GET: api/Projects
        [HttpGet]
        public async Task< BaseModel.BaseResult<ProjectViewModel.ProjectListforChart>> GetProjects()
        {
            var result = new BaseModel.BaseResult<ProjectViewModel.ProjectListforChart>();

            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Products控制器GET方法被呼叫, by" + UriHelper.GetDisplayUrl(Request));

            try
            {
                result.Body = await _projectService.GetAllForCharts();
                return result;
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;
                return result;
            }
        }
    }
}
