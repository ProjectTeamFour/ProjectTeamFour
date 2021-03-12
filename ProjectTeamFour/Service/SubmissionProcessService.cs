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

        public OperationResult ReceiveSubmissionData(SubmissionProcessViewModel input, int Id)
        {
            var result = new OperationResult();

            var member = _repository.GetAll<Member>().Where((x) => x.MemberId == Id).FirstOrDefault();


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

        public int ReturnLoginnerId()
        {
            var session = HttpContext.Current.Session;
            if (session["Member"] == null)
            {
                return 0;
            }
            return ((MemberViewModel)session["Member"]).MemberId;
        }


        //public MemberViewModel GetMember(Expression<Func<Member, bool>> KeySelector)
        //{
        //    var entity = _repository.GetAll<Member>().FirstOrDefault(KeySelector);
        //    if (entity != null)
        //    {
        //        var viewModel = new MemberViewModel
        //        {
        //            MemberId = entity.MemberId,
        //            MemberName = entity.MemberName,
        //            MemberTeamName = entity.MemberTeamName,
        //            MemberAccount = entity.MemberAccount,
        //            MemberPassword = entity.MemberPassword,
        //            MemberAddress = entity.MemberAddress,
        //            MemberPhone = entity.MemberPhone,
        //            MemberRegEmail = entity.MemberRegEmail,
        //            MemberConEmail = entity.MemberConEmail,
        //            Gender = entity.Gender,
        //            MemberBirth = entity.MemberBirth,
        //            AboutMe = entity.AboutMe,
        //            ProfileImgUrl = entity.ProfileImgUrl,
        //            MemberWebsite = entity.MemberWebsite,
        //            MemberMessage = entity.MemberMessage,
        //            Permission = entity.Permission
        //        };
        //        return viewModel;
        //    }
        //    return null;
        //}


    }
}