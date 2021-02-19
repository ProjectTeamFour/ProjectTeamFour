using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.Service
{
    public class ProjectsService
    {
        private DbContext _context;
        private BaseRepository _reposity;

        public ProjectsService()
        {
            _context = new ProjectContext();
            _reposity = new BaseRepository(_context);
        }

        public ProjectTotalViewModel GetByWhere(Expression<Func<Project, bool>> KeySelctor) //判斷是否符合條件判斷
        {
            var result = _reposity.GetAll<Project>().Where(KeySelctor); //篩選條件邏輯
            var project = new ProjectTotalViewModel
            {
                ProjectItems = new List<ProjectViewModel>()
            };
            foreach(var item in result)
            {
                var projectbox = new ProjectViewModel
                {
                    ProjectMainUrl = item.ProjectMainUrl,
                    Category = item.Category,
                    ProjectStatus = item.ProjectStatus,
                    ProjectName = item.ProjectName,
                    CreatorName = item.CreatorName,
                    FundingAmount = item.FundingAmount,
                    AmountThreshold = item.AmountThreshold,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate
                };
                project.ProjectItems.Add(projectbox);
            }
            return project;
        }

        public ProjectTotalViewModel GetByProjectStatus(string projectStatus)
        {
            return GetByWhere(p => p.ProjectStatus == projectStatus);
        }

        //public ProjectListViewModel OrderBy(string Key, string label)
        //{
        //    var result = _reposity.GetAll<Project>().OrderBy(x => x.FundingAmount);
        //}

        //public ProjectListViewModel GetByMoney()
        //{
            //var result = new ProjectListViewModel();
            //result.ProjectItems = new List<ProjectViewModel>();
            //ProjectContext context = new ProjectContext();
            //BaseRepository repo = new BaseRepository(context);
            
            //var result = new ProjectListViewModel();
            //result.ProjectItems = new List<ProjectViewModel>();
            //ProjectContext context = new ProjectContext();
            //BaseRepository repo = new BaseRepository(context);
            //foreach (var item in repo.GetAll<ProjectViewModel>().OrderBy((x) => x.FundingAmount))
            //{
            //    var p = new ProjectViewModel()
            //    {
            //        FundingAmount = item.FundingAmount
            //    };
            //    result.ProjectItems.Add(p);
            //}
            //return result;
        //}
        
        //public ProjectListViewModel GetByPrice() //按照價錢排序
        //{
        //    var result = new ProjectListViewModel();
        //    result.ProjectItems = new List<ProjectViewModel>();
        //    ProjectContext context = new ProjectContext();
        //    BaseRepository<ProjectViewModel> repository = new BaseRepository<ProjectViewModel>(context);
        //    foreach (var item in repository.GetAll<ProjectViewModel>().OrderBy((x) => x.)
        //}
    }
}