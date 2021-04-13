using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Api;
using System.Web.Security;
using ProjectTeamFour.Service;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using ProjectTeamFour.Models;
using ProjectTeamFour.Helpers;

namespace ProjectTeamFour.Controllers
{
    public class MemberController : Controller
    {
        //private PasswordService _passwordservice;
        private MemberService _memberservice;

        private MemberApiController _api;

        public MemberController()
        {
            //_passwordservice = new PasswordService();
            _api = new MemberApiController();
            _memberservice = new MemberService();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MemberRegisterViewModel input)
        {
            MemberViewModel memberVM = _memberservice.GetMember(x => x.MemberRegEmail == input.Email);
            if (memberVM != null)
            {
                return RedirectToAction("RegisterFail", "Member");
            }
            if (ModelState.IsValid)  //這裡是後端驗證input欄位對不對
            {
                MemberViewModel vm = new MemberViewModel()
                {
                    MemberName = input.Name,
                    MemberRegEmail = input.Email,
                    MemberPassword = input.Password,
                    MemberBirth = StringtoDate(input.BirthDay),
                    Gender = input.gender,
                    Permission = 1
                };
                string registerResult = _api.CreateMember(vm);
                if (registerResult == "成功")
                {
                    return RedirectToAction("RegisterSuccess", "Member");
                }
                else
                {
                    return RedirectToAction("RegisterFail", "Member");
                }
            }
            return RedirectToAction("RegisterFail", "Member");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MemberViewModel input)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("LoginFail", "Member");
            //}

            //先抓出email
            MemberViewModel memberinfo = _api.GetMember(x => x.MemberRegEmail == input.MemberRegEmail);
            if (memberinfo == null)
            {
                return RedirectToAction("LoginFail", "Member");
            }
            //如果是假資料
            else if (memberinfo.MemberId <= 17)
            {
                Session["Permission"] = memberinfo.Permission;
                Session["Member"] = memberinfo;
            }
            else
            {
                //確認 hashcode
                bool verify = _memberservice.VerifyPasswordWithHash(input);
                if (verify == false)
                {
                    ModelState.AddModelError("NotFound", "帳號或密碼輸入錯誤");
                    return RedirectToAction("LoginFail", "Member");
                }
                Session["Permission"] = memberinfo.Permission;
                Session["Member"] = memberinfo;
            }
            //1.Create FormsAuthenticationTicket
            var ticket = new FormsAuthenticationTicket(
            version: 1,
            name: "", //可以放使用者Id
            issueDate: DateTime.UtcNow,//現在UTC時間
            expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
            isPersistent: false,// 是否要記住我 true or false
            userData: "", //可以放使用者角色名稱
            cookiePath: FormsAuthentication.FormsCookiePath);

            //2.Encrypt the Ticket
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            //3.Create the cookie.
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);

            //4.Redirect back to original URL.
            var url = FormsAuthentication.GetRedirectUrl("", false);

