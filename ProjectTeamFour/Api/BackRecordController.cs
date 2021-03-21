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
        public BackingRecordsViewModel GetOrderData()
        {
            //return _backingService.QueryOrder(id);

            return null;
        }
    }
}
