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
		private readonly MyProjectsService _myProjectsService;
		private readonly CommentService _commentService;

	 //	int result = _MemberService.ReturnLoginnerId();

	 //           if (result == 0)
	 //           {
	 //               return RedirectToAction("Login", "Member");
	 //}

	public UserInfoController()
        {
            _memberService = new MemberService();
			_myProjectsService = new MyProjectsService();
			_commentService = new CommentService();
			//_memberSettingService = new MemberSettingService();
		}

		// GET: PersonInfo
		//[CustomAuthorize(flagNum = 1)]
		public ActionResult User(int Id)	//公開的個人資料頁面
		{
			var model = (MemberViewModel)Session["Member"];
			var memberService = new MemberService();

			MemberViewModel memberVM = new MemberViewModel();

			var memberInfo = _memberService.GetMember(m => m.MemberId == Id);
			//return View(memberInfo);
			//return RedirectToAction("Index");
			return memberInfo != default(ViewModels.MemberViewModel) ? View(memberInfo) : View();
		}

		public ActionResult Sponser() //贊助紀錄
		{
			var model = (MemberViewModel)Session["Member"];
			return View(model);
		}

		public ActionResult Myprojects()	//專案提交紀錄
		{
			var model = (MemberViewModel)Session["Member"];
			if (model != null)
			{
				MyProjectListViewModel myProjectList = new MyProjectListViewModel()
				{
					MyProjects = new List<MyProjectViewModel>()
				};

				//根據專案的提交與審核狀態進行分類
				myProjectList = _myProjectsService.GetProjectsbyMemberId(model.MemberId);
				//foreach(var item in myProjects.MyProjects)
				//         {
				//	myProjects.OngoingProjects.Add(item);
				//         }

				return View(myProjectList);
			}
            else
            {
				return RedirectToAction("Login", "Member");
			}
		}

		public ActionResult Message()		//聯絡訊息
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
			var model = (MemberViewModel)Session["Member"];
			var memberService = new MemberService();

			MemberViewModel memberVM = new MemberViewModel();

			var memberInfo = _memberService.GetMember(m => m.MemberId == id);
			//return View(memberInfo);
			//return RedirectToAction("Index");
			return memberInfo != default(ViewModels.MemberViewModel) ? View(memberInfo) : View();
		}

		public ActionResult Account()	//修改密碼以及紀錄第三方登入的會員資料
		{
			return View();
		}

		public ActionResult Notifactions()	//通知設定
		{
			return View();
		}
	}
}