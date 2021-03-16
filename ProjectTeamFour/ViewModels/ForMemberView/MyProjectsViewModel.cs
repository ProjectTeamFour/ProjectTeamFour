using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.ViewModels
{
        public class MyProjectsViewModel
        {
            public int ProjectId { get;set; }
            public string ProjectName { get;set; }
            public DateTime CreatedDate { get;set; }
            public bool SubmitStatus { get;set; }
            public DateTime LastEditTime { get;set; }

            public int ProjectStatus { get; set; }
            //0為尚未提交,1為募資中,2為募資成功上架中,3為結束關閉的專案
        }

}