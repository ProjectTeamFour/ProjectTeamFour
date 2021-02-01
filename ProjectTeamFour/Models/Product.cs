using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brief { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal FundedAnount { get; set; }
        public int Progress{ get; set; }
        public DateTime DeadLine { get; set; }
    }
}