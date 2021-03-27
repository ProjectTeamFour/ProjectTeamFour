using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class DraftProject
    {
        /// <summary>
        /// DraftProjectId草稿唯一識別碼
        /// </summary>
        public int DraftProjectId { get; set; }
        /// <summary>
        /// 草稿名稱
        /// </summary>
        public string DraftProjectName { get; set; }
        /// <summary>
        /// 目前募資金額
        /// </summary>
        public decimal FundingAmount { get; set; }
        /// <summary>
        /// 專案類別
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 募資起始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 募資結束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        //public double dateLine { get; set; }
        /// <summary>
        /// MemberId唯一識別碼
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 目前贊助人數
        /// </summary>
        public int Fundedpeople { get; set; }
        /// <summary>
        /// 草稿敘述
        /// </summary>
        public string DraftProjectDescription { get; set; }
        /// <summary>
        /// 草稿圖片連結敘述
        /// </summary>
        public string DraftProjectImgUrl { get; set; }
        /// <summary>
        /// 草稿影片內嵌連結敘述
        /// </summary>
        public string DraftProjectVideoUrl { get; set; }
        /// <summary>
        /// 草稿問題內容
        /// </summary>
        public string DraftProject_Question { get; set; }
        /// <summary>
        /// 草稿問題答案
        /// </summary>
        public string DraftProject_Answer { get; set; }
        public DateTime DraftCreatedDate { get; set; }
        public DateTime DraftSubmittedDate { get; set; }
        public DateTime DraftLastEditTime { get; set; }
        public decimal DraftFundingAmount { get; set; }
        public int DraftFundedpeople { get; set; }
        
        public int ApprovingStatus { get; set; }
        public string ProjectStatus { get; set; }
        /// <summary>
        /// 草稿方案數量
        /// </summary>
        public int DraftProjectPlansCount { get; set; }
        /// <summary>
        /// 草稿影片內嵌覆蓋圖片連結
        /// </summary>
        public string DraftProjectCoverUrl { get; set; }
        /// <summary>
        /// 草稿門檻
        /// </summary>
        public decimal AmountThreshold { get; set; }
        /// <summary>
        /// 草稿創建人名稱
        /// </summary>
        public string CreatorName { get; set; }
        /// <summary>
        /// 草稿瀏覽頁的頁面照片
        /// </summary>
        public string DraftProjectMainUrl { get; set; }
        /// <summary>
        /// 提案人真實姓名
        /// </summary>
        public string DraftProjectPrincipal { get; set; }
        /// <summary>
        /// 提案人身分證號碼:True為管理者；False為客服
        /// </summary>
        public string IdentityNumber { get; set; }

        public virtual Member Member { get; set; }
        
        public virtual ICollection<DraftPlan> DraftPlans{ get; set; }

    }
}