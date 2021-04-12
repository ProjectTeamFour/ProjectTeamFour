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

        public int PlanId { get; set; }
        public int ProjectPlanId { get; set; }
        public bool AddCarCarPlan { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string PlanTitle { get; set; }
        public int PlanFundedPeople { get; set; }
        public DateTime PlanShipDate { get; set; }
        public string PlanDescription { get; set; }
        public string PlanImgUrl { get; set; }
        public decimal PlanPrice { get; set; }
        public int QuantityLimit { get; set; }
        public int? SubmitLimit { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
