//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using ProjectTeamFour.Data;
//using ProjectTeamFour.Models;

//namespace ProjectTeamFour.Controllers
//{
//    public class UsersController : Controller
//    {
//        private UserContext db = new UserContext();

//        // GET: Users
//        public ActionResult Index()
//        {
//            return View(db.Users.ToList());
//        }

//        // GET: Users/Details/5
//        public ActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // GET: Users/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Users/Create
//        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
//        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Password,Name,Email,Gender,Birthday")] User user)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Users.Add(user);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(user);
//        }

//        // GET: Users/Edit/5
//        public ActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: Users/Edit/5
//        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
//        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Password,Name,Email,Gender,Birthday")] User user)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(user).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(user);
//        }

//        // GET: Users/Delete/5
//        public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: Users/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            User user = db.Users.Find(id);
//            db.Users.Remove(user);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
