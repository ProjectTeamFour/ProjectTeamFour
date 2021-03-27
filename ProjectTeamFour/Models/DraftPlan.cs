using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class DraftPlan
    {
        public int DraftPlanId { get; set; }
        public int DraftProjectPlanId { get; set; }
        public bool DraftAddCarCarPlan { get; set; }
        public string DraftProjectName { get; set; }
        public int DraftProjectId { get; set; }
        public string DraftPlanTitle { get; set; }
        public int DraftPlanFundedPeople { get; set; }
        public DateTime DraftPlanShipDate { get; set; }
        public string DraftPlanDescription { get; set; }
        public string DraftPlanImgUrl { get; set; }
        public decimal DraftPlanPrice { get; set; }
        public int DraftQuantityLimit { get; set; }
    }
}