using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string Content { get; set; }
        public int MemberId { get; set; }
        [Display(Name = "建立時間")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "建立者")]
        public string CreateUser { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime EditTime { get; set; }

        [Display(Name = "編輯者")]
        public string EditUser { get; set; }

        public virtual Member Member { get; set; }

    }
}