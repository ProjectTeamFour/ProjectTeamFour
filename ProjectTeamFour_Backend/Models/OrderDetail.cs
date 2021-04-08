using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class OrderDetail
    {
        /// <summary>
        /// 詳細訂單唯一識別id
        /// </summary>
        public int OrderDetailId { get; set; }
        /// <summary>
        /// 訂單詳述
        /// </summary>
        public string OrderDetailDes { get; set; }
        /// <summary>
        /// 訂單唯一識別碼
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 方案id
        /// </summary>
        public int PlanId { get; set; }
        /// <summary>
        /// 方案標題
        /// </summary>
        public string PlanTitle { get; set; }
        /// <summary>
        /// 單品購買數量
        /// </summary>
        public int OrderQuantity { get; set; }
        /// <summary>
        /// 方案單價
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 提案id
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// 方案圖片
        /// </summary>
        public string OrderPlanImgUrl { get; set; }
        /// <summary>
        /// 方案購買狀態
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 預計寄送時間(會以該完整訂單最晚日期的一筆之寄送時間統一寄出)
        /// </summary>
        public DateTime PlanShipDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
