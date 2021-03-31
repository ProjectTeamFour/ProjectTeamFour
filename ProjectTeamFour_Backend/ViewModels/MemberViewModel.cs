using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class MemberViewModel
    {
        public class MemberBaseViewModel
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
            public string MemberBirth { get; set; }
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
        }



        /// <summary>
        /// 取得多种商品模型
        /// </summary>
        public class MemberListResult
        {
            public List<MemberSingleResult> MemberList { get; set; }
        }

        /// <summary>
        /// 取得單一會員模型
        /// </summary>
        public class MemberSingleResult : MemberBaseViewModel
        {

        }
    }
}
