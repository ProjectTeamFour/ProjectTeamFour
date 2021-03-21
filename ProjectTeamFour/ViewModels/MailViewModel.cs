using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class MailViewModel
    {
        public string sender { get; set; }
        public string receiver { get; set; }
        public string MailTitle { get; set; }
        public string MailBody { get; set; }

    }
}