using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberTeamName { get; set; }
        public string MemberAccount { get; set; }
        public string MemberPassword { get; set; }
        public string MemberAddress { get; set; }
        public string MemberPhone { get; set; }
        public string MemberRegEmail { get; set; }
        public string MemberConEmail { get; set; }
        public string Gender { get; set; }
        public DateTime MemberBirth { get; set; }
        public string AboutMe { get; set; }
        public string ProfileImgUrl { get; set; }
        public string MemberWebsite { get; set; }
        public string MemberMessage { get; set; }
        //Navigation Property 導覽屬性
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}