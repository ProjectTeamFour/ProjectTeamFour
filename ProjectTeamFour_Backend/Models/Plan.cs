using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Plan
    {
        public Plan()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Orders = new HashSet<Order>();
        }

        /// <summary>
        /// 方案唯一識別碼
        /// </summary>
        public int PlanId { get; set; }
        /// <summary>
        /// 方案於提案內的序列
        /// </summary>
        public int ProjectPlanId { get; set; }
        /// <summary>
        /// Foreign Key
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// 方案名稱
        /// </summary>
        public string PlanTitle { get; set; }
        /// <summary>
        /// 方案贊助人數
        /// </summary>
        public int PlanFundedPeople { get; set; }
        /// <summary>
        /// 方案預估寄送時間
        /// </summary>
        public DateTime PlanShipDate { get; set; }
        /// <summary>
        /// 方案詳述
        /// </summary>
        public string PlanDescription { get; set; }
        /// <summary>
        /// 方案圖片連結
        /// </summary>
        public string PlanImgUrl { get; set; }
        /// <summary>
        /// 方案庫存
        /// </summary>
        public int QuantityLimit { get; set; }
        /// <summary>
        /// 對應提案名稱
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 方案價錢
        /// </summary>
        public decimal PlanPrice { get; set; }
        /// <summary>
        /// 是否進入車車商城
        /// </summary>
        public bool AddCarCarPlan { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
