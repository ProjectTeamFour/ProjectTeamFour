using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class ProjectContext:DbContext
    {
        public ProjectContext() : base("ProjectContext")
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}