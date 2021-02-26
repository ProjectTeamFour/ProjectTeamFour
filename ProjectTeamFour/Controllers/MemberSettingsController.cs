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
    public class MemberSettingsController : Controller
    {
        private MemberService _memberService;

        public MemberSettingsController()
        {
            _memberService = new MemberService();
        }

        //// GET: Member
        //public ActionResult Index()
        //{
        //    return View("testPageForSonic");
        //}

        // GET: ManageMember
        public ActionResult Index()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            using (ProjectContext db = new ProjectContext())
            {   //抓取所有AspNetMembers中的資料，並且放入Models.ManageMember模型中
                var result = (from s in db.Members
                              select new Member
                              {
                                  MemberId = s.MemberId,
                                  MemberName = s.MemberName,
                                  MemberRegEmail = s.MemberRegEmail
                              }).ToList();
                return View(result);
            }
        }

        //public ActionResult Details(string id)
        //{
        //if (id == null)
        //{
        // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        // }
        // Member member = _memberService.GetMember(id);

        //User user = db.Users.Find(id);
        //if (member == null)
        //{
        //    return HttpNotFound();
        //}
        //return View();
        //}

        //public ActionResult Edit()
        //{
        //MemberViewModel memberInfoVM;



        //return View(memberInfoVM);
        // }
        // GET: Member/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    // id = realID_type_text
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    string[] parmeter = id.Split('_');
        //    //Member member = db.Members.Find(long.Parse(parmeter[0]));
        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        member.MemberName = parmeter[2];
        //        //db.SaveChanges();
        //        return new HttpStatusCodeResult(HttpStatusCode.OK);
        //    }

        //}

        public ActionResult Edit(int id) //編輯該會員個人資料
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
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Edit(int id)
        //{
        //   if(ModelState.IsValid)
        //    {
        //        return Content("修改成功!");
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
