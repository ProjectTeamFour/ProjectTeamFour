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
        public MailsController(ILogger<MailsController> logger , IRepository repository,IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;
            _configuration = configuration;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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

                var queryResult = _repository.GetAll<Member>().FirstOrDefault(M => M.MemberConEmail == mailBaseSingleVM.MemberConEmail);

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
                  queryResult.MemberRegEmail, "集資車車 - 管理員通知"+ mailBaseSingleVM.MailTitle,
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

        public string getEmailData()
        {
            string returnData = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Template" + @"\\" + @"mailtemplate.html";

            if (path != null)
            {
                StreamReader streamReader = new StreamReader(path, Encoding.GetEncoding("Big5"));
                //轉字串給輸出
                returnData = streamReader.ReadToEnd();
            }
            return returnData;
        }


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
