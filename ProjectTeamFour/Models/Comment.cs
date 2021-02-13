using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MemberId { get; set; }
        public string Comment_Question { get; set; }
        public DateTime Comment_Time { get; set; }
        public string Comment_Answer { get; set; }
        //導覽屬性
        public Member Member { get; set; }
        public Project Project { get; set; }
    }
}