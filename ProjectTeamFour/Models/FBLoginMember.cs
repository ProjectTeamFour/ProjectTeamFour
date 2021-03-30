using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class FBLoginMember
    {
        [Key]
        public int FBMemberId { get; set; }
        public string AuthResponseAccessToken { get; set; }
        public string AuthResponseUserId { get; set; }
        public int AuthResponseExpiresIn { get; set; }
        public string AuthResponseSocialPlatform { get; set; }

        
        public int OriginalMemberId { get; set; }


        public string GetMemberName { get; set; }
        public DateTime GetMemberBirth { get; set; }
        public string GetMemberEmail { get; set; }

        
        public int MemberId { get; set; }
        [Required]
        public virtual Member Member { get; set; }
    }
}