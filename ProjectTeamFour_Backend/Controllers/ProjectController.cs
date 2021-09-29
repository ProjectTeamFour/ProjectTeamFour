using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Services;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.Controllers
{
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WaitforPass()
        {
            return View();
        }

        public IActionResult ProjectDetail(int Id)
        {
            if (Id.ToString() != null)
            {
                ProjectDetailPageViewModel projectTotalVM = new ProjectDetailPageViewModel
                {
                    ProjectItem = new ProjectViewModel.ProjectSingleResult(),
                    MemberItem = new MemberViewModel.MemberSingleResult(),
                    PlanItem = new CarCarPlanViewModel.PlanListResult()
                    {
                        CarCarPlanList = new List<CarCarPlanViewModel.SelectPlanViewModel>(),
                    }
                };
                var projectDetail = _projectService.GetProjectById(Id);
                projectTotalVM.ProjectItem = projectDetail;

                var creatorInfo = _projectService.GetCreatorInfo(projectTotalVM.ProjectItem.MemberId);
                projectTotalVM.MemberItem = creatorInfo;

                var plancards = _projectService.GetPlanCards(Id);

                if (plancards != null)
                {
                    foreach (var item in plancards)
                    {
                        projectTotalVM.PlanItem.CarCarPlanList.Add(item);
                    }
                }
                return View(projectTotalVM);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
