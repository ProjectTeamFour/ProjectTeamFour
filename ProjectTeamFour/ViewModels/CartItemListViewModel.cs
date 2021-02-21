using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class CartItemListViewModel
    {
        public CartItemListViewModel()
        {
            this.CartItems = new List<CarCarPlanViewModel>();
        }

        public  List<CarCarPlanViewModel> CartItems{ get;set;}

       

        public decimal TotalAccount { get 
            { 
                decimal totalAccount = 0.0m;

                foreach(var item in CartItems)
                {
                    totalAccount = totalAccount + item.Account;
                }
                return totalAccount;
            } }
    }
}