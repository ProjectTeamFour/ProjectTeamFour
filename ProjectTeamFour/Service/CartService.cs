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

        public CartItemViewModel QueryByPlanId(int Id)
        {
            var plan = repository.GetAll<Plan>().FirstOrDefault(X => X.PlanId == Id);
            

            if (plan == null)
            {
                return new CartItemViewModel();
            }

            var cartItem = new CartItemViewModel
            {
                PlanId = plan.PlanId,
                PlanUrl = plan.PlanImgUrl,
                Title = plan.PlanTitle,
                Price = plan.PlanPrice,

            };
            return cartItem;

        }

        public CartItemViewModel GetPlanById(int Id)
        {
            var plan = QueryByPlanId(Id);

            return plan;
        }


    }
}