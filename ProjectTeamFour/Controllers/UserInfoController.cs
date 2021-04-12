using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System.Web.Mvc;
using ProjectTeamFour.Models;
using System.Linq.Expressions;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.Helpers;
using System.Web.Http;
using System.Collections.Generic;

namespace ProjectTeamFour.Controllers
{
    public class UserInfoController : Controller
	{
		private readonly LogService _logService;
		private readonly MemberService _memberService;
		private readonly MyProjectsService _myProjectsService;
		private readonly CommentService _commentService;
		private readonly BackingService _backingService;
        private readonly AnnouncementService _announcementService;
		private readonly PlanRecordsService _planRecordsService;

		public UserInfoController()
		{
			    _logService = new LogService();
				_memberService = new MemberService();
				_myProjectsService = new MyProjectsService();
				_commentService = new CommentService();
			    _backingService = new BackingService();
                _planRecordsService = new PlanRecordsService();
                _announcementService = new AnnouncementService();
        }

        // GET: PersonInfo
        //[CustomAuthorize(flagNum = 1)]
        public ActionResult Member(int Id)  //公開的個人資料頁面
        {
            var model = (MemberViewModel)Session["Member"];
            if (model != null)
            {
                var memberInfo = _memberService.GetMember(m => m.MemberId == Id);


				//根據專案的提交與審核狀態進行分類
				model.MyProjects  = _myProjectsService.GetProjectsbyMemberId(model.MemberId);

                model.MyDraftProjects = _myProjectsService.GetDraftProjectsbyMemberId(model.MemberId);
                //根據會員id抓取通知紀錄
                model.Announcements = _announcementService.GetAnnouncement(model.MemberId);
				
				//根據會員id抓取會員購買紀錄
			    model.Records = _backingService.QueryOrder(model.MemberId);

				if(model.MyProjects.Count==0)
                {
					model.Comments = _commentService.QueryCommentByMemberId(model.MemberId);
                    ///如果model.PlanRecords = null須防止例外跳出
                    model.PlanRecords = null;
				}
				else
                {
					model.Comments = _commentService.QueryCommentByaskedMemberId(model.MemberId);
                    model.Records = _backingService.QueryOrder(model.MemberId);
                    model.PlanRecords = _planRecordsService.QueryResult(model.MyProjects);
                    
                }
				//該會員為提案者沒有留過言，卻要回覆留言
				

					return model != default(ViewModels.MemberViewModel) ? View(model) : View();
			}
            else
            {
                return RedirectToAction("Login", "Member");
            }
        }
        public ActionResult Users(int Id)
        {

            var memberInfo = _memberService.GetMember(m => m.MemberId == Id);
            if (memberInfo != null)
            {
                //根據專案的提交與審核狀態進行分類
                memberInfo.MyProjects = _myProjectsService.GetProjectsbyMemberId(memberInfo.MemberId);

                //根據會員id抓取會員購買紀錄
                memberInfo.Records = _backingService.QueryOrder(memberInfo.MemberId);

                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }

        //public ActionResult Sponser() //贊助紀錄
        //{
        //    var model = (MemberViewModel)Session["Member"];
        //    if (model != null)
        //    {

        //        //根據會員id抓取會員購買紀錄
        //        model.Records = _backingService.QueryOrder(model.MemberId);
        //    }
        //    return View();

        //}

        //public ActionResult Myprojects()	//專案提交紀錄
        //{
        //	var model = (MemberViewModel)Session["Member"];
        //	if (model != null)
        //	{
        //		//根據專案的提交與審核狀態進行分類
        //		//model.MyProjects  = _myProjectsService.GetProjectsbyMemberId(model.MemberId);				
        //		return View(model);
        //	}
        //          else
        //          {
        //		return RedirectToAction("Login", "Member");
        //	}
        //}

        //public ActionResult Message()		//聯絡訊息
        //{
        //	var model = (MemberViewModel)Session["Member"];
        //	return View(model);
        //}

        //public ActionResult Activity()	//最新通知(可以連動贊助或購買商品後收發訂單狀態的email功能)
        //{
        //	var model = (MemberViewModel)Session["Member"];
        //	return View(model);
        //}

        //public ActionResult Edit()	//修改個人資料
        //{
        //	var model = (MemberViewModel)Session["Member"];

        //	MemberViewModel memberVM = new MemberViewModel();

        //	var memberInfo = _memberService.GetMember(m => m.MemberId == model.MemberId);
        //	//memberInfo = memberVM;
        //	//return RedirectToAction("Index");
        //	return memberInfo != default(ViewModels.MemberViewModel) ? View(memberInfo) : View();
        //}

        //public ActionResult Account()	//修改密碼以及紀錄第三方登入的會員資料
        //{
        //	var model = (MemberViewModel)Session["Member"];

        //	MemberViewModel memberVM = new MemberViewModel();

        //	var memberInfo = _memberService.GetMember(m => m.MemberId == model.MemberId);

        //	//return RedirectToAction("Index");
        //	return memberInfo != default(ViewModels.MemberViewModel) ? View(memberInfo) : View();
        //	//return View();
        //}


        public string LoginedChangePassword([FromBody] MemberViewModel input)
		{
			var result = new OperationResult();
			result = _memberService.ResetPassWord(input);
			if (result.IsSuccessful)
			{
				_memberService.Relogin();
				return "成功";
			}
			else
			{
				//Log entity = new Log()
				//{
				//	DateTime = result.DateTime
				//};
				//_logService.Create(entity);
				return "失敗";
			}
		}


        //public ActionResult Notifaction()	//通知設定
        //{
        //	return View();
        //}

        public ActionResult ToNews(int Id)  //公開的個人資料頁面
        {
            var model = (MemberViewModel)Session["Member"];
            if (model != null)
            {
                var memberInfo = _memberService.GetMember(m => m.MemberId == Id);


                //根據專案的提交與審核狀態進行分類
                model.MyProjects = _myProjectsService.GetProjectsbyMemberId(model.MemberId);

                //根據會員id抓取會員購買紀錄
                model.Records = _backingService.QueryOrder(model.MemberId);
                //根據會員id抓取通知
                model.Announcements = _announcementService.GetAnnouncement(model.MemberId);
                if (model.MyProjects.Count == 0)
                {
                    model.Comments = _commentService.QueryCommentByMemberId(model.MemberId);
                }
                else
                {
                    model.Comments = _commentService.QueryCommentByaskedMemberId(model.MemberId);
                }
                //該會員為提案者沒有留過言，卻要回覆留言


                return model != default(ViewModels.MemberViewModel) ? View(model) : View();
            }
            else
            {
                return RedirectToAction("Login", "Member");
            }
        }

        [System.Web.Http.HttpPost]
        public ActionResult FindOrder(Order oVM)
        {   

            var order = _backingService.FindOrder(oVM);
            return View(order);         
        }
    }
}