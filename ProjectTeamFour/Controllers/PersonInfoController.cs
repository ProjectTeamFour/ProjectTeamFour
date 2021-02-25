using ProjectTeamFour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class PersonInfoController : Controller
    {
        //private ProjectContext db = new ProjectContext();

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

        public ActionResult Edit()
        {
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
            return View();
        }

        public ActionResult Setting()
        {
            return View();
        }
    }
}