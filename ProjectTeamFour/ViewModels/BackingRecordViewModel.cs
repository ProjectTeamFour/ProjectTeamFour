using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace ProjectTeamFour.ViewModels
{
    public class BackingRecordViewModel
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public string OrderConEmail { get; set; }
        public decimal OrderTotalAccount { get; set; }

        public string TradeNo { get; set; } //綠界的交易編號
        public int RtnCode { get; set; } //交易狀態
        public string condition { get; set; } //是否付款

        //導覽屬性
        //[ForeignKey("MemberId")]
        //public virtual Member Member { get; set; }
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}