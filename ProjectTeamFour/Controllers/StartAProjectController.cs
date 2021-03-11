using ProjectTeamFour.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }
    }
}