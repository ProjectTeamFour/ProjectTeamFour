using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int AskedMemberId { get; set; }
        public string CommentQuestion { get; set; }
        public DateTime CommentTime { get; set; }
        public string CommentAnswer { get; set; }
        public bool ReadStatus { get; set; }

        public virtual Member Member { get; set; }
        public virtual Project Project { get; set; }
    }
}
