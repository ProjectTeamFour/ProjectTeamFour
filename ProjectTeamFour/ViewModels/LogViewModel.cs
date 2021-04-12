using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class PersonInfoViewModel
    {
        public int LogId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
    }

    public class GoogleApiTokenInfo
    {
        public string Email { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Sub { get; set; }
        public string Picture { get; set; }
    }
}