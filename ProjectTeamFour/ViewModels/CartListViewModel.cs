using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    public class CartListViewModel
    {
        public CartListViewModel()
        {
            this.CartItems = new List<CartItemViewModel>();
        }

        public  List<CartItemViewModel> CartItems{ get;set;}

       

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