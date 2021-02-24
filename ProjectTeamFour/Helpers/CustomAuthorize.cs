using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ProjectTeamFour.Helpers
{
    public class CustomAuthorize:AuthorizeAttribute
    {
        public int flagNum { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            //判別是否驗證過
            if (httpContext.User.Identity.IsAuthenticated == false)
            {
                return false;
            }
            bool flag = false;
            HttpSessionStateBase session = httpContext.Session;
            if (session.Count > 0 && !string.IsNullOrEmpty(session["Permission"].ToString()))
            {
                string permissionsNum = Convert.ToString((int)session["Permission"], 2);
                string compareNum = Convert.ToString(flagNum, 2);
                if ((int)session["Permission"]>=flagNum&&permissionsNum[compareNum.Length - 1] == '1')
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}