using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    /// <summary>
    /// 購物車ViewModel
    /// </summary>
    public class CartItemListViewModel
    {
        public CartItemListViewModel()
        {
            this.CartItems = new List<CarCarPlanViewModel>();
        }
        /// <summary>
        /// 購物車內的商品方案項目
        /// </summary>
        public  List<CarCarPlanViewModel> CartItems{ get;set;}
        /// <summary>
        /// 購物車留言功能
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 購物車內所有商品的總金額
        /// </summary>

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