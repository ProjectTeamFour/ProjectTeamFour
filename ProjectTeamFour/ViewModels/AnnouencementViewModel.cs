using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class AnnouncementViewModel
    {
        public int AnnouncementId { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditTime { get; set; }
        public string EditUser { get; set; }
    }
}