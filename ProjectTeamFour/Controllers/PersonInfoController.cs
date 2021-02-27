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
        public ActionResult Index()
        {
            return View();
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
            return RedirectToAction("Index");
            if (memberInfo != default(ViewModels.MemberViewModel))
            {
                return View(memberInfo);
            }
            return View();
        }

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    Member member = db.Members.Find(id);
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
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
            //ViewBag.ResultMessage = TempData["ResultMessage"];
            //using (ProjectContext db = new ProjectContext())
            //{   //抓取所有AspNetMembers中的資料，並且放入Models.ManageMember模型中
            //    var result = (from s in db.Members
            //                  select new Member
            //                  {
            //                      MemberId = s.MemberId,
            //                      MemberName = s.MemberName,
            //                      MemberRegEmail = s.MemberRegEmail
            //                  }).ToList();
            //    return View(result);
            //}
            return View();
        }

        public ActionResult Setting()
        {
            return View();
        }
    }
}