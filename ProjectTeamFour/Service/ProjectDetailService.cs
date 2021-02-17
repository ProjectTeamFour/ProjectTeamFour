using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.Models;
using System.Data.Entity;
using System.Net.Http;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;

namespace ProjectTeamFour.Service
{
    public class ProjectDetailService
    {
        public DbContext _context;
        private BaseRepository _repository;
        public ProjectDetailService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        public ProjectDetailViewModel GetProjectDetail(Expression<Func<Project, bool>> ProjectId)
        {
            var entity = _repository.GetAll<Project>().FirstOrDefault(ProjectId);
            var projectdetailVM = new ProjectDetailViewModel()
            {
                Category = entity.Category,
                ProjectStatus = entity.ProjectStatus,
                ProjectName = entity.ProjectName,
                CreatorName = entity.CreatorName,
                FundingAmount = entity.FundingAmount,
                Fundedpeople = entity.Fundedpeople,
                ProjectDescription = entity.ProjectDescription,
                ProjectImgUrl = entity.ProjectImgUrl,
                ProjectVideoUrl = entity.ProjectVideoUrl,
                AmountThreshold = entity.AmountThreshold,
                Project_Question = entity.Project_Question,
                Project_Answer = entity.Project_Answer​,
                EndDate = new DateTime(2021, 3, 11),
                StartDate = new DateTime(2021, 2, 1)
            };
            return projectdetailVM;
        }
    }
}