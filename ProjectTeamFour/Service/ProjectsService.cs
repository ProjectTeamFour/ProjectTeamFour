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

        public ProjectListViewModel GetByWhere(Expression<Func<Project, bool>> KeySelctor) //判斷是否符合條件判斷
        {
            var result = _reposity.GetAll<Project>().Where(KeySelctor); //篩選條件邏輯
            var project = new ProjectListViewModel
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

        public ProjectListViewModel GetByProjectStatus(string projectStatus)
        {
            return GetByWhere(p => p.ProjectStatus == projectStatus);
        }
    }
}