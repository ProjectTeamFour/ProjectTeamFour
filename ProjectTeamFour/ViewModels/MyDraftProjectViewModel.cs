using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class MyDraftProjectViewModel
    {

       
        public int DraftProjectId { get; set; }
       
        public string DraftProjectName { get; set; }
       
        public decimal FundingAmount { get; set; }
       
        public string Category { get; set; }
       
        public DateTime StartDate { get; set; }
       
        public DateTime EndDate { get; set; }
        public string StringStartDate { get; set; }
        public string StringEndDate { get; set; }

        public int MemberId { get; set; }
       
        public int Fundedpeople { get; set; }
       
        public string DraftProjectDescription { get; set; }
      
        public string DraftProjectImgUrl { get; set; }
       
        public string DraftProjectVideoUrl { get; set; }
      
        public string DraftProject_Question { get; set; }
        
        public string DraftProject_Answer { get; set; }
        public DateTime DraftCreatedDate { get; set; }
        public DateTime DraftSubmittedDate { get; set; }
        public DateTime DraftLastEditTime { get; set; }
        public decimal DraftFundingAmount { get; set; }
        public int DraftFundedpeople { get; set; }

        public int ApprovingStatus { get; set; }
        public string ProjectStatus { get; set; }
       
        public int DraftProjectPlansCount { get; set; }
      
        public string DraftProjectCoverUrl { get; set; }
       
        public decimal AmountThreshold { get; set; }
      
        public string CreatorName { get; set; }
       
        public string DraftProjectMainUrl { get; set; }
       
        public string DraftProjectPrincipal { get; set; }
      
        public string IdentityNumber { get; set; }

        public List<DraftProjectFAQViewModel> DraftProjectFAQList { get; set; }
    }
}