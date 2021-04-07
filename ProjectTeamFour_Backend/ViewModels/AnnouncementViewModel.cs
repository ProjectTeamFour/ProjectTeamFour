using ProjectTeamFour_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class AnnouncementViewModel
    {
        public class AnnouncementVM
        {
            public int AnnouncementId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int MemberId { get; set; }
            public DateTime CreateTime { get; set; }
            public string CreateUser { get; set; }
            public DateTime EditTime { get; set; }
            public string EditUser { get; set; }
        }

        public class AnnouncementListResult
        {
            public List<AnnouncementSingleResult> MyAnnouncementList { get; set; }
        }
        public class AnnouncementSingleResult : AnnouncementVM
        {

        }

    }
    
}
