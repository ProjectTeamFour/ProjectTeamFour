using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTeamFour.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string OrderDetailDes { get; set; }
        public int OrderId { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }

        //導覽屬性
        public virtual Order Order { get; set; }
        
        public virtual Plan Plan { get; set; }
    }
}