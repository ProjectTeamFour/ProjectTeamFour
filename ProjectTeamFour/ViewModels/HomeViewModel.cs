using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class HomeViewModel
    {
        public ProjectListViewModel ProjectItem { get; set; }
        public CarCarPlanListViewModel CarCarPlanItem { get; set; }
    }
}