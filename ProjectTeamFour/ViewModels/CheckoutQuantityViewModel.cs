using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.ViewModels
{
    /// <summary>
    /// 此ViewModel專用於結帳前
    /// </summary>
    public class CheckoutQuantityViewModel
    {
        /// <summary>
        /// 專門接收前端傳入的商品數量陣列
        /// </summary>
        public List<int> Quantity { get; set; }
        /// <summary>
        /// 專門接收前端傳入的留言
        /// </summary>
        public string Comment { get; set; }
    }
}