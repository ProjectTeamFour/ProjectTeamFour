using ProjectTeamFour.Models;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class CarCarPlanService
    {
        private DbContext _context;
        private BaseRepository _repository;

        public CarCarPlanService()
        {
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        //public CarCarPlanListViewModel GetByWhere(Expression<Func<Project, bool>> KeySelector)
        //{
        //    var planResult = _repository.GetAll<Plan>().Where(KeySelector);
        //    var planProject = new CarCarPlanListViewModel
        //    {
        //        CarCarPlanItems = new List<CarCarPlanViewModel>()
        //    };

        //    foreach(var item in planResult)
        //    {
        //        var planBox = new CarCarPlanViewModel
        //        {
        //            PlanImgUrl = item.PlanImgUrl,

        //        };
        //    }
        //    return planProject;
        //}

    }
}