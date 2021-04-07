using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels.ForMemberView;

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

        public string MemberConEmail { get; set; }
        public string MemberPhone { get; set; }
        public string ProfileImgUrl { get; set; }
        public string CreatorName { get; set; }
        public string AboutMe { get; set; }
        public string MemberWebsite { get; set; }
        public string ProjectImgUrl { get; set; }

        public string ProjectPrincipal { get; set; }

        public string IdentityNumber { get; set; }


        public string Project_Question { get; set; }
        public string Project_Answer { get; set; }


        public DateTime CreatedDate { get; set; }

        public DateTime SubmittedDate { get; set; }
        public DateTime LastEditTime { get; set; }

        public decimal FundingAmount { get; set; }

        public int Fundedpeople { get; set; }

        public int DraftProjectPlansCount { get; set; }


        public List<SubmissionProcessPlanViewModel> PlanObject { get; set; }

        



    }
}