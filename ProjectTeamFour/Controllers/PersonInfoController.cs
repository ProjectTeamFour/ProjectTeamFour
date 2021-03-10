using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Service;
using System.Linq.Expressions;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.Helpers;

namespace ProjectTeamFour.Controllers
{
    public class PersonInfoController : Controller
    {
        private MemberService _memberService;

        public PersonInfoController()
        {
            _memberService = new MemberService();
        }

        // GET: PersonInfo
        //[CustomAuthorize(flagNum = 1)]
        public ActionResult Index()
        {
            var model = (MemberViewModel)Session["Member"];
            return View(model);
        }

        public ActionResult Sponser()
        {
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }

        public ActionResult Connect()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var memberService = new MemberService();

            MemberViewModel memberVM = new MemberViewModel();

            var memberInfo = _memberService.GetMember(m => m.MemberId == id);
            //return View(memberInfo);
            //return RedirectToAction("Index");
            return memberInfo != default(ViewModels.MemberViewModel) ? View(memberInfo) : View();
        }

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MemberId,MemberName,MemberTeamName,MemberAccount,MemberPassword,MemberAddress,MemberPhone,MemberRegEmail,MemberConEmail,Gender,MemberBirth,AboutMe,ProfileImgUrl,MemberWebsite,MemberMessage,Permission")] Member member)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(member).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(member);
        //}

        public ActionResult Account()
        {
            return View();
        }

        public ActionResult Setting()
        {
            return View();
        }
    }
}