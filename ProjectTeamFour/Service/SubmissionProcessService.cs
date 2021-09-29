using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.ViewModels.ForMemberView;
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
        private ProjectContext _prcontext;

        public SubmissionProcessService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
            _prcontext = new ProjectContext();
        }

        public OperationResult ReceiveSubmissionData(SubmissionProcessViewModel input, int Id)
        {
            OperationResult result = new OperationResult();
            var member = _repository.GetAll<Member>().Where((x) => x.MemberId == Id).FirstOrDefault();
            result.Status = member.MemberId;
            //using (var transaction = _context.Database.BeginTransaction())
            //{
                try
                {
                member.MemberConEmail = input.MemberConEmail;
                member.MemberPhone = input.MemberPhone;
                member.ProfileImgUrl = input.ProfileImgUrl;
                member.AboutMe = input.AboutMe;
                member.MemberWebsite = input.MemberWebsite;
                member.MemberName = input.CreatorName;   //可以同步更動改會員名

                _repository.Update(member);
                result.IsSuccessful = true;

                //

                Project pr_entity = new Project
                {
                    MemberId = member.MemberId, //foreign
                    ProjectName = input.ProjectName,
                    AmountThreshold = input.AmountThreshold,
                    Category = input.Category,
                    StartDate = DateTime.ParseExact(input.StartDate, "yyyyMMdd", null),
                    EndDate = DateTime.ParseExact(input.EndDate, "yyyyMMdd", null),
                    ProjectVideoUrl = input.ProjectVideoUrl,
                    ProjectMainUrl = input.ProjectMainUrl,
                    ProjectCoverUrl = input.ProjectCoverUrl,
                    ProjectPrincipal = input.ProjectPrincipal,
                    IdentityNumber = input.IdentityNumber,
                    CreatorName = input.CreatorName,
                    ProjectImgUrl = input.ProjectImgUrl,
                    Project_Question = input.Project_Question,
                    Project_Answer = input.Project_Answer,
                    ProjectPlansCount = input.PlanObject.Count,
                    ProjectStatus = "審核中",
                    CreatedDate = input.CreatedDate,
                    SubmittedDate = input.SubmittedDate,
                    LastEditTime = input.LastEditTime,
                    FundingAmount = 0,
                    Fundedpeople = 0,
                    ApprovingStatus = 1,

                };
                _repository.Create(pr_entity);
                result.IsSuccessful = true;

                //

                List<SubmissionProcessPlanViewModel> planObj = input.PlanObject;
                foreach (var item in planObj)
                {
                    Plan pl_entity = new Plan
                    {
                        ProjectId = pr_entity.ProjectId,  //foreign
                        ProjectName = pr_entity.ProjectName,  //同步寫入
                        ProjectPlanId = item.ProjectPlanId,
                        PlanPrice = item.PlanPrice,
                        PlanTitle = item.PlanTitle,
                        QuantityLimit = item.QuantityLimit,
                        PlanDescription = item.PlanDescription,
                        PlanImgUrl = item.PlanImgUrl,
                        PlanShipDate = DateTime.ParseExact(item.PlanShipDate, "yyyyMMdd", null),
                        AddCarCarPlan = item.AddCarCarPlan,
                    };

                    _repository.Create(pl_entity);
                    result.IsSuccessful = true;
                }

                if (input.DraftProjectId != 0)
                {
                    var finishedDraftProject = _repository.GetAll<DraftProject>().Where(x => x.DraftProjectId == input.DraftProjectId).FirstOrDefault();
                    _repository.Delete(finishedDraftProject);
                }

                ////這裡以下還沒測
                //var project = _repository.GetAll<Project>().LastOrDefault((x) => x.MemberId == Id);
                //var planCount = _repository.GetAll<Plan>().Where((x) => x.ProjectId == project.ProjectId).Count();
                //project.ProjectPlansCount = planCount;  //寫入幾個plans
                //_repository.Update(project);
                //result.IsSuccessful = true;
                //transaction.Commit();
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
                    //transaction.Rollback();
                }
            //}
            return result;

        }


        public OperationResult ReceiveDraftData(SubmissionProcessViewModel input, int Id)
        {
            OperationResult result = new OperationResult();
            var member = _repository.GetAll<Member>().Where((x) => x.MemberId == Id).FirstOrDefault();
            result.Status = member.MemberId;
            //using (var transaction = _context.Database.BeginTransaction())
            //{
            try
            {
                member.MemberConEmail = input.MemberConEmail;
                member.MemberPhone = input.MemberPhone;
                member.ProfileImgUrl = input.ProfileImgUrl;
                member.AboutMe = input.AboutMe;
                member.MemberWebsite = input.MemberWebsite;
                member.MemberName = input.CreatorName;   //可以同步更動改會員名

                _repository.Update(member);
                result.IsSuccessful = true;

                //

                DraftProject pr_entity = new DraftProject
                {
                    MemberId = member.MemberId, //foreign
                    DraftProjectName = input.ProjectName,
                    AmountThreshold = input.AmountThreshold,
                    Category = input.Category,
                    StartDate = DateTime.ParseExact(input.StartDate, "yyyyMMdd", null),
                    EndDate = DateTime.ParseExact(input.EndDate, "yyyyMMdd", null),
                    DraftProjectVideoUrl = input.ProjectVideoUrl,
                    DraftProjectMainUrl = input.ProjectMainUrl,
                    DraftProjectCoverUrl = input.ProjectCoverUrl,
                    DraftProjectPrincipal = input.ProjectPrincipal,
                    IdentityNumber = input.IdentityNumber,
                    CreatorName = input.CreatorName,
                    DraftProjectImgUrl = input.ProjectImgUrl,
                    DraftProject_Question = input.Project_Question,
                    DraftProject_Answer = input.Project_Answer,
                    DraftProjectPlansCount = input.DraftProjectPlansCount,
                    //ProjectStatus = "審核中",
                    DraftCreatedDate = input.CreatedDate,
                    DraftSubmittedDate = input.SubmittedDate,
                    DraftLastEditTime = input.LastEditTime,
                    FundingAmount = 0,
                    Fundedpeople = 0,
                    ApprovingStatus = 0,
                };
                _repository.Create(pr_entity);
                result.IsSuccessful = true;

                //

                if (input.PlanObject != null)
                {
                    List<SubmissionProcessPlanViewModel> planObj = input.PlanObject;
                    foreach (var item in planObj)
                    {
                        DraftPlan pl_entity = new DraftPlan
                        {
                            DraftProjectId = pr_entity.DraftProjectId,  //foreign
                            DraftProjectName = pr_entity.DraftProjectName,  //同步寫入
                            DraftProjectPlanId = item.ProjectPlanId,
                            DraftPlanPrice = item.PlanPrice,
                            DraftPlanTitle = item.PlanTitle,
                            DraftQuantityLimit = item.QuantityLimit,
                            DraftPlanDescription = item.PlanDescription,
                            DraftPlanImgUrl = item.PlanImgUrl,
                            DraftPlanShipDate = DateTime.ParseExact(item.PlanShipDate, "yyyyMMdd", null),
                            DraftAddCarCarPlan = item.AddCarCarPlan,
                        };
                        _repository.Create(pl_entity);
                        result.IsSuccessful = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
                //transaction.Rollback();
            }
            //}
            return result;
        }



        public OperationResult UpDateDraftData(SubmissionProcessViewModel input, int Id)
        {
            OperationResult result = new OperationResult();
            var member = _repository.GetAll<Member>().Where((x) => x.MemberId == Id).FirstOrDefault();
            var draftProject = _repository.GetAll<DraftProject>().Where((x) => x.DraftProjectId == input.DraftProjectId).FirstOrDefault();
            result.Status = member.MemberId;
            //using (var transaction = _context.Database.BeginTransaction())
            //{
            try
            {
                member.MemberConEmail = input.MemberConEmail;
                member.MemberPhone = input.MemberPhone;
                member.ProfileImgUrl = input.ProfileImgUrl;
                member.AboutMe = input.AboutMe;
                member.MemberWebsite = input.MemberWebsite;
                member.MemberName = input.CreatorName;   //可以同步更動改會員名

                _repository.Update(member);
                result.IsSuccessful = true;

                draftProject.MemberId = member.MemberId; //foreign
                draftProject.DraftProjectName = input.ProjectName;
                draftProject.AmountThreshold = input.AmountThreshold;
                draftProject.Category = input.Category;
                draftProject.StartDate = DateTime.ParseExact(input.StartDate, "yyyyMMdd", null);
                draftProject.EndDate = DateTime.ParseExact(input.EndDate, "yyyyMMdd", null);
                draftProject.DraftProjectVideoUrl = input.ProjectVideoUrl;
                draftProject.DraftProjectMainUrl = input.ProjectMainUrl;
                draftProject.DraftProjectCoverUrl = input.ProjectCoverUrl;
                draftProject.DraftProjectPrincipal = input.ProjectPrincipal;
                draftProject.IdentityNumber = input.IdentityNumber;
                draftProject.CreatorName = input.CreatorName;
                draftProject.DraftProjectImgUrl = input.ProjectImgUrl;
                draftProject.DraftProject_Question = input.Project_Question;
                draftProject.DraftProject_Answer = input.Project_Answer;
                draftProject.DraftProjectPlansCount = input.DraftProjectPlansCount;
                //draftProject.ProjectStatus = "審核中";
                draftProject.DraftCreatedDate = input.CreatedDate;
                draftProject.DraftSubmittedDate = input.SubmittedDate;
                draftProject.DraftLastEditTime = input.LastEditTime;
                
                _repository.Update(draftProject);
                result.IsSuccessful = true;

                if (input.PlanObject != null)
                {
                    //刪掉原本的
                    var draftPlanObj = _repository.GetAll<DraftPlan>().Where((x) => x.DraftProjectId == draftProject.DraftProjectId).ToList();
                    //var draftPlanObj2 = _prcontext.DraftPlans.Where((x) => x.DraftProjectId == draftProject.DraftProjectId);
                    foreach (var item in draftPlanObj)
                    {
                        _repository.Delete(item);
                    }
                       
                    //重新加新的plan
                    List<SubmissionProcessPlanViewModel> planObj = input.PlanObject;
                    foreach (var item in planObj)
                    {
                        DraftPlan pl_entity = new DraftPlan
                        {
                            DraftProjectId = draftProject.DraftProjectId,  //foreign
                            DraftProjectName = draftProject.DraftProjectName,  //同步寫入
                            DraftProjectPlanId = item.ProjectPlanId,
                            DraftPlanPrice = item.PlanPrice,
                            DraftPlanTitle = item.PlanTitle,
                            DraftQuantityLimit = item.QuantityLimit,
                            DraftPlanDescription = item.PlanDescription,
                            DraftPlanImgUrl = item.PlanImgUrl,
                            DraftPlanShipDate = DateTime.ParseExact(item.PlanShipDate, "yyyyMMdd", null),
                            DraftAddCarCarPlan = item.AddCarCarPlan,
                        };
                        _repository.Create(pl_entity);
                        result.IsSuccessful = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
                //transaction.Rollback();
            }
            //}
            return result;
        }




        public int ReturnLoginnerId()
        {
            var session = HttpContext.Current.Session;
            if (session["Member"] == null)
            {
                return 0;
            }
            return ((MemberViewModel)session["Member"]).MemberId;
        }


    }
}