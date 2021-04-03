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
        /// <summary>
        /// 從資料庫取得一筆後台會員資料
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id}")]
        public ActionResult<BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>> GetOneBackendMember(int id)
        {
            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongDateString() + "BackendMembersController GetOneBackendMember方法被呼叫");

            try
            {
                var queryResult= _backendMemberService.GetOne(id);

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
        /// <summary>
        /// 在後台會員資料庫中創建一筆資料
        /// </summary>
        /// <param name="backendSingle"></param>
        /// <returns></returns>
        [HttpPost]
        public  ActionResult<BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>> PostBackendMember([FromBody] BackendMemberViewModel.BackendSingleResult backendSingle)
        {
            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " BackendMembers控制器PostBackendMember方法被呼叫 ,傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(backendSingle));

            if (backendSingle==null)
            {
                return NotFound();
            }

            

            try
            {
                 result.Body = _backendMemberService.CreateOneMember(backendSingle);

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
        public ActionResult<BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>> PutBackendMember([FromBody] BackendMemberViewModel.BackendSingleResult backendSingle)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " BackendMembers控制器PutBackendMember方法被呼叫 ,傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(backendSingle));

            var result = new BaseModel.BaseResult<BackendMemberViewModel.BackendSingleResult>();

            var editResult=_backendMemberService.EditMember(backendSingle);

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
    }
}
