using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTeamFour.Api
{
    
    public class ProjectsController : ApiController
    {
        private ProjectsService projectService;

        public ProjectsController() 
        {
            projectService = new ProjectsService(); //呼叫service            
        }
              
        //Get api/values/Id 找特定id
        [AcceptVerbs("GET", "POST")]
        public ProjectListViewModel GetProject(string id)
        {

            return projectService.GetByWhere(x => x.Category == id ); //這邊屬性怎麼改變
        }

        //Get api/values 全部
        [AcceptVerbs("GET", "POST")]
        public ProjectListViewModel GetAll() //新增卡片資料
        {
            var projectService = new ProjectsService(); //呼叫service

            var project = new ProjectListViewModel
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            var GetAll = projectService.GetAllTotal();
            foreach (var item in GetAll.ProjectItems)
            {
                project.ProjectItems.Add(item);
            }

            return GetAll;

        }

        ////Post api/values/Id  新增卡片資料
        //public void Post([FromBody] ProjectViewModel input)
        //{
        //    var result = new ProjectViewModel();

        //}
    }
}
