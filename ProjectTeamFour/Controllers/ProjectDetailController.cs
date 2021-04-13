using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Models;
using System.Net;
using ProjectTeamFour.Service;
using ProjectTeamFour.Repositories;
using System.Data.Entity;

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

        public ActionResult DraftProjectDetailPagePreview(int id)
        {
            //var member = (int)System.Web.HttpContext.Current.Session["MyValue"];
            var draftprojectDetailService = new ProjectDetailEntityService();

            if (id.ToString() != null)
            {
                ProjectTotalViewModel draftprojectTotalVM = new ProjectTotalViewModel()
                {
                    //ProjectDetailItem = new ProjectDetailViewModel(),
                    DraftProjectDetailItem = new MyDraftProjectViewModel(),

                    CreatorInfo = new MemberViewModel(),
                    SelectPlanCards = new SelectPlanListViewModel()
                    {
                        //PlanCardItems = new List<SelectPlanViewModel>(),
                        DraftPlanCardItems = new List<SelectDraftPlanViewModel>()
                    }
                };

                var draftprojectDetail = draftprojectDetailService.GetDraftProjectDetail(id);
                draftprojectTotalVM.DraftProjectDetailItem = draftprojectDetail;

                //要本人才能訪問預覽
                MemberViewModel vm = Session["member"] == null ? null : (MemberViewModel)Session["Member"];
                if (vm == null)
                {
                    return HttpNotFound();
                }
                else if (vm != null)
                {
                    if (draftprojectDetail.MemberId != vm.MemberId)
                    {
                        return HttpNotFound();
                    }
                }
                

                var creatorInfo = draftprojectDetailService.GetCreatorInfo(p => p.MemberId == draftprojectTotalVM.DraftProjectDetailItem.MemberId);
                draftprojectTotalVM.CreatorInfo = creatorInfo;

                var draftplancards = draftprojectDetailService.GetDraftPlanCards(x => x.DraftProjectId == id);
                foreach (var item in draftplancards)
                {
                    draftprojectTotalVM.SelectPlanCards.DraftPlanCardItems.Add(item);
                }

                return View(draftprojectTotalVM);

            }
            else
            {
                return HttpNotFound();
            }

        }


        public ActionResult NormalProjectPreview(int id)
        {
            var projectDetailService = new ProjectDetailEntityService();

            if (id.ToString() != null)
            {
                ProjectTotalViewModel projectTotalVM = new ProjectTotalViewModel()
                {
                    ProjectDetailItem = new ProjectDetailViewModel(),

                    CreatorInfo = new MemberViewModel(),
                    SelectPlanCards = new SelectPlanListViewModel()
                    {
                        PlanCardItems = new List<SelectPlanViewModel>()
                    }
                };

                var projectDetail = projectDetailService.GetProjectDetail(id);
                projectTotalVM.ProjectDetailItem = projectDetail;

                MemberViewModel vm = Session["member"] == null ? null : (MemberViewModel)Session["Member"];
                if (vm == null)
                {
                    return HttpNotFound();
                }
                else if (vm != null)
                {
                    if (projectDetail.MemberId != vm.MemberId)
                    {
                        return HttpNotFound();
                    }
                }

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
