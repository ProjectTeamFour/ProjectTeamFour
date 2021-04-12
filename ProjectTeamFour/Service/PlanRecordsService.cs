using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.ViewModels.ForMemberView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectTeamFour.Repositories;
using System.Data.Entity;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.Service
{
    public class PlanRecordsService
    {
        private readonly DbContext _context;
        private readonly BaseRepository _repository;
        public PlanRecordsService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }
        public IEnumerable<Permission> GetPermissions()
        {     
            return _repository.GetAll<Permission>();
        }
        public CheckPermissionViewModel CheckPermission(int memberId, int permissionId)
        {
            int mem_per = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == memberId).Permission;
            string mem_perString = Convert.ToString(mem_per, 2);
            int per_value = _repository.GetAll<Permission>().FirstOrDefault(m => m.PermissionId == permissionId).PermissionValue;
            string per_valueString = Convert.ToString(per_value, 2);
            CheckPermissionViewModel cv = new CheckPermissionViewModel()
            {
                MemberId = memberId,
                PermissionId = permissionId,
                Checked = false,
                PermissionValue = mem_per
            };
            return cv;
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