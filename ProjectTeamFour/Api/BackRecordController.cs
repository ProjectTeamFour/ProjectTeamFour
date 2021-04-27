using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System.Web.Mvc;
using System.Web;

namespace ProjectTeamFour.Api
{
    public class BackRecordController : ApiController
    {
        private BackingService _backingService;
        public BackRecordController()
        {
            _backingService = new BackingService();
        }

        public BackingRecordsViewModel GetOrder()
        {
            var session = HttpContext.Current.Session;
            var member = ((MemberViewModel)session["Member"]).MemberId;
            var data = _backingService.QueryOrder(member);

            return data;
        }
    }
}
