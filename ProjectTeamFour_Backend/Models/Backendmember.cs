using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Backendmember
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberAccount { get; set; }
        public string MemberPassword { get; set; }
        public string MemberAddress { get; set; }
        public string MemberPhone { get; set; }
        public string MemberRegEmail { get; set; }
        public string MemberConEmail { get; set; }
        public string Gender { get; set; }
        public DateTime MemberBirth { get; set; }
        public DateTime LoginTime { get; set; }
        public bool BackendIdentity { get; set; }
        public string MemberMessage { get; set; }
        public int? Permission { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string ResetPasswordCode { get; set; }
    }
}
