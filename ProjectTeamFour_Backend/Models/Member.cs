using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Member
    {
        public Member()
        {
            Announcements = new HashSet<Announcement>();
            Comments = new HashSet<Comment>();
            DraftProjects = new HashSet<DraftProject>();
            Orders = new HashSet<Order>();
        }

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
        public int? Permission { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string ResetPasswordCode { get; set; }
        public string IsThirdParty { get; set; }

        public virtual FbloginMember FbloginMember { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<DraftProject> DraftProjects { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
