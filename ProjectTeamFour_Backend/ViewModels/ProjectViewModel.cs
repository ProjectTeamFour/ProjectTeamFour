using ProjectTeamFour_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class ProjectViewModel
    {
        /// <summary>
        /// 提案基底VM
        /// </summary>
        public class ProjectBaseModel
        {

            //這裡放自己要的屬性，這裡只是示意從 model 全貼過來，自己改!
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public decimal FundingAmount { get; set; }
            public string Category { get; set; }
            public string ProjectStatus { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public int MemberId { get; set; }
            public int Fundedpeople { get; set; }
            public string ProjectDescription { get; set; }
            public string ProjectVideoUrl { get; set; }
            public string ProjectQuestion { get; set; }
            public string ProjectAnswer { get; set; }
            public int ProjectPlansCount { get; set; }
            public string ProjectCoverUrl { get; set; }
            public string ProjectImgUrl { get; set; }
            public decimal AmountThreshold { get; set; }
            public string CreatorName { get; set; }
            public string ProjectMainUrl { get; set; }
            public string ProjectPrincipal { get; set; }
            public string IdentityNumber { get; set; }
            public string CreatedDate { get; set; }
            public string SubmittedDate { get; set; }
            public string LastEditTime { get; set; }
            public int ApprovingStatus { get; set; }
            public TimeSpan RestDay { get; set; }
            public List<Plan> PlanList { get; set; }
            public List<Comment> CommentList { get; set; }
 
        }


        /// <summary>
        /// 取得多個提案VM
        /// </summary>
        public class ProjectListResult
        {
            public List<ProjectSingleResult> ProjectList { get; set; }
        }

        /// <summary>
        /// 取得單一提案VM
        /// </summary>
        public class ProjectSingleResult : ProjectBaseModel
        {

        }
        public class GetByCategoryRequest
        {
            public string Category { get; set; }
        }

        public class GetByIdRequest
        {
            public int ProjectId { get; set; }
        }

    }
}
