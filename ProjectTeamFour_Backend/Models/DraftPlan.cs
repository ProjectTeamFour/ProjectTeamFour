using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class DraftPlan
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

        public virtual DraftProject DraftProject { get; set; }
    }
}
