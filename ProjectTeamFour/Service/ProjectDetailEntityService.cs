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
    public class ProjectDetailEntityService: IProjectDetailService
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
                
                ProjectDetailItem = new ProjectDetailViewModel(),

                SelectPlanCards = new SelectPlanListViewModel()
                {
                    PlanCardItems = GetPlanCards(projectId)
                }
            };

            return projectTotalVM;
        }



        public ProjectDetailViewModel GetProjectDetail(int projectId)
        {
            return GetProjectDetailFromEntity(x => x.ProjectId == projectId);
        }

        private ProjectDetailViewModel GetProjectDetailFromEntity(Expression<Func<Project, bool>> ProjectId)
        {
            var entity = _repository.GetAll<Project>().FirstOrDefault(ProjectId);
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


        public List<ProjectFAQViewModel> ConvertProjectFAQList(string strQuestion , string strAnswer)
        {
            List<ProjectFAQViewModel> ProjectFAQ = new List<ProjectFAQViewModel>();

            string[] questionsArray = strQuestion.Split(',');
            string[] answerArray = strAnswer.Split(',');
            int len_of_faq = questionsArray.Length;

            for (int i = 0; i < len_of_faq ; i++)
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

    }
}