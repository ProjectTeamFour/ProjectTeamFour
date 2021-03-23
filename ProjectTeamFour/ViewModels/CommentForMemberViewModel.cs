using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class CommentForMemberViewModel
    {
        public int CommentId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectMainUrl { get; set; }
        public int AskMemberId { get; set; }
        public int AskedMemberId { get; set; }
        public string AskedMemberName { get; set; }
        public string Comment_Question { get; set; }
        public DateTime Comment_Time { get; set; }
        public string Comment_Answer { get; set; }
        public bool ReadStatus { get; set; }
    }
}