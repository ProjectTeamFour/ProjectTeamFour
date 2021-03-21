using ProjectTeamFour.Api;
using ProjectTeamFour.Models;
using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class ForgotPasswordController : Controller
    {

        //private static readonly Byte[] _privateKey = new Byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
        private static readonly TimeSpan _passwordResetExpiry = TimeSpan.FromMinutes(5);
        private static readonly Byte[] _privateKey = new HMACSHA256().Key;
        private const Byte _version = 1; // Increment this whenever the structure of the message changes.

       
        private MemberApiController _api;
        private MemberService _memberService;
        private LogService _logservice;


        public ForgotPasswordController()
        {
            _api = new MemberApiController();
            _memberService = new MemberService();
            _logservice = new LogService();
        }



        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMail([Bind(Include = "sender, receiver, MailTitle, MailBody")] MailViewModel mailVM)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "如果您的信箱輸入正確，已經發送驗證信至您信箱");
                return View(mailVM);
            }

            MemberViewModel viewModel = _api.GetMember(p => p.MemberRegEmail == mailVM.receiver);

            if (viewModel == null)
            {
                ModelState.AddModelError("", "如果您的信箱輸入正確，已經發送驗證信至您信箱");
                return View(mailVM);
            }

            var outputCode = CreatePasswordResetHmacCode(viewModel.MemberId);

            var link = "<a href='"
                        + Request.Url.Scheme + "://"
                        + Request.Url.Authority
                        + @Url.Action("CheckMemberUrl", "Mail", new { forgotpw = outputCode })
                        + "'>Click here to reset your password</a>";

            mailVM.receiver = viewModel.MemberRegEmail;
            mailVM.sender = "11@a.com";
            mailVM.MailTitle = "test";
            mailVM.MailBody = link;
            string id = WebConfigurationManager.AppSettings["GmailId"];
            string password = WebConfigurationManager.AppSettings["GmailPassword"];
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(id, password),
                EnableSsl = true
            };
            client.Send(mailVM.sender, mailVM.receiver, mailVM.MailTitle, mailVM.MailBody);
            return RedirectToAction("FinishedSending", "Member");
        }


        public ActionResult CheckMemberUrl(string forgotpw)
        {
            if (!VerifyPasswordResetHmacCode(forgotpw, out Int32 userId))
            {
                // Message is invalid, such as the HMAC hash being incorrect, or the code has expired.
                return null;
            }

            return View();

        }

        public String ResetPassword(EditMemberViewModel input)
        {

            //if (!VerifyPasswordResetHmacCode(input., out Int32 userId))
            //{
            //    return null;
            //}

            var result = new OperationResult();
            result = _memberService.ResetPassWord(input);
            if (result.IsSuccessful)
            {
                _memberService.Relogin();
                return "成功";
            }
            else
            {
                Log entity = new Log()
                {
                    //Path = result.WriteLog(HostingEnvironment.MapPath("~/Assets/Log/")),
                    DateTime = result.DateTime
                };
                _logservice.Create(entity);
                return "失敗";
            }
        }

        public String CreatePasswordResetHmacCode(Int32 userId)
        {
            Byte[] message = Enumerable.Empty<Byte>()
            .Append(_version)
            .Concat(BitConverter.GetBytes(userId))
            .Concat(BitConverter.GetBytes(DateTime.UtcNow.ToBinary()))
            .ToArray();

            using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey))
            {
                Byte[] hash = hmacSha256.ComputeHash(buffer: message, offset: 0, count: message.Length);

                Byte[] outputMessage = message.Concat(hash).ToArray();
                String outputCodeB64 = Convert.ToBase64String(outputMessage);
                String outputCode = outputCodeB64.Replace('+', '-').Replace('/', '_');
                return outputCode;
            }
        }

        public static Boolean VerifyPasswordResetHmacCode(String codeBase64Url, out Int32 userId)
        {
            String base64 = codeBase64Url.Replace('-', '+').Replace('_', '/');
            Byte[] message = Convert.FromBase64String(base64);

            Byte version = message[0];
            if (version < _version)
            {
                userId = 0;
                return false;
            }

            userId = BitConverter.ToInt32(message, 1);
            Int64 createdUtcBinary = BitConverter.ToInt64(message, 1 + sizeof(Int32));

            DateTime createdUtc = DateTime.FromBinary(createdUtcBinary);
            if (createdUtc.Add(_passwordResetExpiry) < DateTime.UtcNow) return false;

            const Int32 _messageLength = 1 + sizeof(Int32) + sizeof(Int64);

            using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey))
            {
                Byte[] hash = hmacSha256.ComputeHash(message, offset: 0, count: _messageLength);

                Byte[] messageHash = message.Skip(_messageLength).ToArray();
                return Enumerable.SequenceEqual(hash, messageHash);
            }
        }




    }
}