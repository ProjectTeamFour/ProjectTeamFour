using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class SelectPlan
    {
        public int Id { get; set; }
        public string PlanTitle { get; set; }
        public string PlanDescription { get; set; }
        public decimal PlanPrice { get; set; }
        public int FundedPeople { get; set; }
        public DateTime ExpectShipDate { get; set; }
        public string PlaceAllowedShippng { get; set; }

    }
}