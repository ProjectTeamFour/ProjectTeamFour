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
        public int? MemberMemberId { get; set; }
        public string DraftProjectImgUrl { get; set; }
        public string DraftProjectVideoUrl { get; set; }
        public string DraftProjectQuestion { get; set; }
        public string DraftProjectAnswer { get; set; }
        public string DraftProjectCoverUrl { get; set; }
        public string DraftProjectMainUrl { get; set; }
        public string DraftProjectPrincipal { get; set; }
        public decimal? DraftAmountThreshold { get; set; }
        public string DraftCategory { get; set; }
        public DateTime? DraftStartDate { get; set; }
        public DateTime? DraftEndDate { get; set; }
        public string DraftMemberConEmail { get; set; }
        public string DraftMemberPhone { get; set; }
        public string DraftProfileImgUrl { get; set; }
        public string DraftCreatorName { get; set; }
        public string DraftAboutMe { get; set; }
        public string DraftMemberWebsite { get; set; }
        public string DraftIdentityNumber { get; set; }
        public DateTime? DraftCreatedDate { get; set; }
        public DateTime? DraftSubmittedDate { get; set; }
        public DateTime? DraftLastEditTime { get; set; }
        public decimal? DraftFundingAmount { get; set; }
        public int? DraftFundedpeople { get; set; }
        public int? ApprovingStatus { get; set; }
        public string ProjectStatus { get; set; }

        public virtual Member MemberMember { get; set; }
        public virtual ICollection<DraftPlan> DraftPlans { get; set; }
    }
}
