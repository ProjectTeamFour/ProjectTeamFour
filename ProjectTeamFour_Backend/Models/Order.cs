using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        /// <summary>
        /// 訂單唯一識別碼
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Foreign Key
        /// </summary>
        public int MemberId { get; set; }

        public int? PlanPlanId { get; set; }
        /// <summary>
        /// 訂單名稱
        /// </summary>
        public string OrderName { get; set; }
        /// <summary>
        /// 訂單地址
        /// </summary>
        public string OrderAddress { get; set; }
        /// <summary>
        /// 訂單手機號碼
        /// </summary>
        public string OrderPhone { get; set; }
        /// <summary>
        /// 訂單聯繫email
        /// </summary>
        public string OrderConEmail { get; set; }
        /// <summary>
        /// 訂單金額
        /// </summary>
        public decimal OrderTotalAccount { get; set; }
        /// <summary>
        /// 綠界的交易編號
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 交易狀態
        /// </summary>
        public int RtnCode { get; set; }
        /// <summary>
        /// 是否付款
        /// </summary>
        public string Condition { get; set; }

        public virtual Member Member { get; set; }
        public virtual Plan PlanPlan { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
