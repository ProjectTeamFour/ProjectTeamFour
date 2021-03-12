using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Project
    {
        public int ProjectId { get; set; } 
        public string ProjectName { get; set; } 
        public decimal FundingAmount { get; set; }
        public string Category { get; set; }
        public string ProjectStatus { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public double dateLine { get; set; }
        public int MemberId { get; set; }
        public int Fundedpeople { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImgUrl { get; set; }
        public string ProjectVideoUrl { get; set; }
        public string Project_Question { get; set; }
        public string Project_Answer { get; set; }

        
        //可以動態取得看是否拿掉plan.Count(p=>p.projectid==?)......................... 
        public int ProjectPlansCount { get; set; }
        public string ProjectCoverUrl { get; set; }
        public decimal AmountThreshold { get; set; }
        public string CreatorName { get; set; }
        public string ProjectMainUrl { get; set; }
        public string ProjectPrincipal { get; set; }
        public string IdentityNumber { get; set; }
        //導覽屬性
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime SubmittedDate { get; set; }
        public DateTime LastEditTime { get; set; }
        public int ApprovingStatus { get; set; }
        //未審核:0;審核中:1;審核通過:2
    }
}