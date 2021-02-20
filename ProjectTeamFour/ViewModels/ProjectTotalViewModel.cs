using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    //完整商品詳細頁的ViewModel聚合
    public class ProjectTotalViewModel
    {
        public ProjectDetailViewModel ProjectDetailItem { get;set; }
        public SelectPlanListViewModel SelectPlanCards { get; set; }
    }
}