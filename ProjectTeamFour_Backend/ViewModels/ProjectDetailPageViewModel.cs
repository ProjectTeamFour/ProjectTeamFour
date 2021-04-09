using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class ProjectDetailPageViewModel
    {
        public ProjectViewModel.ProjectSingleResult ProjectItem { get; set; }
        public CarCarPlanViewModel.PlanListResult PlanItem { get; set; }
        public MemberViewModel.MemberSingleResult MemberItem { get; set; }
    }
}
