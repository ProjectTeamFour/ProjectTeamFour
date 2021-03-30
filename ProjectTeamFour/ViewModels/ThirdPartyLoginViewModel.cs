using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class ThirdPartyLoginViewModel
    {
        public int FBId { get; set; }
        public string AuthResponseAccessToken { get; set; }
        public string AuthResponseUserId { get; set; }
        public int AuthResponseExpiresIn { get; set; }
        public string AuthResponseSocialPlatform { get; set; }


        public int OriginalMemberId { get; set; }


        public string GetMemberName { get; set; }
        public DateTime GetMemberBirth { get; set; }
        public string GetMemberEmail { get; set; }


    }

    public class SocialInfo
    {
        public string Email { get; set; }
        public string SocialPlatform { get; set; }
        public string ImgUrl { get; set; }
    }
}