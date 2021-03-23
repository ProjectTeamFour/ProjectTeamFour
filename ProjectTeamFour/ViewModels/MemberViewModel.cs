using ProjectTeamFour.ViewModels.ForMemberView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ProjectTeamFour.ViewModels
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        [Display(Name = "顯示名稱")]
        public string MemberName { get; set; }
        public string MemberTeamName { get; set; }
        public string MemberAccount { get; set; }
        
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string MemberPassword { get; set; }
        [Display(Name = "連絡地址")]
        public string MemberAddress { get; set; }
        [Display(Name ="連絡電話")]
        public string MemberPhone { get; set; }
        [Required]
        [Display(Name = "註冊信箱")]
        [DataType(DataType.EmailAddress)]
        public string MemberRegEmail { get; set; }
        [Required]
        [Display(Name = "聯絡信箱")]
        [DataType(DataType.EmailAddress)]
        public string MemberConEmail { get; set; }
        [Display(Name ="性別")]
        public string Gender { get; set; }
        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MemberBirth { get; set; }
        [Display(Name = "關於我")]
        [DataType(DataType.Text)]
        public string AboutMe { get; set; }
        [Display(Name = "大頭照")]
        public string ProfileImgUrl { get; set; }
        [Display(Name = "個人網站")]
        [DataType(DataType.Url)]
        public string MemberWebsite { get; set; }
        [Display(Name = "聯絡訊息")]
        public string MemberMessage { get; set; }
        public int Permission { get; set; }
        public string ResetPasswordCode { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        public BackingRecordsViewModel Records { get; set; }
        public List<SubmissionProcessViewModel> ProjectRecords { get; set; }
        public List<SubmissionProcessPlanViewModel> PlanRecords { get; set; }
        public List<MyProjectViewModel> MyProjects { get; set; }
        public List<CommentForMemberViewModel> Comments { get; set; }
    }
}