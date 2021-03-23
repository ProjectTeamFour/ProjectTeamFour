using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class EditMemberViewModel
    {
        [Key]
        public int MemberId { get; set; }

        [Display(Name = "大頭照")]
        public string ProfileImgUrl { get; set; }

        [Display(Name = "註冊信箱")]
        [DataType(DataType.EmailAddress)]
        public string MemberRegEmail { get; set; }

        [Display(Name = "聯絡信箱")]
        [DataType(DataType.EmailAddress)]
        public string MemberConEmail { get; set; }

        [Required]
        [Display(Name = "性別")]
        public string Gender { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime MemberBirth { get; set; }

        [Display(Name = "關於我")]
        [DataType(DataType.Text)]
        public string AboutMe { get; set; }

        [Display(Name = "顯示名稱")]
        public string MemberName { get; set; }

        [Display(Name = "個人網站")]
        [DataType(DataType.Url)]
        public string MemberWebsite { get; set; }
        public int Permission { get; set; }
        public string MemberPassword { get; set; }
        public string MemberMessage { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}