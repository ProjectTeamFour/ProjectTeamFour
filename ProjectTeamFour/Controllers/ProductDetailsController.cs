using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Summary()
        {
            
            return View();
        }

        public ActionResult ShowProjectContent()
        {
         
            //if(content==null)
            //{
            //    return new HttpNotFoundResult("沒有檔案!");
            //}
            //else
            //{
            //    content = ProductDetail.ProjectContent;
            //}
            return View(ProjectContent);
        }

        protected List<ProductDetail> ProjectContent = new List<ProductDetail>
        {
            new ProductDetail{Id=1, ProductName="開啟與孩子的第一場程式冒險 《解碼傳說 CO·DECODE》",CreatorName="Papacode-程式老爹",FundedPeople=828,GoalAmount=140113}
        };
    }
}