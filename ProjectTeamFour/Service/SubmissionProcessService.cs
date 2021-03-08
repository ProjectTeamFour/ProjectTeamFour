using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class SubmissionProcessService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public SubmissionProcessService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }


        public SubmissionProcessViewModel ReceiveSubmissionData(SubmissionProcessViewModel input)
        {
            SubmissionProcessViewModel SPVM = new SubmissionProcessViewModel()
            {
                ProjectItem = new ProjectListViewModel()
                {
                    ProjectItems = new List<ProjectViewModel>()
                },

                CarCarPlanItem = new CarCarPlanListViewModel()
                {
                    CarCarPlanItems = new List<CarCarPlanViewModel>()
                },

                MemberItem = new MemberListViewModel()
                {
                    Items = new List<MemberViewModel>()
                },

                ProjectDetailItem = new ProjectDetailViewModel()
                {
                    ProjectFAQList = new List<ProjectFAQViewModel>()
                },

                SelectPlanCards = new SelectPlanListViewModel()
                {
                    PlanCardItems = new List<SelectPlanViewModel>()
                }

            };

            Project entity = new Project
            {
                ProjectName = input.ProjectDetailItem.ProjectName,
                AmountThreshold = input.ProjectDetailItem.AmountThreshold,
                Category = input.ProjectDetailItem.Category,
                StartDate = input.ProjectDetailItem.StartDate,
                EndDate = input.ProjectDetailItem.EndDate,
                ProjectVideoUrl = input.ProjectDetailItem.ProjectVideoUrl,
                ProjectMainUrl = input.ProjectDetailItem.ProjectMainUrl,

            };






            return null;
        }
    }
}