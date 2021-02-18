using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using ProjectTeamFour.Data;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class MemberSettingsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        //// GET: Member
        //public ActionResult Index()
        //{
        //    return View("testPageForSonic");
        //}
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            //if (member == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }
        //// GET: Member/Edit/5
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        //db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }



    




    
}
