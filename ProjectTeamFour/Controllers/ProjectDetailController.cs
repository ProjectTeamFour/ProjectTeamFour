using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Models;
using System.Net;
using ProjectTeamFour.Service;

namespace ProjectTeamFour.Controllers
{
    public class ProjectDetailController : Controller
    {
        private IProjectDetailService projectDetailService;

        public ProjectDetailController()
        {
            projectDetailService = new ProjectDetailEntityService();
            //projectDetailService = new ProjectDetailMockService();
        }

        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            var projectDetailService = new ProjectDetailEntityService();


            ProjectTotalViewModel projectTotalVM = new ProjectTotalViewModel()
            {
                ProjectDetailItem = new ProjectDetailViewModel(),

                SelectPlanCards = new SelectPlanListViewModel()
                {
                    PlanCardItems = new List<SelectPlanViewModel>()
                }
            };

            var projectDetail = projectDetailService.GetProjectDetail(id);
            projectTotalVM.ProjectDetailItem.Equals(projectDetail);

            var plancards = projectDetailService.GetPlanCards(x => x.ProjectId == id);
            foreach (var item in plancards)
            {
                projectTotalVM.SelectPlanCards.PlanCardItems.Add(item);
            }

            return View(projectTotalVM);
        }
    }
}
