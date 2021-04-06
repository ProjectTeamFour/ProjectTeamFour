using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository _dbRepository;
        private readonly LabContext _labContext;

        public ProjectService(IRepository repository, LabContext labcontext)
        {
            _dbRepository = repository;
            _labContext = labcontext;
        }

        //取得全部
        public ProjectViewModel.ProjectListResult GetAll()
        {
            ProjectViewModel.ProjectListResult result = new ProjectViewModel.ProjectListResult();
            result.ProjectList = _dbRepository
                .GetAll<Project>()
                .Select(p => new ProjectViewModel.ProjectSingleResult()
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.ProjectName,
                    FundingAmount = p.FundingAmount,
                    Category = p.Category,
                    ProjectStatus = p.ProjectStatus,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    MemberId = p.MemberId,
                    Fundedpeople = p.Fundedpeople,
                    ProjectDescription = p.ProjectDescription,
                    ProjectVideoUrl = p.ProjectVideoUrl,
                    ProjectQuestion = p.ProjectQuestion,
                    ProjectAnswer = p.ProjectAnswer,
                    ProjectPlansCount = p.ProjectPlansCount,
                    ProjectCoverUrl = p.ProjectCoverUrl,
                    ProjectImgUrl = p.ProjectImgUrl,
                    AmountThreshold = p.AmountThreshold,
                    CreatorName = p.CreatorName,
                    ProjectMainUrl = p.ProjectMainUrl,
                    ProjectPrincipal = p.ProjectPrincipal,
                    IdentityNumber = p.IdentityNumber,
                    CreatedDate = p.CreatedDate,
                    SubmittedDate = p.SubmittedDate,
                    LastEditTime = p.LastEditTime,
                    ApprovingStatus = p.ApprovingStatus,

                    PlanList = _dbRepository
                    .GetAll<Plan>()
                    .Where(pl => pl.ProjectId == p.ProjectId)
                    .Select(pl => new Plan
                    {
                        PlanId = pl.PlanId,
                        ProjectPlanId = pl.ProjectPlanId,
                        ProjectId = pl.ProjectId,
                        PlanTitle = pl.PlanTitle,
                        PlanFundedPeople = pl.PlanFundedPeople,
                        PlanShipDate = pl.PlanShipDate,
                        PlanDescription = pl.PlanDescription,
                        PlanImgUrl = pl.PlanImgUrl,
                        QuantityLimit = pl.QuantityLimit,
                        ProjectName = pl.ProjectName,
                        PlanPrice = pl.PlanPrice,
                        AddCarCarPlan = pl.AddCarCarPlan,

                    }).ToList(),

                    CommentList = _dbRepository
                        .GetAll<Comment>()
                        .Where(c => c.ProjectId == p.ProjectId)
                        .Select(c => new Comment
                        {
                            CommentId = c.CommentId,
                            ProjectId = c.ProjectId,
                            MemberId = c.MemberId,
                            CommentQuestion = c.CommentQuestion,
                            CommentTime = c.CommentTime,
                            CommentAnswer = c.CommentAnswer,
                            ReadStatus = c.ReadStatus,
                            AskedMemberId = c.AskedMemberId

                        }).ToList(),


                }).ToList();

            return result;
        }


        //取得審核中

        public ProjectViewModel.ProjectListResult GetWaitForPass()
        {
            ProjectViewModel.ProjectListResult result = new ProjectViewModel.ProjectListResult();
            result.ProjectList = _dbRepository
                .GetAll<Project>()
                .Where(x => x.ProjectStatus == "審核中")
                .Select(p => new ProjectViewModel.ProjectSingleResult()
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.ProjectName,
                    FundingAmount = p.FundingAmount,
                    Category = p.Category,
                    ProjectStatus = p.ProjectStatus,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    MemberId = p.MemberId,
                    Fundedpeople = p.Fundedpeople,
                    ProjectDescription = p.ProjectDescription,
                    ProjectVideoUrl = p.ProjectVideoUrl,
                    ProjectQuestion = p.ProjectQuestion,
                    ProjectAnswer = p.ProjectAnswer,
                    ProjectPlansCount = p.ProjectPlansCount,
                    ProjectCoverUrl = p.ProjectCoverUrl,
                    ProjectImgUrl = p.ProjectImgUrl,
                    AmountThreshold = p.AmountThreshold,
                    CreatorName = p.CreatorName,
                    ProjectMainUrl = p.ProjectMainUrl,
                    ProjectPrincipal = p.ProjectPrincipal,
                    IdentityNumber = p.IdentityNumber,
                    CreatedDate = p.CreatedDate,
                    SubmittedDate = p.SubmittedDate,
                    LastEditTime = p.LastEditTime,
                    ApprovingStatus = p.ApprovingStatus,

                    PlanList = _dbRepository
                    .GetAll<Plan>()
                    .Where(pl => pl.ProjectId == p.ProjectId)
                    .Select(pl => new Plan
                    {
                        PlanId = pl.PlanId,
                        ProjectPlanId = pl.ProjectPlanId,
                        ProjectId = pl.ProjectId,
                        PlanTitle = pl.PlanTitle,
                        PlanFundedPeople = pl.PlanFundedPeople,
                        PlanShipDate = pl.PlanShipDate,
                        PlanDescription = pl.PlanDescription,
                        PlanImgUrl = pl.PlanImgUrl,
                        QuantityLimit = pl.QuantityLimit,
                        ProjectName = pl.ProjectName,
                        PlanPrice = pl.PlanPrice,
                        AddCarCarPlan = pl.AddCarCarPlan,

                    }).ToList(),

                    CommentList = _dbRepository
                        .GetAll<Comment>()
                        .Where(c => c.ProjectId == p.ProjectId)
                        .Select(c => new Comment
                        {
                            CommentId = c.CommentId,
                            ProjectId = c.ProjectId,
                            MemberId = c.MemberId,
                            CommentQuestion = c.CommentQuestion,
                            CommentTime = c.CommentTime,
                            CommentAnswer = c.CommentAnswer,
                            ReadStatus = c.ReadStatus,
                            AskedMemberId = c.AskedMemberId

                        }).ToList(),
                }).ToList();

            return result;
        }



        /// <summary>
        /// 將前端修改後的資料以交易方式，變更資料庫資料。回傳為字串形式:"查無此筆資料"、"修改成功"、Exception.Message
        /// </summary>
        /// <param name="waitForPassProject"></param>
        public string EditWaitForPassProject(ProjectViewModel.ProjectSingleResult waitForPassProject)
        {
            var querySingleResult = _dbRepository.GetAll<Project>().FirstOrDefault(x => x.ProjectId == waitForPassProject.ProjectId);
            if (querySingleResult == default)
            {
                return "查無此筆資料";
            }

            querySingleResult.ProjectStatus = "集資中";
            querySingleResult.ApprovingStatus = 2;

            using (var transaction = _labContext.Database.BeginTransaction())
            {
                try
                {
                    _dbRepository.Update<Project>(querySingleResult);
                    transaction.Commit();
                    return "修改成功";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return ex.Message;
                }
            }


        }






        public ProjectViewModel.ProjectListResult GetByCategory(ProjectViewModel.GetByCategoryRequest request)
        {
            ProjectViewModel.ProjectListResult result = new ProjectViewModel.ProjectListResult();

            result.ProjectList = _dbRepository.GetAll<Project>()
                .Where(x => x.Category == request.Category)
                .Select(x => new ProjectViewModel.ProjectSingleResult()
                {
                    ProjectId = x.ProjectId,
                    ProjectName = x.ProjectName,
                    ProjectMainUrl = x.ProjectMainUrl,
                    Category = x.Category,
                    ProjectStatus = x.ProjectStatus,
                    CreatorName = x.CreatorName,
                    FundingAmount = x.FundingAmount,
                    AmountThreshold = x.AmountThreshold,
                    EndDate = x.EndDate,
                    StartDate = x.StartDate,
                    Fundedpeople = x.Fundedpeople,
                }).ToList();

            return result;
        }

        public ProjectViewModel.ProjectSingleResult GetById(ProjectViewModel.GetByIdRequest request)
        {
            var data = _dbRepository.GetAll<Project>()
                .FirstOrDefault(x => x.ProjectId == request.ProjectId);

            var result = new ProjectViewModel.ProjectSingleResult()
            {
                ProjectId = data.ProjectId,
                ProjectName = data.ProjectName,
                ProjectMainUrl = data.ProjectMainUrl,
                Category = data.Category,
                ProjectStatus = data.ProjectStatus,
                CreatorName = data.CreatorName,
                FundingAmount = data.FundingAmount,
                AmountThreshold = data.AmountThreshold,
                EndDate = data.EndDate,
                StartDate = data.StartDate,
                Fundedpeople = data.Fundedpeople,
            };

            return result;
        }

        public ProjectViewModel.ProjectListResult GetTotalSale()
        {
            return null;
        }
    }
}
