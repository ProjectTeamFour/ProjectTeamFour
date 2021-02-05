using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.Models;

namespace ProjectTeamFour.Controllers
{
    public class ProductDetailController : Controller
    {
        protected List<ProductDetail> productDetails = new List<ProductDetail>
        {
            new ProductDetail{ Id=1, ProductName="開啟與孩子的第一場程式冒險 《解碼傳說 CO·DECODE》",CreatorName="Papacode-程式老爹",Category="遊戲出版",FundedPeople=828,GoalAmount=140113,
                                FundedAmount=1609173},
            new ProductDetail{ Id=2,ProductName="Cheerpod 智慧滑鼠 | 一片在手,螢幕隨控",CreatorName="cheerdots TW",Category="科技設計",FundedPeople=5,GoalAmount=10000000},

        };


        // GET: ProductDetail
        public ActionResult Index()
        {
            //ViewData.Model = productDetails;
            //return View(productDetails);
            return View();
        }
        public ActionResult Summary()
        {

            return View();
        }

        //static void IfSucceed()
        //{
        //    foreach(var item in productDetails)
        //    {

        //    }
        //}

       
    }
}
