using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.ViewModels.ForMemberView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class PlanRecordsService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public PlanRecordsService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        public List<SubmissionProcessPlanViewModel> QueryResult(List<MyProjectViewModel> myProjectsVM)
        {

            List<SubmissionProcessPlanViewModel> submissionProcessPlanVM = new List<SubmissionProcessPlanViewModel>();
            var queryResults = new List<Plan>();
            foreach (var myProject in myProjectsVM)
            {
                queryResults = _repository.GetAll<Plan>().Where(p => p.ProjectId == myProject.ProjectId&&p.AddCarCarPlan==true).Select(x => x).ToList();
                if (queryResults != null)
                {
                    foreach (var queryResult in queryResults)
                    {
                        SubmissionProcessPlanViewModel singleVM = new SubmissionProcessPlanViewModel
                        {
                            PlanDescription = queryResult.PlanDescription,
                            AddCarCarPlan = queryResult.AddCarCarPlan,
                            QuantityLimit = queryResult.QuantityLimit,
                            SubmitLimit = queryResult.SubmitLimit.HasValue? queryResult.SubmitLimit.Value:0,
                            PlanFundedPeople = queryResult.PlanFundedPeople,
                            PlanId = queryResult.PlanId,
                            PlanImgUrl = queryResult.PlanImgUrl,
                            PlanPrice = queryResult.PlanPrice,
                            PlanShipDate = queryResult.PlanShipDate.ToString("d"),
                            PlanTitle = queryResult.PlanTitle,
                            ProjectId = queryResult.ProjectId,
                            ProjectName = queryResult.ProjectName,
                            ProjectPlanId = queryResult.ProjectPlanId
                        };
                        submissionProcessPlanVM.Add(singleVM);
                    }
                    
                }
                
               
            }

            return submissionProcessPlanVM;





        }
    }
}