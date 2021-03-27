using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class DraftProject
    {
        public DraftProject()
        {
            DraftPlans = new HashSet<DraftPlan>();
        }

        public int DraftProjectId { get; set; }
        public string DraftProjectName { get; set; }
        public int MemberId { get; set; }
        public string DraftProjectImgUrl { get; set; }
        public string DraftProjectVideoUrl { get; set; }
        public string DraftProjectQuestion { get; set; }
        public string DraftProjectAnswer { get; set; }
        public string DraftProjectCoverUrl { get; set; }
        public string DraftProjectMainUrl { get; set; }
        public string DraftProjectPrincipal { get; set; }
        public decimal? FundingAmount { get; set; }
        public string Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Fundedpeople { get; set; }
        public string DraftProjectDescription { get; set; }
        public int? DraftProjectPlansCount { get; set; }
        public decimal? AmountThreshold { get; set; }
        public string CreatorName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? DraftCreatedDate { get; set; }
        public DateTime? DraftSubmittedDate { get; set; }
        public DateTime? DraftLastEditTime { get; set; }
        public decimal? DraftFundingAmount { get; set; }
        public int? DraftFundedpeople { get; set; }
        public int? ApprovingStatus { get; set; }
        public string ProjectStatus { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<DraftPlan> DraftPlans { get; set; }
    }
}
