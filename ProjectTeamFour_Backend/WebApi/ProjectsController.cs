using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly CarCarPlanContext _context;
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectService _projectService;

        public ProjectsController(CarCarPlanContext context, ILogger<ProjectsController> logger, IProjectService projectService)
        {
            _context = context;
            _logger = logger;
            _projectService = projectService;
        }

        //拿全部
        // GET: api/Projects
        [HttpGet]
        public async Task <BaseModel.BaseResult<ProjectViewModel.ProjectListResult>> GetAll()
        {
            var result = new BaseModel.BaseResult<ProjectViewModel.ProjectListResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Projects控制器GetAll方法被呼叫, by " + UriHelper.GetDisplayUrl(Request)); 

            try
            {
                result.Body = await _projectService.GetAll();
                return result;
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;
                return result;
            }
        }

        //拿待審提案
        // GET: api/Projects
        [HttpGet]
        public async Task<BaseModel.BaseResult<ProjectViewModel.ProjectListResult>> GetWaitForPass()
        {
            var result = new BaseModel.BaseResult<ProjectViewModel.ProjectListResult>();

            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + "Projects控制器GET方法被呼叫, by" + UriHelper.GetDisplayUrl(Request));

            try
            {
                result.Body = await _projectService.GetWaitForPass();
                return result;
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.IsSuccess = false;
                return result;
            }
        }




        /// <summary>
        /// 從前端審核提案資料，回傳型式為字串。共有三種型式"查無此筆資料"、"修改成功"及例外的資訊
        /// 改提案狀態
        /// </summary>
        /// <param name="waitForPassSingle"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<BaseModel.BaseResult<ProjectViewModel.ProjectSingleResult>>> EditWaitForPassProject([FromBody] ProjectViewModel.ProjectSingleResult waitForPassSingle)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " BackendMembers控制器PutBackendMember方法被呼叫 ,傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(waitForPassSingle));

            var result = new BaseModel.BaseResult<ProjectViewModel.ProjectSingleResult>();

            var editResult = await _projectService.EditWaitForPassProject(waitForPassSingle);

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



        //// GET: api/Projects
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        //{
        //    _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " Projects控制器GET方法被呼叫, by " + UriHelper.GetDisplayUrl(Request));

        //    return await _context.Projects.ToListAsync();
        //}

        // GET: api/Projects/5



        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + $" Projects控制器GET方法被呼叫 ,傳入的{nameof(id)}資料為:" + id);

            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProject(int id, Project project)
        //{
        //    _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " Projects控制器PUT方法被呼叫 ,傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(project));

        //    if (id != project.ProjectId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(project).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProjectExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + " Projects控制器Post方法被呼叫 - 傳入的資料為:" + System.Text.Json.JsonSerializer.Serialize(project));

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            _logger.LogWarning(2001, DateTime.Now.ToLongTimeString() + $"  Projects控制器Delete方法被呼叫,傳入的{nameof(id)}資料為:" + id);

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
