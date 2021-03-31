using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Interfaces;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BackendMembersController : ControllerBase
    {
        private readonly IBackendMemberService _backendMemberService;
        private readonly ILogger<BackendMembersController> _logger;

        public BackendMembersController(IBackendMemberService backendMemberService, ILogger<BackendMembersController>  logger)
        {
            _backendMemberService = backendMemberService;
            _logger = logger;
        }

        [HttpGet]
        public BaseModel.BaseResult<BackendMemberViewModel.BackendListResult> GetAll()
        {
            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendListResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongDateString() + "BackendMembersController GetAll方法被呼叫");

            try
            {
                result.Body = _backendMemberService.GetAll();

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
