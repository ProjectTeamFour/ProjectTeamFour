using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectTeamFour.ViewModels
{
    public class ViewMembers
    {
        [Required(ErrorMessage ="姓名是必填")]
        public string Name { get; set; }
        public string Account { get; set; }
        [StringLength(5,ErrorMessage ="最多5個字")]
        public string PassWord { get; set; }
        public string PassWordConfirm { get; set; }
        public string Position { get; set; }
    }
}