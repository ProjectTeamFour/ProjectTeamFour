using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class StartAProjectController : Controller
    {


        private readonly MemberService _MemberService;
        private readonly SubmissionProcessService _SubmissionProcessService;
        private readonly ProjectDetailEntityService _pdService;

        public StartAProjectController()
        {
            _MemberService = new MemberService();
            _SubmissionProcessService = new SubmissionProcessService();
            _pdService = new ProjectDetailEntityService();
        }
        // GET: StartAProject
        public ActionResult Index()
        {
            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }

            return View();
        }

        public ActionResult SubmissionProcess()
        {
            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }

            ViewBag.MemberId = result;
            return View();
        }

        public ActionResult SubmitSuccess()
        {
            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }


            ViewBag.MemberId = result;
            return View();
        }

        public ActionResult SubmitFail()
        {
            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }


            ViewBag.MemberId = result;
            return View();
        }

        public ActionResult SaveDraftFail()
        {
            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }


            ViewBag.MemberId = result;
            return View();
        }

        public ActionResult SaveDraftSuccess()
        {
            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }

            ViewBag.MemberId = result;
            return View();
        }


        public ActionResult EditDraftProject(int Id)
        {
            int result = _MemberService.ReturnLoginnerId();
            //MyDraftProjectViewModel dpVM = new MyDraftProjectViewModel();
            MyDraftProjectViewModel draftProject = _pdService.GetDraftProjectDetail(Id);

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }

            ViewBag.MemberId = result;
            ViewBag.DraftProjectId = draftProject.DraftProjectId;
            return View(draftProject);
        }


    }
}