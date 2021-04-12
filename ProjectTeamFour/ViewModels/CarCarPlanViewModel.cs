using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    /// <summary>
    /// 前端首頁車車商城畫面所呈現的每張Modal
    /// </summary>
    public class CarCarPlanViewModel
    {
        public int PlanId { get; set; }
        public string PlanImgUrl { get; set; }
        public string Category { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string PlanTitle { get; set; }
        public string PlanDescription { get; set; }
        public string CreatorName { get; set; }
        public decimal PlanPrice { get; set; }
        /// <summary>
        /// 方案庫存
        /// </summary>
        public int QuantityLimit { get; set; } 
        /// <summary>
        /// 購物車未付款品項數量
        /// </summary>
        public int Quantity { get; set; } 
        public int CartId { get; set; }
        public decimal Account { get { return this.PlanPrice * Quantity; } }
        public bool AddCarCarPlan { get; set; }

    }
}