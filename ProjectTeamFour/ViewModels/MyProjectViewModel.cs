using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Controllers
{
    public class MyProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal FundingAmount { get; set; }
        public string Category { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //可能還需要加到資料庫
        public DateTime CreateDate { get; set; }
        //可能還需要加到資料庫
        public DateTime LastEditDate { get; set; }

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

    }
}