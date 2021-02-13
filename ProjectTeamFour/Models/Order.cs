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
        public Guid OrderId { get; set; }
        public Guid OrderMemberId { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        //導覽屬性
        [ForeignKey("OrderMemberId")]
        public virtual Member Member { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}