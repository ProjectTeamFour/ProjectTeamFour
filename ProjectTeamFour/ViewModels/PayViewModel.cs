using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.ViewModels
{
    public class PayViewModel
    {
        //---------------Member------------------------------
        public int MemberId { get; set; } 
        public string MemberName { get; set; }        
        public string MemberAddress { get; set; }
        public string MemberPhone { get; set; }
        public string MemberConEmail { get; set; }


        //--------------Order-Detail----------------------------

        public int OrderDetailId { get; set; }
        public string OrderDetailDes { get; set; }
        public int OrderId { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }


        //------------Order----------------------------------------

        public List<Order> OrderItems { get; set; }

        //-------------Plan--------------------------------------------
        public List<SelectPlanViewModel> PlanCardItems { get; set; }

    }
}