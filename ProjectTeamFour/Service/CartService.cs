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
                PlanPrice = plan.PlanPrice,
                PlanImgUrl = plan.PlanImgUrl,
                Quantity = 1

            };
            return cartItem;

        }

        public CarCarPlanViewModel GetPlanById(int Id)
        {
            var plan = QueryByPlanId(Id);

            return plan;
        }
        
        /// <summary>
        /// 查看購物車內是否有重複方案:若有，則方案數量+1;若無，購物車新增一筆方案
        /// </summary>
        /// <param name="cartItems"></param>
        /// <param name="carcarPlanVM"></param>
        /// <returns></returns>
        public CartItemListViewModel CheckId(CartItemListViewModel cartItems, CarCarPlanViewModel carcarPlanVM)
        {
            

            var result = cartItems.CartItems.Where(x => x.PlanId == carcarPlanVM.PlanId).Select(x => x).FirstOrDefault();
            ///若沒有找到相同項目，則新增一個項目
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
                    QuantityLimit=carcarPlanVM.QuantityLimit,
                    ProjectId=carcarPlanVM.ProjectId

                };
                cartItems.CartItems.Add(cart);
                return cartItems;
            }
            //若有找到相同項目，則該項目數量+1
            else
            {
               result.Quantity += 1;
               return cartItems;
            }
        }
        /// <summary>
        /// 購物車新增一筆方案
        /// </summary>
        /// <param name="CarCarPlanVM"></param>
        /// <returns></returns>
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
                QuantityLimit=CarCarPlanVM.QuantityLimit,
                ProjectId=CarCarPlanVM.ProjectId

            };

            return cart;
        }


        /// <summary>
        /// 此方法為刪除購物車內某一商品:cartItems為目前購物車內容，carcarPlanVM則為欲刪除項目
        /// </summary>
        /// <param name="cartItems"></param>
        /// <param name="carcarPlanVM"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 清空購物車功能
        /// </summary>
        /// <param name="cartItems"></param>
        /// <returns></returns>
        public CartItemListViewModel ClearCart(CartItemListViewModel cartItems)
        {
            cartItems.CartItems.Clear();
            
            return cartItems;
        }
        /// <summary>
        /// cartItems為購物車內容，QuantityArray則為前端傳入的數量陣列及留言內容
        /// </summary>
        /// <param name="cartItems"></param>
        /// <param name="QuantityArray"></param>
        /// <returns></returns>
        public CartItemListViewModel ChangeCartQuantity(CartItemListViewModel cartItems, CheckoutQuantityViewModel QuantityArray)
        {
            if(QuantityArray==null)
            {
                return cartItems;
            }
            else
            {
                
                for(int i=0;i<QuantityArray.Quantity.Count;i++)
                {
                    ///第一項商品的購買數量等於數量陣列的第一項
                    cartItems.CartItems[i].Quantity = QuantityArray.Quantity[i];
                    ///如果商品購買數量大於庫存，則購買數量等於庫存
                    if (cartItems.CartItems[i].Quantity> cartItems.CartItems[i].QuantityLimit)
                    {
                        cartItems.CartItems[i].Quantity = cartItems.CartItems[i].QuantityLimit;
                    }
                    
                    
                }
                cartItems.Comment = QuantityArray.Comment;
                ///初始化記錄數量的陣列
                QuantityArray.Quantity.Clear();
                return cartItems;
            }
            
            
            
        }




    }
}