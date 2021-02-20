using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.Models;
using System.Data.Entity;
using System.Net.Http;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;

namespace ProjectTeamFour.Service
{
    public interface IProjectDetailService
    {
        ProjectDetailViewModel GetProjectDetail(int ProjectId);
        List<SelectPlanViewModel> GetPlanCards(int projectId);
        ProjectTotalViewModel GetPageViewModel(int projectId);
    }
}
