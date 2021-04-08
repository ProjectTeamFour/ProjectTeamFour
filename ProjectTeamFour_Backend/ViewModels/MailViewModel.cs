using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamFour_Backend.ViewModels
{
    public class MailViewModel
    {
        public class MailBaseViewModel
        {
            public int MemberId { get; set; }
            
            public string sender { get; set; }
            public string receiver { get; set; }
            public string MailTitle { get; set; }
            public string MailBody { get; set; }
            public string ResetPasswordCode { get; set; }
            public string MemberRegEmail { get; set; }
            public string MemberConEmail { get; set; }
            public string MemberPassword { get; set; }
            public string Salt { get; set; }
            public string Hash { get; set; }
        }

        public class MailBaseListViewModel
        {
            public List<MailBaseSingleViewModel> mailBaseSingleViewModels { get; set; }
        }

        public class MailBaseSingleViewModel: MailBaseViewModel
        {

        }
    }
}
