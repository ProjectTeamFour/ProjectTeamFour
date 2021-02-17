using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Api;

namespace ProjectTeamFour.Controllers
{
    public class MemberController : Controller
    {
        private MemberApiController _api;
        public MemberController()
        {
            _api = new MemberApiController();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(MemberRegisterViewModel input)
        {
            if (ModelState.IsValid)
            {
                MemberViewModel vm = new MemberViewModel()
                {
                    MemberName = input.Name,
                    MemberRegEmail = input.Email,
                    MemberPassword = input.Password,
                    MemberBirth = StringtoDate(input.BirthDay),
                    Gender=input.gender  
                };
                _api.CreateMember(vm);
            }
            return View();
        }
        private DateTime StringtoDate(string input)
        {
            int[] result = input.Split('-').Select(p =>
            {
                return int.Parse(p);
            }).ToArray();
            DateTime dt = new DateTime(result[0], result[1], result[2]);
            return dt;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberLoginViewModel input)
        {
            MemberViewModel viewModel = null;
            if (ModelState.IsValid)
            {
                viewModel= _api.GetMemberbyReg(input.Email);
                if (viewModel == null)
                {
                    ViewData["WrongAccount"] = "帳號錯誤!";
                    return View();
                }
                if (viewModel.MemberPassword != input.Password)
                {
                    ViewData["WrongPassword"] = "密碼錯誤!";
                    return View();
                }
                Session["Member"] = viewModel;
            }
            return RedirectToAction("Index","Home");
        }
        public ActionResult Logout()
        {
            Session["Member"] = null;
            return RedirectToAction("Index", "Home");
        }
 


        //private MemberService _memberService;
        //public MemberController()
        //{
        //    _memberService = new MemberService();
        //}
        //// GET: Member
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult Login(string acc, string pwd)
        //{
        //    if (Session["Member"] == null)
        //    {
        //        Member m = _memberService.GetMember(acc, pwd);
        //        Session["Member"] = m;
        //    }
        //    return View();
        //}
    }
}