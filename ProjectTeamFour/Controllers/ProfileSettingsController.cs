using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Data;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class ProfileSettingsController : Controller
    {
        private ProfileSettingsContext db = new ProfileSettingsContext();

        // GET: ProfileSettings
        public ActionResult Index()
        {
            // return View(db.ProfileSettings.ToList());
            return View();
        }

        // GET: ProfileSettings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileSetting profileSetting = db.ProfileSettings.Find(id);
            if (profileSetting == null)
            {
                return HttpNotFound();
            }
            return View(profileSetting);
        }

        // GET: ProfileSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileSettings/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Passward,Name,ProfileImage,Email,Gender,Birthday,AboutMe,ProfileUrl,Language,Notifactions")] ProfileSetting profileSetting)
        {
            if (ModelState.IsValid)
            {
                db.ProfileSettings.Add(profileSetting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profileSetting);
        }

        // GET: ProfileSettings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileSetting profileSetting = db.ProfileSettings.Find(id);
            if (profileSetting == null)
            {
                return HttpNotFound();
            }
            return View(profileSetting);
        }

        // POST: ProfileSettings/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Passward,Name,ProfileImage,Email,Gender,Birthday,AboutMe,ProfileUrl,Language,Notifactions")] ProfileSetting profileSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profileSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profileSetting);
        }

        // GET: ProfileSettings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileSetting profileSetting = db.ProfileSettings.Find(id);
            if (profileSetting == null)
            {
                return HttpNotFound();
            }
            return View(profileSetting);
        }

        // POST: ProfileSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProfileSetting profileSetting = db.ProfileSettings.Find(id);
            db.ProfileSettings.Remove(profileSetting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
