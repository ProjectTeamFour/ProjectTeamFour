using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Currency)]
        public decimal PlanPrice { get; set; }
        public int QuantityLimit { get; set; }

        public bool AddCarCarPlan { get; set; }

        // ---------------------------
        public string ProjectName { get; set; }

        public int? SubmitLimit { get; set; }
    }
}