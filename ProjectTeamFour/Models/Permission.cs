using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string CountrollerName { get; set; }
        public string ActionName { get; set; }
        public int PermissionValue { get; set; }
    }
}