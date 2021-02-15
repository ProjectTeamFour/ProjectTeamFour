using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateTime { get; set; }
        public string Path { get; set; }
    }
}