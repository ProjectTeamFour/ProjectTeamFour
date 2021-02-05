using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        //public string Brief { get; set; }

        //public string Status { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal FundedAmount { get; set; }
        public int FundedPeople { get; set; }

        public bool ifSucceed { get; set; }

        public int CountDownDays { get; set; }
        public DateTime DeadLine { get; set; }

        public string CreatorName{ get; set; }
        public string CreatorLinkUrl { get; set; }

        public string ProjectContent { get; set; }

        //public List<string> FAQ { get; set; }
    }
}