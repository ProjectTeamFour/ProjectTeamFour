using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }

        //public string ProfileImage { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name = "性別")]
        public string Gender { get; set; }
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }
        //public string AboutMe { get; set; }

        //public string ProfileUrl { get; set; }
        //public string Language { get; set; }
        //public bool Notifactions { get; set; }
    }
}