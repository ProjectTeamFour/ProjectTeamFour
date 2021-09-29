using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string OrderDetailDes { get; set; }
        public int OrderId { get; set; }
        public int ProjectId { get; set; }
        public int PlanId { get; set; }
        public string PlanTitle { get; set; }
        public int OrderQuantity { get; set; }
        public decimal OrderPrice { get; set; }
        public string OrderPlanImgUrl { get; set; }
        public string Condition { get; set; }
        public DateTime PlanShipDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Plan Plan { get; set; }
    }
}
