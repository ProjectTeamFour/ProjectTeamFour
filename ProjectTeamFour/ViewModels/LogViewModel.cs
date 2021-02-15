using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class LogViewModel
    {
        public int LogId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }

    }
}