using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
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
        public int QuantityLimit { get; set; } // 方案限量個數
        public int Quantity { get; set; } // 購物車未付款品項數量
        public int CartId { get; set; }
        public decimal Account { get { return this.PlanPrice * Quantity; } }
        public bool AddCarCarPlan { get; set; }

    }
}