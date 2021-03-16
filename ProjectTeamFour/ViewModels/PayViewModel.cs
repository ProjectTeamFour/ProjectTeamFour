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

        public int OrderId { get; set; }
        //public int MemberId { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderPhone { get; set; }
        public string OrderConEmail { get; set; }
        public decimal OrderTotalAccount { get; set; }
        public string TradeNo { get; set; } //綠界的交易編號
        public int RtnCode { get; set; } //交易狀態

        //------------Order----------------------------------------

        public List<OrderDetail> OrderItems { get; set; } //訂單

        //-------------Plan--------------------------------------------
        public List<CarCarPlanViewModel> CartItems { get; set; }

        public decimal TotalAccount
        {
            get
            {
                decimal totalAccount = 0m;
                if(CartItems!=null)
                {
                    foreach (var item in CartItems)
                    {
                        totalAccount = totalAccount + item.Account;
                    }
                    return totalAccount;
                }
                return 0m;
            }
        }
    }
}