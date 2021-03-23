using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class UserInfoController : Controller
	{
		private readonly MemberService _memberService;
		private readonly MyProjectsService _myProjectsService;
		private readonly CommentService _commentService;
		private readonly BackingService _backingService;

		public UserInfoController()
			{
				_memberService = new MemberService();
				_myProjectsService = new MyProjectsService();
				_commentService = new CommentService();
			    _backingService = new BackingService();
			}

		// GET: PersonInfo
		//[CustomAuthorize(flagNum = 1)]
		public ActionResult Member(int Id)	//公開的個人資料頁面
		{
			var model = (MemberViewModel)Session["Member"];
			if (model != null)
			{
				var memberInfo = _memberService.GetMember(m => m.MemberId == Id);


				//根據專案的提交與審核狀態進行分類
				model.MyProjects  = _myProjectsService.GetProjectsbyMemberId(model.MemberId);
				
				//根據會員id抓取會員購買紀錄
			    model.Records = _backingService.QueryOrder(model.MemberId);

				model.Comments = _commentService.QueryCommentByMemberId(model.MemberId);
				//該會員為提案者沒有留過言，卻要回覆留言
				if (model.Comments.Count==0)
                {

                }

					return model != default(ViewModels.MemberViewModel) ? View(model) : View();
			}
            else
            {
				return RedirectToAction("Login", "Member");
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

		public ActionResult Edit()	//修改個人資料
		{
			var model = (MemberViewModel)Session["Member"];

			MemberViewModel memberVM = new MemberViewModel();

			var memberInfo = _memberService.GetMember(m => m.MemberId == model.MemberId);
			//memberInfo = memberVM;
			//return RedirectToAction("Index");
			return memberInfo != default(ViewModels.MemberViewModel) ? View(memberInfo) : View();
		}

		public ActionResult Account()	//修改密碼以及紀錄第三方登入的會員資料
		{
			var model = (MemberViewModel)Session["Member"];

			MemberViewModel memberVM = new MemberViewModel();

			var memberInfo = _memberService.GetMember(m => m.MemberId == model.MemberId);

			//return RedirectToAction("Index");
			return memberInfo != default(ViewModels.MemberViewModel) ? View(memberInfo) : View();
			//return View();
		}

		//public ActionResult Notifaction()	//通知設定
		//{
		//	return View();
		//}
	}
}