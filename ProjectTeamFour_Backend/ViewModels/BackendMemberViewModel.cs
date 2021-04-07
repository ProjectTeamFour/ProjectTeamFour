using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class BackendMemberViewModel
    {
       public class BackendBaseViewModel
        {

            [Required]
            public int MemberId { get; set; }
            /// <summary>
            /// 後臺會員真實姓名
            /// </summary>
            public string MemberName { get; set; }
            /// <summary>
            /// 後臺會員顯示姓名
            /// </summary>
            public string MemberAccount { get; set; }
            /// <summary>
            /// 後臺會員密碼
            /// </summary>
            public string MemberPassword { get; set; }
            /// <summary>
            /// 後臺會員註冊地址
            /// </summary>
            public string MemberAddress { get; set; }
            /// <summary>
            /// 後臺會員註冊電話
            /// </summary>
            public string MemberPhone { get; set; }
            /// <summary>
            /// 後臺會員註冊信箱
            /// </summary>
            public string MemberRegEmail { get; set; }
            /// <summary>
            /// 後臺會員聯絡信箱
            /// </summary>
            public string MemberConEmail { get; set; }
            /// <summary>
            /// 後臺會員性別
            /// </summary>
            public string Gender { get; set; }
            /// <summary>
            /// 後臺會員生日
            /// </summary>
            public string MemberBirth { get; set; }
            /// <summary>
            /// 後臺會員權限:true為管理者；false為客服
            /// </summary>
            public bool BackendIdentity { get; set; }
            public string MemberMessage { get; set; }
        }

        public class BackendListResult
        {

            public List<BackendSingleResult> BackendMemberList { get; set; }
        }
        public class BackendSingleResult:BackendBaseViewModel
        {

        }
    }
}