            //5.Response.Redirect
            return Redirect(url);
        }

        //登出清 session
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Member"] = null;
            Session["Permission"] = null;
            return RedirectToAction("Login", "Member");
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult RegisterFail()
        {
            return View();
        }

        public ActionResult LoginFail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginWithFacebook()
        {
            return null;
        }

        [HttpPost]
        public ActionResult FacebookLogin(string name, string email, string socialPlatform, string imgUrl)
        {
            if (_memberservice.IsSocialAccountRegister(email, socialPlatform))   //尋找是不是早已出現在member這張表
            {
                MemberViewModel member = _api.GetMember(x => x.MemberRegEmail == email && x.IsThirdParty == socialPlatform);

                Session["Permission"] = member.Permission;  //存session
                Session["Member"] = member; //存session

                //var cookie = SetCookie(_memberservice.GetMember(x => x.MemberRegEmail == email).MemberName, false);
                //Response.Cookies.Add(cookie);

                return Json(new { response = "第三方登入", status = 1 }, JsonRequestBehavior.AllowGet);  //吐json物件回去
            }
            else   //如果不在db裡幫他註冊一個
            {
                OperationResult result = _memberservice.SocialAccountRegisterCreate(name, email, socialPlatform, imgUrl);    //幫使用者註冊一個通過第三方登入的會員
                if (result.IsSuccessful == true)
                {
                    MemberViewModel member = _api.GetMember(x => x.MemberRegEmail == email && x.IsThirdParty == socialPlatform);

                    Session["Permission"] = member.Permission; //存session
                    Session["Member"] = member; //存session

                    return Json(new { response = "註冊成功", status = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { response = "目前系統維修中暫時不能申請會員", status = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> GoogleLogin2(string token, int type)
        {
            var result = await _memberservice.GetGoogleInfo(token);

            if (result.IsSuccessful)
            {
                var googleTokenInfo = JsonConvert.DeserializeObject<GoogleApiTokenInfo>(result.MessageInfo);

                if (_memberservice.IsSocialAccountRegister(googleTokenInfo.Email, "Google")) //檢查此帳戶是否存在並註冊
                {
                    MemberViewModel member = _api.GetMember(x => x.MemberRegEmail == googleTokenInfo.Email && x.IsThirdParty == "Google");

                    Session["Permission"] = member.Permission;  //存session
                    Session["Member"] = member; //存session

                    return Json(new { response = "第三方登入", status = 1 });
                }
                else
                {
                    if (type == 0) //若不是，去判斷是進行註冊還是登入
                    {
                        var SocialInfo = new SocialInfo
                        {
                            Email = googleTokenInfo.Email,
                            SocialPlatform = "Google",
                            ImgUrl = googleTokenInfo.Picture,
                        };

                        return Json(new { response = JsonConvert.SerializeObject(SocialInfo), status = 1 });
                    }
                    else
                    {
                        return Json(new { response = "尚未註冊", status = 0 });
                    }
                }
            }
            else
            {
                return Json(new { response = "發生錯誤", status = 0 });
            }
        }

        private DateTime StringtoDate(string input)
        {
            int[] result = input.Split('-').Select(p =>
            {
                return int.Parse(p);
            }).ToArray();
            DateTime dt = new DateTime(result[0], result[1], result[2]);
            return dt;
        }



        [HttpPost]
        public ActionResult GoogleLogin(string name, string email, string socialPlatform, string imgUrl)
        {
            //var result = await _memberservice.GetGoogleInfo(token);

            //if (result.IsSuccessful)
            //{
            //var googleTokenInfo = JsonConvert.DeserializeObject<GoogleApiTokenInfo>(result.MessageInfo);

            if (_memberservice.IsSocialAccountRegister(email, socialPlatform)) //檢查此帳戶是否存在並註冊
            {
                MemberViewModel member = _api.GetMember(x => x.MemberRegEmail == email && x.IsThirdParty == socialPlatform);

                Session["Permission"] = member.Permission;  //存session
                Session["Member"] = member; //存session

                return Json(new { response = "第三方登入", status = 1 }, JsonRequestBehavior.AllowGet);  //吐json物件回去
            }
            else
            {
                OperationResult result = _memberservice.SocialAccountRegisterCreate(name, email, socialPlatform, imgUrl);    //幫使用者註冊一個通過第三方登入的會員
                if (result.IsSuccessful == true)
                {
                    MemberViewModel member = _api.GetMember(x => x.MemberRegEmail == email && x.IsThirdParty == socialPlatform);

                    Session["Permission"] = member.Permission; //存session
                    Session["Member"] = member; //存session

                    return Json(new { response = "註冊成功", status = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { response = "目前系統維修中暫時不能申請會員", status = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            //}
            //else
            //{
            //    return Json(new { response = "發生錯誤", status = 0 });
            //}
        }



        //設定cookie暫時沒用到
        //public static HttpCookie SetCookie(string accountName, bool rememberMe)
        //{
        //    HttpCookie cookie_user = new HttpCookie("user");
        //    var cookieText = Encoding.UTF8.GetBytes(accountName);  //變位元組陣列也就是byte陣列
        //    var encryptedValue = Convert.ToBase64String(MachineKey.Protect(cookieText, "protectedCookie"));  //轉base64
        //    cookie_user.Values["user_accountname"] = encryptedValue;

        //    if (rememberMe == true) cookie_user.Expires = DateTime.Now.AddDays(7);

        //    return cookie_user;
        //}
    }
}