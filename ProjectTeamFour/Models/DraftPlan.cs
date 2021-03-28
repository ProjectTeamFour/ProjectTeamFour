using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class DraftPlan
    {
        /// <summary>
        /// DraftPlanId唯一識別碼
        /// </summary>
        public int DraftPlanId { get; set; }
        /// <summary>
        /// 草稿方案序列
        /// </summary>
        public int DraftProjectPlanId { get; set; }
        /// <summary>
        /// 草稿方案是否加入購物車
        /// </summary>
        public bool DraftAddCarCarPlan { get; set; }
        /// <summary>
        /// 草稿專案名稱
        /// </summary>
        public string DraftProjectName { get; set; }
        /// <summary>
        /// 草稿方案的專案ID
        /// </summary>
        public int DraftProjectId { get; set; }
        /// <summary>
        /// 草稿方案的名稱
        /// </summary>
        public string DraftPlanTitle { get; set; }
        /// <summary>
        /// 草稿方案的贊助人數
        /// </summary>
        public int DraftPlanFundedPeople { get; set; }
        /// <summary>
        /// 草稿方案預計運送時間
        /// </summary>
        public DateTime DraftPlanShipDate { get; set; }
        /// <summary>
        /// 草稿方案詳細說明
        /// </summary>
        public string DraftPlanDescription { get; set; }
        /// <summary>
        /// 草稿方案圖片連結
        /// </summary>
        public string DraftPlanImgUrl { get; set; }
        /// <summary>
        /// 草稿方案價錢
        /// </summary>
        public decimal DraftPlanPrice { get; set; }
        /// <summary>
        /// 草稿方案庫存
        /// </summary>
        public int DraftQuantityLimit { get; set; }

        public virtual DraftProject DraftProject { get; set; }
    }
}