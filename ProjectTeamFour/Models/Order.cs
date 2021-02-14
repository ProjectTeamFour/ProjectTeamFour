using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTeamFour.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }

        public int ProjectId { get; set; }
        public int PlanId { get; set; }
        //導覽屬性
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Plan  Plan {get;set;}
    }
}