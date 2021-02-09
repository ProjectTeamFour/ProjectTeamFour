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
    }
}