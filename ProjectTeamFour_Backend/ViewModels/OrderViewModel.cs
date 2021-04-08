using ProjectTeamFour_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class OrderViewModel
    {
        public class OrderBaseViewModel
        {
            /// <summary>
            /// 訂單人編號
            /// </summary>
            public int OrderId { get; set; }
            /// <summary>
            /// 會員編號
            /// </summary>
            public int MemberId { get; set; }          
            public int? PlanPlanId { get; set; }
            /// <summary>
            /// 訂單人名稱
            /// </summary>
            public string OrderName { get; set; }
            /// <summary>
            /// 寄送地址
            /// </summary>
            public string OrderAddress { get; set; }
            /// <summary>
            /// 連絡電話
            /// </summary>
            public string OrderPhone { get; set; }
            /// <summary>
            /// 聯絡信箱
            /// </summary>
            public string OrderConEmail { get; set; }
            /// <summary>
            /// 訂單總額
            /// </summary>
            public decimal OrderTotalAccount { get; set; }
            /// <summary>
            /// 流水編號
            /// </summary>
            public string TradeNo { get; set; }
            /// <summary>
            /// 交易成功與否
            /// </summary>
            public int RtnCode { get; set; }
            /// <summary>
            /// 付款狀態
            /// </summary>
            public string Condition { get; set; }
            /// <summary>
            /// 訂單成立時間
            /// </summary>
            public string OrderDate { get; set; }
            public List<OrderDetail> OrderDetailList { get; set; }
        }
        public class OrderListResult
        {
            public List<OrderSingleResult> MyOrderList { get; set; }
        }

        public class OrderSingleResult: OrderBaseViewModel
        {

        }
    }
}
