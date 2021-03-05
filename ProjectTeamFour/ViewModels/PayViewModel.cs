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


        //--------------Order-Detail---------------------------- //會員資料

        public int OrderDetailId { get; set; }
        public string OrderDetailDes { get; set; }
        public int OrderId { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public int ProjectId { get; set; }
        public int PlanId { get; set; }
        public decimal OrderPrice { get; set; }
        public string OrderProjectName { get; set; }
        public int OrderQuantity { get; set; }

        //------------Order----------------------------------------

        public List<Order> OrderItems { get; set; } //訂單

        //-------------Plan--------------------------------------------
        public List<CarCarPlanViewModel> CartItems { get; set; }

        public decimal TotalAccount
        {
            get
            {
                decimal totalAccount = 0.0m;

                foreach (var item in CartItems)
                {
                    totalAccount = totalAccount + item.Account;
                }
                return totalAccount;
            }
        }
    }
}