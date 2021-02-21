using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class ProjectDetailViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal FundingAmount { get; set; }
        public string Category { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public int MemberId { get; set; }
        public int Fundedpeople { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImgUrl { get; set; }
        public string ProjectVideoUrl { get; set; }

        public List<ProjectFAQViewModel> ProjectFAQList { get; set; }
  
        //可以動態取得看是否拿掉plan.Count(p=>p.projectid==?)......................... 
        public int ProjectPlansCount { get; set; }
        public string ProjectCoverUrl { get; set; }
        public decimal AmountThreshold { get; set; }
        public string CreatorName { get; set; }
        //public string ProjectMainUrl { get; set; }
        //導覽屬性
        //public virtual ICollection<Plan> Plans { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
    }
}