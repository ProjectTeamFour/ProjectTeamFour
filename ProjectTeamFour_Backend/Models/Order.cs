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
        /// 每筆訂單的唯一識別碼
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 會員id
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// Null
        /// </summary>
        public int? PlanPlanId { get; set; }
        /// <summary>
        /// 訂單人名稱
        /// </summary>
        public string OrderName { get; set; }
        /// <summary>
        /// 寄送地址        
        /// </summary>
        public string OrderAddress { get; set; }
        /// <summary>
        ///連絡電話 
        /// </summary>
        public string OrderPhone { get; set; }
        /// <summary>
        /// 聯絡信箱
        /// </summary>
        public string OrderConEmail { get; set; }
        /// <summary>
        /// 訂單總額
        /// </summary>
        public decimal OrderTotalAccount { get; set; }
        /// <summary>
        /// 訂單流水號
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 是否成功判別碼(綠界)
        /// </summary>
        public int RtnCode { get; set; }
        /// <summary>
        /// 付款狀態
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 訂單創立日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual Plan PlanPlan { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
