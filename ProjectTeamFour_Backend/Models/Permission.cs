using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTeamFour_Backend.Models
{
    public partial class Permission
    {
        public int PermissionId { get; set; }
        public string CountrollerName { get; set; }
        public string ActionName { get; set; }
        public int PermissionValue { get; set; }
    }
}
