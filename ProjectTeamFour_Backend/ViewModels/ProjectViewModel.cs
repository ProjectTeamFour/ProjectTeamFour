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
            public DateTime DateTimeStartDate { get; set; }
            public DateTime DateTimeEndDate { get; set; }
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
            public int RestDay { get; set; }
            public decimal ProjectPercent { get; set; }
            public List<Plan> PlanList { get; set; }
            public List<Comment> CommentList { get; set; }
            public List<ProjectFAQViewModel> ProjectFAQList { get; set; }

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

        /// <summary>
        /// Dashboard會用到的有關Project的Model for Api
        /// </summary>
        public class GetProjectChart
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public decimal FundingAmount { get; set; }
            public string Category { get; set; }
            public string ProjectStatus { get; set; }

        }
        /// <summary>
        /// 取得多個提案VM
        /// </summary>
        public class ProjectListforChart
        {
            public List<ProjectforChart> ProjectChartdta { get; set; }
        }

        /// <summary>
        /// 取得單一提案VM
        /// </summary>
        public class ProjectforChart : GetProjectChart
        {

        }
        /// <summary>
        /// 取得專案達成度
        /// </summary>
        public class GetProjectPercent
        {
            public decimal ProjectPercent { get; set; }
        }
        /// <summary>
        /// 取得專案達成度清單
        /// </summary>
        public class ProjectListForPercent
        {
            public List<GetProjectPercent> getProjectPercentsList { get; set; }
        }
    }
}
