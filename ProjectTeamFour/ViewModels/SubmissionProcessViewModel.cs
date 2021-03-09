using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.ViewModels
{
    public class SubmissionProcessViewModel
    {
        public string ProjectName { get; set; }
        public decimal AmountThreshold { get; set; }
        public string Category { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ProjectVideoUrl { get; set; }
        public string ProjectMainUrl { get; set; }
        public string ProjectCoverUrl { get; set; }

        //ProjectPrincipal
        public string MemberConEmail { get; set; }
        public string MemberPhone { get; set; }

        //IdentityNumber
        public string ProfileImgUrl { get; set; }
        public string CreatorName { get; set; }
        public string AboutMe { get; set; }
        public string MemberWebsite { get; set; }
        public string ProjectImgUrl { get; set; }


        //public string Project_Question { get; set; }
        //public string Project_Answer { get; set; }


        //public int ProjectPlanId { get; set; }
        //public decimal PlanPrice { get; set; }
        //public string PlanTitle { get; set; }
        //public int QuantityLimit { get; set; }
        //public string PlanDescription { get; set; }
        //public string PlanImgUrl { get; set; }
        //public DateTime PlanShipDate { get; set; }


        //AddCarCarPlan


        public List<Project> ProjectQA { get; set; }
        public List<Plan> PlanObject { get; set; }








    }
}