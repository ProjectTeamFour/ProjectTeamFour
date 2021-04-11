using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ProjectTeamFour.Service
{
    //enum MyProjectStatusFilter
    //{
    //    SubmitStatus,
    //    Approval,

    //}
    public class MyProjectsService
    {
        private readonly DbContext _ctx;
        private readonly BaseRepository _repository;
        public MyProjectsService()
        {
            _ctx = new ProjectContext();
            _repository = new BaseRepository(_ctx);
        }


        public List<MyProjectViewModel> GetProjectsbyMemberId(int memberId)
        {
            var myProjectsListVM = new List<MyProjectViewModel>();

            var ProjectItems = _repository.GetAll<Project>().Where(m => m.MemberId == memberId);

            var DraftProjectItems = _repository.GetAll<DraftProject>().Where(dp => dp.MemberId == memberId);

            foreach (Project entity in ProjectItems)
            {
                var myProjectVM = new MyProjectViewModel
                {
                    ProjectId = entity.ProjectId,
                    ProjectName = entity.ProjectName,
                    ProjectCoverUrl = entity.ProjectCoverUrl,
                    GoalMoney = entity.AmountThreshold,
                    CreatedDate = entity.CreatedDate,
                    LastEditTime = entity.LastEditTime,
                    SubmittedDate = entity.SubmittedDate,
                    ApprovingStatus = entity.ApprovingStatus,
                    ProjectStatus = entity.ProjectStatus,
                    EndDate = entity.EndDate,
                    StartDate = entity.StartDate,
                    ProjectMainUrl = entity.ProjectMainUrl,
                };
                myProjectsListVM.Add(myProjectVM);
            }
            return myProjectsListVM;
        }
        ////0:draft/1:approving/2:ongoing/3:ended
        //public  List<MyProjectViewModel> SortMyProjectsbyStatus(int approvingStatus)
        //{
        //    return (List<MyProjectViewModel>)_repository.GetAll<MyProjectViewModel>().Where(x => x.ApprovingStatus == approvingStatus);
        //}


        public List<MyDraftProjectViewModel> GetDraftProjectsbyMemberId(int memberId)
        {
            var myDraftProjectsListVM = new List<MyDraftProjectViewModel>();

            var DraftProjectItems = _repository.GetAll<DraftProject>().Where(dp => dp.MemberId == memberId);

            foreach (DraftProject entity in DraftProjectItems)
            {
                var myDraftProjectVM = new MyDraftProjectViewModel
                {
                    DraftProjectId = entity.DraftProjectId,
                    DraftProjectName = entity.DraftProjectName,
                    DraftProjectCoverUrl = entity.DraftProjectCoverUrl,
                    AmountThreshold = entity.AmountThreshold,
                    DraftCreatedDate = entity.DraftCreatedDate,
                    DraftLastEditTime = entity.DraftLastEditTime,
                    DraftSubmittedDate = entity.DraftSubmittedDate,
                    ApprovingStatus = entity.ApprovingStatus,
                    ProjectStatus = entity.ProjectStatus,
                    EndDate = entity.EndDate,
                    StartDate = entity.StartDate,
                    DraftProjectMainUrl = entity.DraftProjectMainUrl,
                };
                myDraftProjectsListVM.Add(myDraftProjectVM);
            }
            return myDraftProjectsListVM;
        }




    }
}