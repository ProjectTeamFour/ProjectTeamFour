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


        public MyProjectsViewModel GetProjectsbyMemberId(int memberId)
        {
            var myProjects = new MyProjectsViewModel
            {
                MyProjectsList = new List<MyProjectsViewModel.MyProject>()
            };
            Project entity = _repository.GetAll<Project>().FirstOrDefault(m => m.MemberId == memberId);
            if (entity != (Project)default)
            {
                var myProjectVM = new MyProjectsViewModel.MyProject()
                {
                    ProjectId = entity.ProjectId,
                    ProjectName = entity.ProjectName,
                    CreatedDate = entity.CreatedDate,
                    SubmittedDate = entity.SubmittedDate,
                    LastEditTime = entity.LastEditTime,
                    ApprovingStatus = entity.ApprovingStatus
                };
                myProjects.MyProjectsList.Add(myProjectVM);
            }
            else
            {
                return null;
            }
            return myProjects;
        }





    }
}