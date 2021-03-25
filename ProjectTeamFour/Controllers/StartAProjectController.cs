using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using ProjectTeamFour.Service;
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


        private MemberService _MemberService;

        public StartAProjectController()
        {
            _MemberService = new MemberService();
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
            ViewBag.MemberId = result;
            return View();
        }

        public ActionResult SubmitSuccess()
        {
            int result = _MemberService.ReturnLoginnerId();
            ViewBag.MemberId = result;
            return View();
        }

        public ActionResult SubmitFail()
        {
            int result = _MemberService.ReturnLoginnerId();
            ViewBag.MemberId = result;
            return View();
        }


    }
}