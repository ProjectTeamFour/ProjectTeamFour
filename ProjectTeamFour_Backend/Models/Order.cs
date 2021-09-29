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

        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public string OrderConEmail { get; set; }
        public decimal OrderTotalAccount { get; set; }
        public string TradeNo { get; set; }
        public int RtnCode { get; set; }
        public string Condition { get; set; }
        public DateTime OrderDate { get; set; }
        public int? PlanPlanId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Plan PlanPlan { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
