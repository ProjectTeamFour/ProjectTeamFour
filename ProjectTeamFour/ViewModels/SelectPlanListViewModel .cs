using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.ViewModels
{
    public class ProjectPageViewModel
    {
        public ProjectDetailViewModel projectDetailViewModel { get;set; }
        public List<SelectPlanViewModel> PlanCardItems { get;set; }
    }
}