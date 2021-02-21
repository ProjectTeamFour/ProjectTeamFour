using ProjectTeamFour.Service;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class ShoppingCartController : Controller
    {
        private CartService _CartService;
        public ShoppingCartController()
        {
            _CartService = new CartService();
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View("ListShoppingCart");
        }

        [HttpPost]
        public int AddtoCart(CarCarPlanViewModel carcarPlanVM)
        {
            var cartList = new CartItemListViewModel
            { CartItems = new List<CarCarPlanViewModel>() };


            if (Session["Cart"] == null)
            {
                var cart = new CarCarPlanViewModel
                {
                    CartId = 1,
                    PlanId = carcarPlanVM.PlanId,
                    PlanTitle = carcarPlanVM.PlanTitle,
                    PlanImgUrl = carcarPlanVM.PlanImgUrl,
                    PlanPrice = carcarPlanVM.PlanPrice,
                    Quantity = carcarPlanVM.Quantity,


                };
                cartList.CartItems.Add(cart);
                Session["Cart"] = cartList;
            }
            else
            {
                cartList = (CartItemListViewModel)Session["Cart"];

                //var cart = new CarCarPlanViewModel
                //{
                //    CartId = cartList.CartItems.Count() + 1,
                //    PlanId = carcarPlanVM.PlanId,
                //    PlanTitle = carcarPlanVM.PlanTitle,
                //    PlanImgUrl = carcarPlanVM.PlanImgUrl,
                //    PlanPrice = carcarPlanVM.PlanPrice,
                //    Quantity = carcarPlanVM.Quantity,


                //};
                //cartList.CartItems.Add(cart);
                var cartFiilter = _CartService.CheckId(cartList, carcarPlanVM);

                    Session["Cart"] = cartFiilter;
                
                
            }


            return cartList.CartItems.Count;
        }

        public ActionResult ListShoppingCart()
        {
            var carList = (CartItemListViewModel)Session["Cart"];

            return View(carList);
        }
    }
}