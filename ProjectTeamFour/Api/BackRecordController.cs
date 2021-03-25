using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.ViewModels.ForMemberView;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace ProjectTeamFour.Api
{
    public class BackRecordController : ApiController
    {
        private readonly BackingService _backingService;
        public BackRecordController(BackingService backService)
        {
            _backingService = new BackingService();
        }

        [HttpGet]
        public BackingRecordsViewModel GetOrderData([FromBody] MemberViewModel member)
        {
            var session = System.Web.HttpContext.Current.Session;

            member = (MemberViewModel)session["Member"];

            if (member != null)
            {
                //var memberInfo = _memberService.GetMember(m => m.MemberId == id);
                //根據會員id抓取會員購買紀錄
                member.Records = _backingService.QueryOrder(member.MemberId);
                return member.Records;
            }
            else
            {
                return null;
            }
        }
    }
}
