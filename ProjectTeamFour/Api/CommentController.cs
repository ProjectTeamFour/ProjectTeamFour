using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjectTeamFour.Api
{
    public class CommentController : ApiController
    {

        [System.Web.Mvc.HttpPost]
        public  ActionResult UpdateComment([FromBody] CommentViewModel commentVM)
        {
            var session = System.Web.HttpContext.Current.Session;
            var memberId = (MemberViewModel)session["Member"];
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
            return null;
        }
    }
}
