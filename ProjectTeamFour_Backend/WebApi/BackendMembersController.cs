using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Interfaces;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
        /// <summary>
        /// 從資料庫取得一筆後台會員資料
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task <ActionResult<BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>>> GetOneBackendMember(int id)
        {
            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongDateString() + "BackendMembersController GetOneBackendMember方法被呼叫");

            try
            {
                var queryResult= await _backendMemberService.GetOne(id);

                if(queryResult==null)
                {
                    return NotFound();
                }
                else
                {
                    result.Body = queryResult;
                    return result;
                }
                
                
                
            }
            catch(Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;

                return result;
            }
        }

        /// <summary>
        /// 從資料庫取得所有後台會員資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task <BaseModel.BaseResult<BackendMemberViewModel.BackendListResult>> GetAll()
        {
            //var result = Members.Join(Projects, m => m.MemberId, p => p.MemberId, (m, p) => new { m.MemberId, m.MemberRegEmail, m.MemberBirth, p.ProjectId, p.ProjectName, p.FundingAmount, p.AmountThreshold, p.StartDate, p.EndDate, p.ProjectStatus })
            //.Join(Plans, p => p.ProjectId, pl => pl.ProjectId, (p, pl) => new { p.MemberId, p.MemberRegEmail, p.ProjectId, p.ProjectName, pl.PlanId, pl.PlanTitle, pl.AddCarCarPlan });

            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendListResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongDateString() + "BackendMembersController GetAll方法被呼叫");

            try
            {
                result.Body = await _backendMemberService.GetAll();

                return result;
            }
            catch(Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;

                return result;
            }

        }
        /// <summary>
        /// 在後台會員資料庫中創建一筆資料
        /// </summary>
        /// <param name="backendSingle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task <ActionResult<BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>>> PostBackendMember([FromBody] BackendMemberViewModel.BackendSingleResult backendSingle)
        {
            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " BackendMembers控制器PostBackendMember方法被呼叫 ,傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(backendSingle));
            try
            {
                result.Body = await _backendMemberService.CreateOneMember(backendSingle);



                return result;
            }
            catch(Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;
                return result;
            }

        }
        /// <summary>
        /// 從前端修改資料庫會員資料，回傳型式為字串。共有三種型式"查無此筆資料"、"修改成功"及例外的資訊
        /// </summary>
        /// <param name="backendSingle"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task <ActionResult<BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>>> PutBackendMember([FromBody] BackendMemberViewModel.BackendSingleResult backendSingle)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " BackendMembers控制器PutBackendMember方法被呼叫 ,傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(backendSingle));

            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();
            if (!ModelState.IsValid)
            {
                result.Msg = "查無此筆資料";
                result.IsSuccess = false;

                return result;
            }

            var editResult=await _backendMemberService.EditMember(backendSingle);

            result.Msg = editResult;
            if (result.Msg == "查無此筆資料")
            {
                
                result.IsSuccess = false;
                return result;
            }
            else if(result.Msg == "修改成功")
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

        [HttpDelete]
        public async Task <ActionResult<BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>>> DeleteBackendMember([FromBody] BackendMemberViewModel.BackendSingleResult backendSingle)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " BackendMembers控制器DeleteBackendMember方法被呼叫 ,傳入的資料為:" + $"Product controller Get called ,Parameter is {nameof(backendSingle.MemberId)} " + backendSingle.MemberId);

            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();
            if (!ModelState.IsValid||backendSingle.MemberId==2)
            {
                result.Msg = "查無此筆資料";
                result.IsSuccess = false;

                return result;
            }

            var deleteResult = await _backendMemberService.DeleteMember(backendSingle);

            result.Msg = deleteResult;
            if (result.Msg == "查無此筆資料")
            {

                result.IsSuccess = false;
                return result;
            }
            else if (result.Msg == "刪除成功")
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
