using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.ViewModels
{
    public class MyProjectViewModel
    {
        //private DateTime _today;
        //private double _dateline;
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCoverUrl { get; set; }
        public decimal GoalMoney { get; set; }  //AmountThreshold
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        //public bool SubmitStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastEditTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubmittedDate { get; set; }

        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        //確認要不要用enum
        public string ProjectStatus { get; set; }
        //0為審核中,1為募資中,2為募資成功上架中,3為募資失敗
        public int ApprovingStatus { get; set; }
        //0為尚未提交,1為募資中,2為募資成功上架中,3為結束關閉的專案

        //[ForeignKey("MemberId")]

        public string Category { get; set; }
        public string CreatorName { get; set; }
        public decimal FundingAmount { get; set; }      //price
        public int Fundedpeople { get; set; }    //people

        
        public int SubmitLimit { get; set; }
        public List<CarCarPlanViewModel>MyPlan{ get; set; }

        //public List<CarCarPlanViewModel> plan { get; set; }

        //public TimeSpan DateLine { get; set; }

        //        public DateTime Today
        //        {
        //            get
        //            {
        //                return _today;
        //            }
        //            set
        //            {
        //                _today = DateTime.Now();
        //            }
        //        }

        //        public int DateLine{
        //            get{
        //                return _dateline;
        //                }
        //    set{
        //_dateline= new TimeSpan(EndDate.Ticks - Today.Ticks).TotalDays;
        //            }
        //                    }

    }

}