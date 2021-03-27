using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Comment
    {
        /// <summary>
        /// CommentId專一識別碼
        /// </summary>
        public int CommentId { get; set; }
        /// <summary>
        /// ProjectId專一識別碼
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// MemberId專一識別碼
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 被留言MemberId
        /// </summary>
        public int AskedMemberId { get; set; }
        /// <summary>
        /// 留言內容
        /// </summary>
        public string Comment_Question { get; set; }
        /// <summary>
        /// 留言時間
        /// </summary>
        public DateTime Comment_Time { get; set; }
        /// <summary>
        /// 答覆內容
        /// </summary>
        public string Comment_Answer { get; set; }
        //導覽屬性
        public Member Member { get; set; }
        public Project Project { get; set; }
        /// <summary>
        /// 是否已回覆
        /// </summary>
        public bool ReadStatus { get; set; }
    }
}