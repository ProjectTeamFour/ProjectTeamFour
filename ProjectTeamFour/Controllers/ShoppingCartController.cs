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


       

        [HttpPost]
        public int AddtoCart(CarCarPlanViewModel carcarPlanVM)
        {
            var cartList = new CartItemListViewModel
            { CartItems = new List<CarCarPlanViewModel>() };


            if (Session["Cart"] == null)
            {
                var cart = _CartService.CreateANewCart(carcarPlanVM);
                cartList.CartItems.Add(cart);
                Session["Cart"] = cartList;
            }
            else
            {
                cartList = (CartItemListViewModel)Session["Cart"];
                var cartFiilter = _CartService.CheckId(cartList, carcarPlanVM);

                    Session["Cart"] = cartFiilter;
                    
                
            }


            return cartList.CartItems.Count;
        }

        public ActionResult ListShoppingCart()
        {
            //還原Session
            var carList = (CartItemListViewModel)Session["Cart"];

            return View(carList);
        }

        [HttpPost]
        public ActionResult RemoveCartItem(CarCarPlanViewModel carcarPlanVM)
        {
            //還原Session
            var carList = (CartItemListViewModel)Session["Cart"];

            carList = _CartService.DeleteId(carList,carcarPlanVM);

            Session["Cart"] = carList;


            return View("ListShoppingCart");
        }

        [HttpPost]
        public ActionResult ClearCartItem()
        {
            //還原Session
            var carList = (CartItemListViewModel)Session["Cart"];

            carList = _CartService.ClearCart(carList);

            Session["Cart"] = carList;

            return View("ListShoppingCart");
        }

        [HttpPost]
        public ActionResult GetCheckoutQuantity(CheckoutQuantityViewModel QuantityArray)
        {
            var carList = (CartItemListViewModel)Session["Cart"];

            carList = _CartService.ChangeCartQuantity(carList, QuantityArray);

            Session["Cart"] = carList;

            return View("ListShoppingCart");
        }

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