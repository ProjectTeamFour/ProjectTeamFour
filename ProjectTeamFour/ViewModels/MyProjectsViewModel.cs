using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.ViewModels
{
    public class MyProjectsViewModel
    {
        public List<MyProject> MyProjectsList { get; set; }
        public List<OngoingProject> OngoingProjects { get; set; }
        public List<EditingProject> EditingProjects { get; set; }
        public List<EndedProject> EndedProjects { get; set; }
        

        public class OngoingProject
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public DateTime CreatedDate { get; set; }

            public DateTime SubmittedDate { get; set; }
            public DateTime LastEditTime { get; set; }
            public int ApprovingStatus { get; set; }
        }

        public class EditingProject
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public DateTime CreatedDate { get; set; }

            public DateTime SubmittedDate { get; set; }
            public DateTime LastEditTime { get; set; }
            public int ApprovingStatus { get; set; }
        }

        public class EndedProject
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public DateTime CreatedDate { get; set; }

            public DateTime SubmittedDate { get; set; }
            public DateTime LastEditTime { get; set; }
            public int ApprovingStatus { get; set; }
        }

        public class MyProject
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public DateTime CreatedDate { get; set; }

            public DateTime SubmittedDate { get; set; }
            public DateTime LastEditTime { get; set; }
            public int ApprovingStatus { get; set; }
            //0為尚未提交,1為募資中,2為募資成功上架中,3為結束關閉的專案
        }
    }
}