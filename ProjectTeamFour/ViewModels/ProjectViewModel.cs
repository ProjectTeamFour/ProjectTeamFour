using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectMainUrl { get; set; }
        public string Category { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectName { get; set; }
        public string CreatorName { get; set; }
        public decimal FundingAmount { get; set; }
        public decimal AmountThreshold { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan dateLine { get; set; }
        public int Fundedpeople { get; set; }        
    }
}