using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class ProjectDetailListViewModel
    {
        //方案的List
        public List<ProjectDetailViewModel> ProjectDetails { get; set; }
        public List<SelectPlanViewModel> PlanCardItems { get; set; }
    }
}