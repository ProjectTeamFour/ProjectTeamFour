using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels.ForMemberView
{
    public class SubmissionProcessPlanViewModel
    {
        public int PlanId { get; set; }
        public int ProjectPlanId { get; set; }
        public bool AddCarCarPlan { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string PlanTitle { get; set; }
        public int PlanFundedPeople { get; set; }
        public string PlanShipDate { get; set; }
        public string PlanDescription { get; set; }
        public string PlanImgUrl { get; set; }
        public decimal PlanPrice { get; set; }
        public int QuantityLimit { get; set; }
        public int SubmitLimit { get; set; }
       
    }
}