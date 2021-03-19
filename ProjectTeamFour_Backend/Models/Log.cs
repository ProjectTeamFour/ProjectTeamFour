using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
    }
}
