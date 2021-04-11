using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Project
    {
        public Project()
        {
            Comments = new HashSet<Comment>();
            Plans = new HashSet<Plan>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal FundingAmount { get; set; }
        public string Category { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MemberId { get; set; }
        public int Fundedpeople { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImgUrl { get; set; }
        public string ProjectVideoUrl { get; set; }
        public string ProjectQuestion { get; set; }
        public string ProjectAnswer { get; set; }
        public int ProjectPlansCount { get; set; }
        public string ProjectCoverUrl { get; set; }
        public decimal AmountThreshold { get; set; }
        public string CreatorName { get; set; }
        public string ProjectMainUrl { get; set; }
        public string ProjectPrincipal { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime LastEditTime { get; set; }
        public int ApprovingStatus { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
