using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Member
    {
        /// <summary>
        /// 會員唯一識別碼
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 提案者真實姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 提案團隊顯示姓名
        /// </summary>
        public string MemberTeamName { get; set; }
        /// <summary>
        /// 暫棄
        /// </summary>
        public string MemberAccount { get; set; }
        /// <summary>
        /// 會員密碼
        /// </summary>
        public string MemberPassword { get; set; }
        /// <summary>
        /// 會員註冊地址
        /// </summary>
        public string MemberAddress { get; set; }
        /// <summary>
        /// 會員註冊電話
        /// </summary>
        public string MemberPhone { get; set; }
        /// <summary>
        /// 會員註冊信箱
        /// </summary>
        public string MemberRegEmail { get; set; }
        /// <summary>
        /// 會員聯絡信箱
        /// </summary>
        public string MemberConEmail { get; set; }
        /// <summary>
        /// 會員性別
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 會員生日
        /// </summary>
        public DateTime MemberBirth { get; set; }
        /// <summary>
        /// 會員關於我
        /// </summary>
        public string AboutMe { get; set; }
        /// <summary>
        /// 會員關於我照片
        /// </summary>
        public string ProfileImgUrl { get; set; }
        /// <summary>
        /// 會員網站連結
        /// </summary>
        public string MemberWebsite { get; set; }

        public string MemberMessage { get; set; }
        public int Permission { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string ResetPasswordCode { get; set; }


        //Navigation Property 導覽屬性
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<DraftProject> DraftProjects { get; set; }

    }
}