using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectTeamFour.Models
{
    public class ProjectCategory
    {
        public int ProjectId { get; set; } //primary key
        public string Category { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectCoverUrl { get; set; }
        public string ProjectName { get; set; }
        public decimal FundingAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatorName { get; set; } //foreignKey

        //[ForeignKey("CreatorName")]
        //public virtual xxx CreatorName { get; set; }
    }
}