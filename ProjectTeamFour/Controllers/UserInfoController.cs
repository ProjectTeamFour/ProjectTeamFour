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
	public class UserInfoController : Controller
	{
		private readonly MemberService _memberService;
		//private readonly BackingService _backingService;
		private readonly ProjectsService _ProjectsService;
		private readonly CommentService _commentService;
		private readonly BackingService _backingService;

        public UserInfoController()
        {
            _memberService = new MemberService();
            //_memberSettingService = new MemberSettingService();
        }

		// GET: PersonInfo
		//[CustomAuthorize(flagNum = 1)]
		public ActionResult Index()	//公開的個人資料頁面
		{
			var model = (MemberViewModel)Session["Member"];			
			return View(model);
		}

		public ActionResult Sponser() //贊助紀錄
		{
			var model = (MemberViewModel)Session["Member"];
			return View(model);
		}

		public ActionResult Myprojects()	//專案提交紀錄
		{
			var model = (MemberViewModel)Session["Member"];



			return View(model);
		}

		public ActionResult Message()		//第三方連動帳號
		{
			var model = (MemberViewModel)Session["Member"];
			return View(model);
		}

		public ActionResult Activity()	//最新通知(可以連動贊助或購買商品後收發訂單狀態的email功能)
		{
			var model = (MemberViewModel)Session["Member"];
			return View(model);
		}

		public ActionResult Edit(int id)	//修改個人資料
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

		public ActionResult Account()	//修改密碼以及紀錄第三方登入的會員資料
		{
			return View();
		}

		public ActionResult Setting()	//通知設定
		{
			return View();
		}
	}
}