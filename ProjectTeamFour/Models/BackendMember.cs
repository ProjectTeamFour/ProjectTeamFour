using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class BackendMember
    {
        public int BackendMemberId { get; set; }
        /// <summary>
        /// 後臺會員真實姓名
        /// </summary>
        public string BackendMemberName { get; set; }
        /// <summary>
        /// 後臺會員顯示姓名
        /// </summary>
        public string BackendMemberAccount { get; set; }
        /// <summary>
        /// 後臺會員密碼
        /// </summary>
        public string BackendMemberPassword { get; set; }
        /// <summary>
        /// 後臺會員註冊地址
        /// </summary>
        public string BackendMemberAddress { get; set; }
        /// <summary>
        /// 後臺會員註冊電話
        /// </summary>
        public string BackendMemberPhone { get; set; }
        /// <summary>
        /// 後臺會員註冊信箱
        /// </summary>
        public string BackendMemberRegEmail { get; set; }
        /// <summary>
        /// 後臺會員聯絡信箱
        /// </summary>
        public string BackendMemberConEmail { get; set; }
        /// <summary>
        /// 後臺會員性別
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 後臺會員生日
        /// </summary>
        public DateTime BackendMemberBirth { get; set; }
        /// <summary>
        /// 後臺會員關於我
        /// </summary>
        public string AboutMe { get; set; }
        /// <summary>
        /// 後臺會員關於我照片
        /// </summary>
        public string ProfileImgUrl { get; set; }
        /// <summary>
        /// 後臺會員網站連結
        /// </summary>
        public string BackendMemberWebsite { get; set; }
        /// <summary>
        /// 後臺會員權限:true為管理者；false為客服
        /// </summary>
        public bool BackendIdentity { get; set; }
        public string BackendMemberMessage { get; set; }
        public int Permission { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string ResetPasswordCode { get; set; }
    }
}