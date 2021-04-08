using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Project
    {
        /// <summary>
        /// 提案唯一識別碼
        /// </summary>
        public int ProjectId { get; set; } 
        /// <summary>
        /// 提案名稱
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 提案目前贊助金額
        /// </summary>
        public decimal FundingAmount { get; set; }
        /// <summary>
        /// 提案分類
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 提案狀態: 審核中 集資成功 集資中 結束且成功 結束且失敗
        /// </summary>
        public string ProjectStatus { get; set; } 
        /// <summary>
        /// 提案起始時間
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 提案結束時間
        /// </summary>
        public DateTime EndDate { get; set; }

        //public double dateLine { get; set; }
        /// <summary>
        /// Foreign key
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 贊助人數
        /// </summary>
        public int Fundedpeople { get; set; }
        /// <summary>
        /// 提案詳述
        /// </summary>
        public string ProjectDescription { get; set; }
        /// <summary>
        /// 提案詳細內容
        /// </summary>
        public string ProjectImgUrl { get; set; }
        /// <summary>
        /// 提案內嵌影片連結
        /// </summary>
        public string ProjectVideoUrl { get; set; }
        /// <summary>
        /// 提案常見問題
        /// </summary>
        public string Project_Question { get; set; }
        /// <summary>
        /// 提案常見問題的答案
        /// </summary>
        public string Project_Answer { get; set; }


        /// <summary>
        /// 提案內方案總數量
        /// </summary>
        public int ProjectPlansCount { get; set; }
        /// <summary>
        /// 提案內嵌影片的覆蓋照片
        /// </summary>
        public string ProjectCoverUrl { get; set; }
        /// <summary>
        /// 提案成功的門檻金額
        /// </summary>
        public decimal AmountThreshold { get; set; }
        /// <summary>
        /// 提案人名稱
        /// </summary>
        public string CreatorName { get; set; }
        /// <summary>
        /// 提案瀏覽頁的頁面照片
        /// </summary>
        public string ProjectMainUrl { get; set; }
        /// <summary>
        /// 提案人真實姓名
        /// </summary>
        public string ProjectPrincipal { get; set; }
        /// <summary>
        /// 提案人身分證字號
        /// </summary>
        public string IdentityNumber { get; set; }
        //導覽屬性
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        
        /// <summary>
        /// 提案創建日期
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// 提案提交日期
        /// </summary>
        public DateTime SubmittedDate { get; set; }
        /// <summary>
        /// 提案最後編輯日期
        /// </summary>
        public DateTime LastEditTime { get; set; }
        /// <summary>
        /// 後臺使用 草稿:0;審核中:1；審核成功:2 審核失敗:3
        /// </summary>
        public int ApprovingStatus { get; set; }
        
    }
}