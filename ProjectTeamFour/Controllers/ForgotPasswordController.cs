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

       
        private static readonly TimeSpan _passwordResetExpiry = TimeSpan.FromMinutes(5); //限制5分鐘
        private static readonly Byte[] _privateKey = new HMACSHA256().Key; //做key
        private const Byte _version = 1;


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

        //找回密碼填email頁
        public ActionResult SendMail()
        {
            return View();
        }

        //找回密碼填email頁的post 送出email
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


        //送完email頁跳轉
        public ActionResult FinishedSending()
        {
            return View();
        }

        //使用者點連結進到這裡 check 對了返回 View
        public ActionResult CheckMemberUrl(string forgotpw)
        {
            if (!VerifyPasswordResetHmacCode(forgotpw, out Int32 userId))
            {
                // Message is invalid, such as the HMAC hash being incorrect, or the code has expired.
                return null;
            }

            return View();

        }


        // CheckMemberUrl View 重設密碼 post 傳入這裡  --input ajax要再處理
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



        //----------加密的東西 int 都先寫 int32 比較好換算理解

       // 做 Hmac金鑰雜湊 用 SHA256 包 memberId 和 時間 去做
        public String CreatePasswordResetHmacCode(Int32 userId)
        {
            Byte[] message = Enumerable.Empty<Byte>()
            .Append(_version) //加 1 個 int 也就是 4個byte 32bit
            .Concat(BitConverter.GetBytes(userId))  //Id  回傳4個byte 32bit
            .Concat(BitConverter.GetBytes(DateTime.UtcNow.ToBinary())) //Time 回傳8個byte 64bit  取國際標準時間就好
            .ToArray(); //byte => byte[]

            using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey))  //開始做 code
            {
                Byte[] hash = hmacSha256.ComputeHash(buffer: message, offset: 0, count: message.Length);  //buffer 材料 //offset 材料起始點 //count 材料使用長度 做出原始 hash
                Byte[] outputMessage = message.Concat(hash).ToArray(); //串在一起 增加複雜度
                String outputCodeB64 = Convert.ToBase64String(outputMessage); //轉 base64string  
                String outputCode = outputCodeB64.Replace('+', '-').Replace('/', '_');  //最後再一次增加複雜度 替換 + 和 /
                return outputCode;
            }
        }


        // 解碼
        public static Boolean VerifyPasswordResetHmacCode(String codeBase64Url, out Int32 userId)   //Id 原本被包在裡面 , 所以先用 out 不用初始化 , 在裡面咐值
        {
            String base64 = codeBase64Url.Replace('-', '+').Replace('_', '/');  //解最外層
            Byte[] messagePlusHash = Convert.FromBase64String(base64); //轉回 byte陣列 index 0 會是 1

            Byte version = messagePlusHash[0];    // 這裡做判斷，但 肯定 1 不會小於 1 所以我有點不懂一開始 append 1 和現在這件事的意義 //也許算是制定一個小規則增加解密難度 讓中間這裡開頭一定是1
            if (version < _version)
            {
                userId = 0;
                return false;
            }

            userId = BitConverter.ToInt32(messagePlusHash, 1); //拿id
            Int64 createdUtcBinary = BitConverter.ToInt64(messagePlusHash, 1 + sizeof(Int32));  //拿時間bit
             
            DateTime createdUtc = DateTime.FromBinary(createdUtcBinary);  //bit => 真正時間
            if (createdUtc.Add(_passwordResetExpiry) < DateTime.UtcNow)  //如果超過5分鐘就失效 
            {
                return false;
            }

            const Int32 _messageLength = 1 + sizeof(Int32) + sizeof(Int64);  //計算原本傳入的長度 32 32 64

            using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey)) 
            {
                Byte[] hash = hmacSha256.ComputeHash(messagePlusHash, offset: 0, count: _messageLength);   // 取前面 => 所以得到一開始作的時候的原始 hash
                Byte[] messageHash = messagePlusHash.Skip(_messageLength).ToArray(); // 這整串去掉原始message長度  => 會是得到傳進來的 hash
                return Enumerable.SequenceEqual(hash, messageHash);  //原始的 比對 傳進來的 一樣就是 true 
            }
        }




    }
}