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
        /// <summary>
        /// 訂單唯一識別碼
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Foreign Key
        /// </summary>
        public int MemberId { get; set; }
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
        /// 是否付款:已付款、未付款
        /// </summary>
        public string condition { get; set; }

        /// <summary>
        /// 訂單成立時間
        /// </summary>
        public DateTime OrderDate { get; set; }
        //導覽屬性
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
       
    }
}