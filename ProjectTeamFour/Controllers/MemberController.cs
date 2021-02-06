using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;
using ProjectTeamFour.Service;

namespace ProjectTeamFour.Controllers
{
    public class MemberController : Controller
    {
        private MemberService _memberService;
        public MemberController()
        {
            _memberService = new MemberService();
        }
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string acc,string pwd)
        {
            if (Session["Member"] == null)
            {
                Member m = _memberService.GetMember(acc, pwd);
                Session["Member"] = m;
            }
            return View();
        }
    }
}