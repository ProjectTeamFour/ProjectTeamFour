using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Passward { get; set; }
        public string Name { get; set; }

        //public string ProfileImage { get; set; }
        public string Email { get; set; }
        
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        //public string AboutMe { get; set; }

        //public string ProfileUrl { get; set; }
        //public string Language { get; set; }
        //public bool Notifactions { get; set; }
    }
}