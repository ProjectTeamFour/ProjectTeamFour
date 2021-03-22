using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Api;
using System.Web.Security;
using ProjectTeamFour.Service;

namespace ProjectTeamFour.Controllers
{
    public class MemberController : Controller
    {
        //private PasswordService _passwordservice;
        private MemberService _memberservice;
        private MemberApiController _api;
        public MemberController()
        {
            //_passwordservice = new PasswordService();
            _api = new MemberApiController();
            _memberservice = new MemberService();
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
                    Gender = input.gender,
                    Permission = 1 
                };
                string registerResult = _api.CreateMember(vm);
                if (registerResult == "成功")
                {
                    return RedirectToAction("RegisterSuccess", "Member");
                }
                else
                {
                    return RedirectToAction("RegisterFail", "Member");
                }
            }
            return RedirectToAction("RegisterFail", "Member");
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
            if (!ModelState.IsValid)
            {
                return View(input);  //輸錯通知要改
            }

            //確認 hashcode
            bool verify = _memberservice.VerifyPasswordWithHash(input);

            if (verify == false)
            {
                ModelState.AddModelError("NotFound", "帳號或密碼輸入錯誤");
                return View(input); //輸錯通知要改
            }

            MemberViewModel memberinfo = _api.GetMember(x => x.MemberRegEmail == input.Email);
            Session["Permission"] = memberinfo.Permission;
            Session["Member"] = memberinfo;
            //1.Create FormsAuthenticationTicket
           var ticket = new FormsAuthenticationTicket(
           version: 1,
           name: "", //可以放使用者Id
           issueDate: DateTime.UtcNow,//現在UTC時間
           expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
           isPersistent: false,// 是否要記住我 true or false
           userData: "", //可以放使用者角色名稱
           cookiePath: FormsAuthentication.FormsCookiePath);

            //2.Encrypt the Ticket
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            //3.Create the cookie.
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);

            //4.Redirect back to original URL.
            var url = FormsAuthentication.GetRedirectUrl("", false);

            //5.Response.Redirect
            return Redirect(url);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Member"] = null;
            Session["Permission"] = null;
            return RedirectToAction("Login", "Member");
        }


        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult RegisterFail()
        {
            return View();
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