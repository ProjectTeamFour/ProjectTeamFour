using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class SubmissionProcessViewModel
    {
        public ProjectListViewModel ProjectItem { get; set; }
        public CarCarPlanListViewModel CarCarPlanItem { get; set; }
        public MemberListViewModel MemberItem { get; set; }
        public ProjectDetailViewModel ProjectDetailItem { get; set; }
        public SelectPlanListViewModel SelectPlanCards { get; set; }


    }
}