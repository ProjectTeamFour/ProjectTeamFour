using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Pulisher { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
        public DateTime D_DateTime { get; set; }
        public decimal GoalMoney { get; set; }
        public decimal NowMoney { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}