using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly ILogger<MailsController> _logger;
        private readonly IRepository _repository;
        private readonly IConfiguration  _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MailsController(ILogger<MailsController> logger , IRepository repository, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _repository = repository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 傳入前端POST請求的內容mailBaseSingleVM，之後在資料庫內對比mailBaseSingleVM.MemberRegEmail，如無誤，則寄出信件
        /// </summary>
        /// <param name="mailBaseSingleVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseModel.BaseResult<MailViewModel.MailBaseSingleViewModel>>> SendMail([FromBody] MailViewModel.MailBaseSingleViewModel mailBaseSingleVM)
        {
            return await Task.Run(() =>
            {
                var result = new BaseModel.BaseResult<MailViewModel.MailBaseSingleViewModel>();

                _logger.LogWarning(2001, DateTime.Now.ToLongDateString() + "MailsController SendMail方法被呼叫");

                if (!ModelState.IsValid)
                {
                    result.Msg = "查無此Eamil";

                    result.IsSuccess = false;

                    return result;
                }

                var queryResult = _repository.GetAll<Member>().FirstOrDefault(M => M.MemberRegEmail == mailBaseSingleVM.MemberRegEmail);

                if (queryResult == default)
                {
                    result.Msg = "查無此Eamil";

                    result.IsSuccess = false;

                    return result;
                }


                //取Email template
                string returnData = getEmailData();

                //把該帶的資料塞進 template
                string finalReturnData = setReplacedEmailData(returnData, mailBaseSingleVM.MailBody, queryResult.MemberName);

                var msg = new MailMessage("raisebubu@gmail.com",
                  queryResult.MemberRegEmail, "集資車車 - 管理員通知："+ mailBaseSingleVM.MailTitle,
                  finalReturnData);

                msg.IsBodyHtml = true;

                string id = _configuration.GetValue<string>("Gmail:Id");
                string password = _configuration.GetValue<string>("Gmail:Password");

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(id, password),
                    EnableSsl = true,

                };
                //client.Send(mailVM.sender, mailVM.receiver, mailVM.MailTitle, mailVM.MailBody);
                client.Send(msg);

                result.Msg = mailBaseSingleVM.MailTitle + mailBaseSingleVM.MailBody;

                return result;
            });
            

        }
        /// <summary>
        /// 取得ProjectTeamFour\ProjectTeamFour_Backend\bin\Debug\net5.0\Template\mailtemplate.html檔案路徑。該檔案為信件樣板
        /// </summary>
        /// <returns></returns>
        public string getEmailData()
        {
            string returnData = "";
            //string path = _hostingEnvironment.ContentRootPath + @"\\Template"  + @"\\mailtemplate.html";
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Template", "mailtemplate.html" );

            if (path != null)
            {
                StreamReader streamReader = new StreamReader(path, Encoding.GetEncoding("Big5"));
                //轉字串給輸出
                returnData = streamReader.ReadToEnd();
            }
            return returnData;
        }

        /// <summary>
        /// 在信件樣板檔案mailtemplate.html中插入標題及內容
        /// </summary>
        /// <param name="returnData"></param>
        /// <param name="context"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public string setReplacedEmailData(string returnData, string context, string memberName)
        {

            //讀取信件範本
            returnData = getEmailData();

            //取代文字


            //returnData = Regex.Replace(returnData, "#name#", mailReplaceData.NameRecipient);


            returnData = Regex.Replace(returnData, "#link#", context);
            returnData = Regex.Replace(returnData, "#memberName#", memberName);
            //...無限向下增加

            return returnData;
        }
    }
}
