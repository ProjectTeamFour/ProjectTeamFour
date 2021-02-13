using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTeamFour.Models
{
    public class Plan
    {
        public Guid PlanId { get; set; }
        public int OderIndex { get; set; }
        public Guid Projectid { get; set; }
        public string PlanTitle { get; set; }
        public int PlanFundedPeople { get; set; }
        public DateTime PlanShipDate { get; set; }
        public string PlanDescription { get; set; }
        public string PlanImgUrl { get; set; }
        public decimal PlanePrice { get; set; }
        //導覽屬性
        public virtual Project Project { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}