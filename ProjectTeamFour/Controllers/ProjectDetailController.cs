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

            if (id.ToString() != null)
            {


                ProjectTotalViewModel projectTotalVM = new ProjectTotalViewModel()
                {
                    ProjectDetailItem = new ProjectDetailViewModel(),

                    CreatorInfo=new MemberViewModel(),
                    SelectPlanCards = new SelectPlanListViewModel()
                    {
                        PlanCardItems = new List<SelectPlanViewModel>()
                    }
                };

                

                var projectDetail = projectDetailService.GetProjectDetail(id);
                projectTotalVM.ProjectDetailItem = projectDetail;


                // var creatorInfo = projectDetailService.GetCreatorInfo(x => x.MemberId == MemberService.membMemberId);
                var creatorInfo = projectDetailService.GetCreatorInfo(p => p.MemberId == projectTotalVM.ProjectDetailItem.MemberId);
                projectTotalVM.CreatorInfo = creatorInfo;

                var plancards = projectDetailService.GetPlanCards(x => x.ProjectId == id);
                foreach (var item in plancards)
                {
                    projectTotalVM.SelectPlanCards.PlanCardItems.Add(item);
                }

                return View(projectTotalVM);

            }
            else
            {
                return HttpNotFound();
            }

        }


    }
}
