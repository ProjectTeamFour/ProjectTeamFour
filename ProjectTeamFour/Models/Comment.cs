using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int AskedMemberId { get; set; }
        public string Comment_Question { get; set; }
        public DateTime Comment_Time { get; set; }
        public string Comment_Answer { get; set; }
        //導覽屬性
        public Member Member { get; set; }
        public Project Project { get; set; }
        public bool ReadStatus { get; set; }
    }
}