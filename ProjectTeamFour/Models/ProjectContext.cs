using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectTeamFour.Models
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=ProjectContext")
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProjectDetail> productDetails { get; set; }
        public DbSet<Member> Members { get; set; }

    }
}