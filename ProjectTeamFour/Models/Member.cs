using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        //提案者真實姓名
        public string MemberName { get; set; }
        //提案顯示姓名
        public string MemberTeamName { get; set; }
        //這裡到時候可以作為儲存第三方登入帳號的資料
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
        public int Permission { get; set; }

        //Navigation Property 導覽屬性
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}