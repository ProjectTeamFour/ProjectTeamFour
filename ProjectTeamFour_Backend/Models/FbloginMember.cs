using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class FbloginMember
    {
        public int FbmemberId { get; set; }
        public string AuthResponseAccessToken { get; set; }
        public string AuthResponseUserId { get; set; }
        public int AuthResponseExpiresIn { get; set; }
        public string AuthResponseSocialPlatform { get; set; }
        public int OriginalMemberId { get; set; }
        public string GetMemberName { get; set; }
        public DateTime GetMemberBirth { get; set; }
        public string GetMemberEmail { get; set; }
        public int MemberId { get; set; }

        public virtual Member Fbmember { get; set; }
    }
}
