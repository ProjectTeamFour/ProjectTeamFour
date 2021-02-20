using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class CartItemViewModel
    {
        public int CartId { get; set; }

        public int PlanId { get; set; }

        public string Title { get; set; }

        public string PlanUrl { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Account { get { return this.Price * Quantity; } }
    }
}