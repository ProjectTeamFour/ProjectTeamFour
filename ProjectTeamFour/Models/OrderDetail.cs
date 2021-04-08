using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTeamFour.Models
{
    public class OrderDetail
    {
        /// <summary>
        /// 訂單明細唯一識別碼
        /// </summary>
        public int OrderDetailId { get; set; }
        /// <summary>
        /// 訂單明細詳述
        /// </summary>
        public string OrderDetailDes { get; set; }
        /// <summary>
        /// Foreign Key
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Foreign Key
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// Foreign Key
        /// </summary>
        public int PlanId { get; set; }
        /// <summary>
        /// 訂單明細內方案名稱
        /// </summary>
        public string PlanTitle { get; set; }
        /// <summary>
        /// 訂單明細數量
        /// </summary>
        public int OrderQuantity { get; set; }
        /// <summary>
        /// 訂單明細金額
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 訂單明細內方案圖片連結
        /// </summary>
        public string OrderPlanImgUrl { get; set; }
        /// <summary>
        /// 訂單明細是否付款，共有三種:未付款、已付款、須退款
        /// </summary>
        public string condition { get; set; }
        /// <summary>
        /// 寄送時間
        /// </summary>
        public DateTime PlanShipDate { get; set; }
        //導覽屬性
        public virtual Order Order { get; set; }
        public virtual Plan Plan { get; set; }
    }
}