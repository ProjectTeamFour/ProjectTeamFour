using ProjectTeamFour_Backend.Context;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProjectTeamFour_Backend.ViewModels.CarCarPlanViewModel;

namespace ProjectTeamFour_Backend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository _dbRepository;
        private readonly CarCarPlanContext _labContext;

        public ProjectService(IRepository repository, CarCarPlanContext labcontext)
        {
            _dbRepository = repository;
            _labContext = labcontext;
        }

        //取得全部
        public Task<ProjectViewModel.ProjectListResult> GetAll()
        {
            return Task.Run(() =>
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
                        StartDate = p.StartDate.ToString("d"),
                        EndDate = p.EndDate.ToString("d"),
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
                        CreatedDate = p.CreatedDate.ToString("d"),
                        SubmittedDate = p.SubmittedDate.ToString("d"),
                        LastEditTime = p.LastEditTime.ToString("d"),
                        ApprovingStatus = p.ApprovingStatus,
                        RestDay = p.EndDate.Subtract(p.StartDate).Days,
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
            });
           
        }

        public ProjectViewModel.ProjectListForPercent GetPercent()
        {
            var result = new ProjectViewModel.ProjectListForPercent();
            result.getProjectPercentsList = _dbRepository.GetAll<Project>().Select(x => new ProjectViewModel.GetProjectPercent
            {
                ProjectPercent = (x.FundingAmount/x.AmountThreshold)*100
            }).ToList();

            return result;
        }

        //取得審核中

        public Task<ProjectViewModel.ProjectListResult> GetWaitForPass()
        {
            return Task.Run(() =>
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
                        StartDate = p.StartDate.ToString("d"),
                        EndDate = p.EndDate.ToString("d"),
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
                        CreatedDate = p.CreatedDate.ToString("d"),
                        SubmittedDate = p.SubmittedDate.ToString("d"),
                        LastEditTime = p.LastEditTime.ToString("d"),
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
            });
          
        }



        /// <summary>
        /// 將前端修改後的資料以交易方式，變更資料庫資料。回傳為字串形式:"查無此筆資料"、"修改成功"、Exception.Message
        /// </summary>
        /// <param name="waitForPassProject"></param>
        public Task<string> EditWaitForPassProject(ProjectViewModel.ProjectSingleResult waitForPassProject)
        {
            return Task.Run(() =>
            {
                var querySingleResult = _dbRepository.GetAll<Project>().FirstOrDefault(x => x.ProjectId == waitForPassProject.ProjectId);
                if (querySingleResult == default)
                {
                    return "查無此筆資料";
                }
                if (waitForPassProject.ApprovingStatus == 2)
                {
                    querySingleResult.ProjectStatus = "集資中";
                    querySingleResult.ApprovingStatus = 2;
                }
                else
                {
                    querySingleResult.ProjectStatus = null;
                    querySingleResult.ApprovingStatus = 3;
                }

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

            });
           

        }






        public Task<ProjectViewModel.ProjectListResult> GetByCategory(ProjectViewModel.GetByCategoryRequest request)
        {
            return Task.Run(() => {
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
                        EndDate = x.EndDate.ToString("d"),
                        StartDate = x.StartDate.ToString("d"),
                        Fundedpeople = x.Fundedpeople,
                    }).ToList();

                return result;

            });
          
        }

        public Task<ProjectViewModel.ProjectSingleResult> GetById(ProjectViewModel.GetByIdRequest request)
        {
            return Task.Run(() =>
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
                    EndDate = data.EndDate.ToString("d"),
                    StartDate = data.StartDate.ToString("d"),
                    Fundedpeople = data.Fundedpeople,
                };

                return result;
            });
          
        }

        public Task<ProjectViewModel.ProjectListResult> GetTotalSale()
        {
            return (Task<ProjectViewModel.ProjectListResult>)Task.Run(() =>
            {
                return null;
            });
            
        }

        //取得Charts會用到的資料
        public Task<ProjectViewModel.ProjectListforChart> GetAllForCharts()
        {
            return Task.Run(() =>
            {
                ProjectViewModel.ProjectListforChart result = new ProjectViewModel.ProjectListforChart();
                result.ProjectChartdta = _dbRepository
                    .GetAll<Project>()
                    .Select(p => new ProjectViewModel.ProjectforChart()
                    {
                        ProjectId = p.ProjectId,
                        ProjectName = p.ProjectName,
                        FundingAmount = p.FundingAmount,
                        Category = p.Category,
                        ProjectStatus = p.ProjectStatus
                    }).ToList();

                return result;
            });
           
        }


        public ProjectViewModel.ProjectSingleResult GetProjectById(int ProjectId)
        {
                var entity = _dbRepository.GetAll<Project>().FirstOrDefault(x => x.ProjectId == ProjectId);
                var result = new ProjectViewModel.ProjectSingleResult
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
                    ProjectFAQList = ConvertProjectFAQList(entity.ProjectQuestion, entity.ProjectAnswer),
                    //Project_Question = entity.Project_Question,
                    //Project_Answer = entity.Project_Answer​,
                    DateTimeEndDate = entity.EndDate,
                    DateTimeStartDate = entity.StartDate,
                    ProjectMainUrl = entity.ProjectMainUrl,
                    ProjectId = entity.ProjectId,
                    MemberId = entity.MemberId
                };
                return result;
        }

        public List<ProjectFAQViewModel> ConvertProjectFAQList(string strQuestion, string strAnswer)
        {
            List<ProjectFAQViewModel> ProjectFAQ = new List<ProjectFAQViewModel>();

            string[] questionsArray = strQuestion.Split(',');
            string[] answerArray = strAnswer.Split(',');
            int len_of_faq = questionsArray.Length;

            for (int i = 0; i < len_of_faq; i++)
            {
                ProjectFAQ.Add(
                    new ProjectFAQViewModel()
                    {
                        ProjectQuestion = questionsArray[i],
                        ProjectAnswer = answerArray[i]
                    }
                );
            }
            return ProjectFAQ;
        }


        public MemberViewModel.MemberSingleResult GetCreatorInfo(int MemberId)
        {

            var entity = _dbRepository.GetAll<Member>().Where(x => x.MemberId == MemberId).FirstOrDefault();
            var memberVM = new MemberViewModel.MemberSingleResult()
            {
                ProfileImgUrl = entity.ProfileImgUrl,
                MemberTeamName = entity.MemberTeamName,
                MemberName = entity.MemberName,
                AboutMe = entity.AboutMe,
                MemberWebsite = entity.MemberWebsite,
                MemberId = entity.MemberId,
                MemberConEmail = entity.MemberConEmail,
                MemberPhone = entity.MemberPhone,
            };

            return memberVM;
        }


        public List<SelectPlanViewModel> GetPlanCards(int ProjectId)
        {

            List<SelectPlanViewModel> selectPlanCardItems = new List<SelectPlanViewModel>();

            var planCardModelItems = _dbRepository.GetAll<Plan>().Where(x => x.ProjectId == ProjectId);
            foreach (var item in planCardModelItems)
            {
                var selectPlanCardViewModel = new SelectPlanViewModel()
                {
                    ProjectId = item.ProjectId,
                    PlanId = item.PlanId,
                    ProjectPlanId = item.ProjectPlanId,
                    PlanTitle = item.PlanTitle,
                    PlanDescription = item.PlanDescription,
                    PlanFundedPeople = item.PlanFundedPeople,
                    PlanShipDate = item.PlanShipDate,
                    PlanImgUrl = item.PlanImgUrl,
                    PlanPrice = item.PlanPrice,
                    QuantityLimit = item.QuantityLimit
                };
                selectPlanCardItems.Add(selectPlanCardViewModel);
            }

            return selectPlanCardItems;
        }


    }
}
