using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class CheckPermissionViewModel
    {
        public int MemberId { get; set; }
        public int PermissionId { get; set; }
        public bool Checked { get; set; }
    }
}