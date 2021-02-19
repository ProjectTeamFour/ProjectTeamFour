using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.ViewModels
{
    public class SelectPlanViewModel
    {
        public int PlanId { get; set; }
        public int ProjectPlanId { get; set; }

        public int ProjectId { get; set; }
        public string PlanTitle { get; set; }
        public int PlanFundedPeople { get; set; }
        public DateTime PlanShipDate { get; set; }
        public string PlanDescription { get; set; }
        public string PlanImgUrl { get; set; }
        public decimal PlanPrice { get; set; }
        public int QuantityLimit { get; set; }
        ////導覽屬性
        //public virtual Project Project { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
    }
}