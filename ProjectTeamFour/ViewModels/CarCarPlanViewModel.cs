﻿using System;
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
        public string PlanTitle { get; set; }
        public string PlanDescription { get; set; }
        public string CreatorName { get; set; }
        public decimal PlanPrice { get; set; }
    }
}