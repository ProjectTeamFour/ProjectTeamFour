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


        public MyProjectListViewModel GetProjectsbyMemberId(int memberId)
        {
            var myProjects = new MyProjectListViewModel
            {
                MyProjects = new List<MyProjectViewModel>()
            };
            Project entity = _repository.GetAll<Project>().FirstOrDefault(m => m.MemberId == memberId);
            if (entity != (Project)default)
            {
                var myProjectVM = new MyProjectViewModel
                {
                    ProjectId = entity.ProjectId,
                    ProjectName = entity.ProjectName,
                    CreatedDate = entity.CreatedDate,
                    SubmittedDate = entity.SubmittedDate,
                    LastEditTime = entity.LastEditTime,
                    ApprovingStatus = entity.ApprovingStatus,
                    GoalMoney=entity.AmountThreshold
                };
                myProjects.MyProjects.Add(myProjectVM);
            }
            else
            {
                return null;
            }
            return myProjects;
        }
        //0:draft/1:approving/2:ongoing/3:ended
        //public  List<MyProjectViewModel> SortMyProjectsbyStatus(int approvingStatus)
        //{
        //    return (List<MyProjectViewModel>)_repository.GetAll<MyProjectViewModel>().Where(x => x.ApprovingStatus == approvingStatus);
        //}

        public List<MyProjectViewModel> SortMyProjectsbyStatus(int approvingStatus)
        {
            return (List<MyProjectViewModel>)_repository.GetAll<MyProjectViewModel>().Where(x => x.ApprovingStatus == approvingStatus);
        }
    }
}