using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class CartService
    {
        private DbContext _ctx;

        private BaseRepository repository;

        public CartService()
        {
            _ctx = new ProjectContext();
            repository = new BaseRepository(_ctx);
        }

        public CarCarPlanViewModel QueryByPlanId(int Id)
        {
            var plan = repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == Id);
            

            if (plan == null)
            {
                return new CarCarPlanViewModel();
            }

            var cartItem = new CarCarPlanViewModel
            {
                PlanId = plan.PlanId,
                PlanTitle = plan.PlanTitle,
                PlanPrice=plan.PlanPrice,
                PlanImgUrl=plan.PlanImgUrl,
               
                Quantity=1
                
            };
            return cartItem;

        }

        public CarCarPlanViewModel GetPlanById(int Id)
        {
            var plan = QueryByPlanId(Id);

            return plan;
        }
        //
        public CartItemListViewModel CheckId(CartItemListViewModel cartItems, CarCarPlanViewModel carcarPlanVM)
        {
            

            var result = cartItems.CartItems.Where(x => x.PlanId == carcarPlanVM.PlanId).Select(x => x).FirstOrDefault();

            if(result == default(CarCarPlanViewModel))
            {
                var cart = new CarCarPlanViewModel
                {
                    CartId = cartItems.CartItems.Count() + 1,
                    PlanId = carcarPlanVM.PlanId,
                    PlanTitle = carcarPlanVM.PlanTitle,
                    PlanImgUrl = carcarPlanVM.PlanImgUrl,
                    PlanPrice = carcarPlanVM.PlanPrice,
                    Quantity = carcarPlanVM.Quantity,


                };
                cartItems.CartItems.Add(cart);
                return cartItems;
            }
            else
            {
               result.Quantity += 1;
                return cartItems;
            }
        }

        public CarCarPlanViewModel CreateANewCart(CarCarPlanViewModel CarCarPlanVM)
        {
            var cart = new CarCarPlanViewModel
            {
                CartId = 1,
                PlanId = CarCarPlanVM.PlanId,
                PlanTitle = CarCarPlanVM.PlanTitle,
                PlanImgUrl = CarCarPlanVM.PlanImgUrl,
                PlanPrice = CarCarPlanVM.PlanPrice,
                Quantity = CarCarPlanVM.Quantity,


            };

            return cart;
        }

        public CartItemListViewModel DeleteId(CartItemListViewModel cartItems, CarCarPlanViewModel carcarPlanVM)
        {


            var result = cartItems.CartItems.Where(x => x.PlanId == carcarPlanVM.PlanId).Select(x => x).FirstOrDefault();

            if (result == default(CarCarPlanViewModel))
            {
                
               
            }
            else
            {
                cartItems.CartItems.Remove(result);
            }
            return cartItems;
        }

        public CartItemListViewModel ClearCart(CartItemListViewModel cartItems)
        {
            cartItems.CartItems.Clear();
            
            return cartItems;
        }




    }
}