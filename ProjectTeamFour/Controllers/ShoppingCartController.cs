using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ProjectTeamFour.Controllers
{
    public class ShoppingCartController : Controller
    {
        private CartService _CartService;
        private MemberService _MemberService;
        public ShoppingCartController()
        {
            _CartService = new CartService();
            _MemberService = new MemberService();
        }



        /// <summary>
        /// 前端購物車功能(加入購物車)所呼叫的Action，傳入CarCarPlanViewModel(此Action皆沒有資料庫的資料處理)
        /// </summary>
        /// <param name="carcarPlanVM"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddtoCart(CarCarPlanViewModel carcarPlanVM)
        {
            var cartList = new CartItemListViewModel
            { CartItems = new List<CarCarPlanViewModel>() };

            ///若購物車為空，則初始化購物車，並放入Session["Cart"]
            if (Session["Cart"] == null)
            {
                var cart = _CartService.CreateANewCart(carcarPlanVM);
                cartList.CartItems.Add(cart);
                Session["Cart"] = cartList;
            }
            ///若購物車不為空，則購物車新增CarCarPlanViewModel
            else
            {
                cartList = (CartItemListViewModel)Session["Cart"];
                var cartFiilter = _CartService.CheckId(cartList, carcarPlanVM);

                    Session["Cart"] = cartFiilter;
                    
                
            }

            ///前端畫面顯示購物車內購物項目的數量。若有重複，則不重複計算
            return cartList.CartItems.Count;
        }
        /// <summary>
        /// 購物車頁面:將Session["Cart"]內的資料放入View中。該頁面以Vue為主，Razor語法為輔
        /// </summary>
        /// <returns></returns>
        public ActionResult ListShoppingCart()
        {
            //還原Session
            var carList = (CartItemListViewModel)Session["Cart"];

            
            
            return View(carList);
        }
        /// <summary>
        /// 前端觸發刪除該項商品之後，傳入CarCarPlanViewModel
        /// </summary>
        /// <param name="carcarPlanVM"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveCartItem(CarCarPlanViewModel carcarPlanVM)
        {
            //還原Session
            var carList = (CartItemListViewModel)Session["Cart"];

            carList = _CartService.DeleteId(carList,carcarPlanVM);

            Session["Cart"] = carList;


            return View("ListShoppingCart");
        }
        /// <summary>
        /// 專為前端AJAX呼叫的清空購物車功能
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ClearCartItem()
        {
            //還原Session
            var carList = (CartItemListViewModel)Session["Cart"];

            carList = _CartService.ClearCart(carList);

            Session["Cart"] = carList;

            return View("ListShoppingCart");
        }
        /// <summary>
        /// 傳入前端的數量陣列及留言，以CheckoutQuantityViewModel來接收
        /// </summary>
        /// <param name="QuantityArray"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCheckoutQuantity(CheckoutQuantityViewModel QuantityArray)
        {
            var carList = (CartItemListViewModel)Session["Cart"];
            ///此carList為更改數量後的狀態
            carList = _CartService.ChangeCartQuantity(carList, QuantityArray);

            Session["Cart"] = carList;

            return View("ListShoppingCart");
        }
        /// <summary>
        /// 確認使用者是否為登入狀態
        /// </summary>
        /// <returns></returns>
        public ActionResult PrepareToCheckout()
        {
            int result = _MemberService.ReturnLoginnerId();

            if(result==0)
            {
                return RedirectToAction("Login", "Member");
            }

            else
            {
                return RedirectToAction("Index", "Pay");
            }

           
        }


    }
}