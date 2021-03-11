using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class BackingViewModel
    {

        //--------------Order-Detail---------------------------- //取得會員資料
        //public int OrderId { get; set; }
        public int MemberId { get; set; }
        public string OrderName { get; set; }

        //public decimal OrderTotalAccount { get; set; }
        //public string TradeNo { get; set; } //綠界金流編號
        //public int RtnCode { get; set; } //交易狀態

        
        //-------------Order 確定需要的欄位-------------------

        public int OrderId { get; set; }

        public decimal OrderTotalAccount { get; set; } //該次贊助總金額

        public string TradeNo { get; set; } //綠界金流編號

        public bool ReceivedStatus { get; set; } //有無收到?

        // Project
        public int ProjectId { get; set; } //贊助專案
        public string ProjectName { get; set; } //贊助專案

        //Plan 
        public int PlanId { get; set; }
        public string PlanTitle { get; set; }

        
        
    }
}