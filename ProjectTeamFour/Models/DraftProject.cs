using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class DraftProject
    {

        public int DraftProjectId { get; set; }
        public string DraftProjectName { get; set; }
        public decimal DraftAmountThreshold { get; set; }
        public string DraftCategory { get; set; }
        public DateTime DraftStartDate { get; set; }
        public DateTime DraftEndDate { get; set; }
        public string DraftProjectVideoUrl { get; set; }
        public string DraftProjectMainUrl { get; set; }
        public string DraftProjectCoverUrl { get; set; }
        public string DraftMemberConEmail { get; set; }
        public string DraftMemberPhone { get; set; }
        public string DraftProfileImgUrl { get; set; }
        public string DraftCreatorName { get; set; }
        public string DraftAboutMe { get; set; }
        public string DraftMemberWebsite { get; set; }
        public string DraftProjectImgUrl { get; set; }
        public string DraftProjectPrincipal { get; set; }
        public string DraftIdentityNumber { get; set; }
        public string DraftProject_Question { get; set; }
        public string DraftProject_Answer { get; set; }
        public DateTime DraftCreatedDate { get; set; }
        public DateTime DraftSubmittedDate { get; set; }
        public DateTime DraftLastEditTime { get; set; }
        public decimal DraftFundingAmount { get; set; }
        public int DraftFundedpeople { get; set; }
        public List<DraftPlan> DraftPlanObject { get; set; }
        public int ApprovingStatus { get; set; }
        public string ProjectStatus { get; set; }



    }
}