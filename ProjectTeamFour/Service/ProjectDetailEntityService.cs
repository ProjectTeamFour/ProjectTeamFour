using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace ProjectTeamFour.Service
{
    public class ProjectDetailEntityService : IProjectDetailService
    {
        public DbContext _context;
        private BaseRepository _repository;
        public ProjectDetailEntityService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        public ProjectTotalViewModel GetPageViewModel(int projectId)
        {
            ProjectTotalViewModel projectTotalVM = new ProjectTotalViewModel
            {
                CreatorInfo = new MemberViewModel(),

                ProjectDetailItem = new ProjectDetailViewModel(),

                SelectPlanCards = new SelectPlanListViewModel()
                {
                    PlanCardItems = GetPlanCards(projectId)
                }
            };

            return projectTotalVM;
        }

        public MemberViewModel GetCreatorInfo(Expression<Func<Member, bool>> KeySelector)
        {

            var entity = _repository.GetAll<Member>().FirstOrDefault(KeySelector);
            var memberVM = new MemberViewModel()
            {
                ProfileImgUrl = entity.ProfileImgUrl,
                MemberTeamName = entity.MemberTeamName,
                MemberName = entity.MemberName,
                AboutMe = entity.AboutMe,
                MemberWebsite = entity.MemberWebsite,
                MemberId = entity.MemberId
            };

            return memberVM;
        }

        public ProjectDetailViewModel GetProjectDetail(int projectId)
        {
            return GetProjectDetailFromEntity(x => x.ProjectId == projectId);
        }

        private ProjectDetailViewModel GetProjectDetailFromEntity(Expression<Func<Project, bool>> ProjectId)
        {
            var entity = _repository.GetAll<Project>().FirstOrDefault(ProjectId);
            UpdateProjectStatus(entity);
            //if (entity != default(Models.Project))
            //{
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
                ProjectFAQList = ConvertProjectFAQList(entity.Project_Question, entity.Project_Answer),
                //Project_Question = entity.Project_Question,
                //Project_Answer = entity.Project_Answer​,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                ProjectMainUrl = entity.ProjectMainUrl,
                ProjectId = entity.ProjectId,
                MemberId = entity.MemberId
            };

            //}
            //else
            //{

            //}
            return projectdetailVM;
        }

        public List<SelectPlanViewModel> GetPlanCards(int projectId)
        {

            return GetPlanCards(x => x.ProjectId == projectId);

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
                        Question = questionsArray[i],
                        Answer = answerArray[i]
                    }
                );
            }
            return ProjectFAQ;
        }


        public List<SelectPlanViewModel> GetPlanCards(Expression<Func<Plan, bool>> ProjectId)
        {

            List<SelectPlanViewModel> selectPlanCardItems = new List<SelectPlanViewModel>();

            var planCardModelItems = _repository.GetAll<Plan>().Where(ProjectId);
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

        public void UpdateProjectStatus(Project item)
        {

            DateTime today = DateTime.Now;
            double dateLine = Convert.ToInt32(new TimeSpan(item.EndDate.Ticks - today.Ticks).TotalDays);

            if (dateLine <= 0 && item.FundingAmount > item.AmountThreshold)
            {
                item.ProjectStatus = "結束且成功";
            }
            else if (dateLine <= 0 && item.FundingAmount < item.AmountThreshold)
            {
                item.ProjectStatus = "結束且失敗";
            }
            else if (dateLine > 0 && item.FundingAmount > item.AmountThreshold)
            {
                item.ProjectStatus = "集資成功";
            }
            else if (dateLine > 0 && item.FundingAmount < item.AmountThreshold)
            {
                item.ProjectStatus = "集資中";
            }
            else
            {
                item.ProjectStatus = "審核中";
            }
            _repository.Update(item);
        }

    }
}