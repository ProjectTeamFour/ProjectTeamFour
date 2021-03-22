using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class MailViewModel
    {
        public int MemberId { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string MailTitle { get; set; }
        public string MailBody { get; set; }
        public string ResetPasswordCode { get; set; }
        public string MemberRegEmail { get; set; }
        public string MemberPassword { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

    }
}