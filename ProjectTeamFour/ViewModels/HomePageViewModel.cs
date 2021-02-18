using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class HomePageViewModel
    {
        public List<ProjectTotalViewModel> ProjectItem { get; set; }
        public List<CarCarPlanListViewModel> CarCarPlanItem { get; set; }
    }
}