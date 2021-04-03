using System.Web;
using System.Web.Optimization;

namespace ProjectTeamFour
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/Plugin/JQuery/jquery_migrate1.2.1.min.js",
                        "~/Assets/Plugin/JQuery/jquery_dataTable.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"                        
                        ));
            bundles.Add(new StyleBundle("~/bundles/jquery").Include(
                        "~/Assets/Plugin/JQuery/jquery_datatable.css"
                        ));
            
            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assets/Plugin/JQuery/jquery_3.5.1.min.js",                      
                      "~/Assets/Plugin/Slick/slick_cdn1.8.1.min.js",
                      "~/Assets/Plugin/Popper.js/popper_cdn1.16.1.min.js",
                      "~/Assets/Plugin/Bootstrap/bootstrap_cdn4.6.0.min.js",
                      "~/Assets/HeaderFooterLayout/headerfooter.js",
                      "~/Assets/Plugin/Vue/Vue_cdn2.6.12.js"                      
                      ));
                      

            bundles.Add(new StyleBundle("~/Assets/css").Include(
                    "~/Assets/Plugin/FontAwesome/fontawesome-free-5.15.2-web/css/all.min.css",
                      "~/Assets/HeaderFooterLayout/headerfooter.css",
                      "~/Assets/Plugin/Bootstrap/bootstrap_cdn4.6.0.min.css", 
                      "~/Assets/Plugin/Normalize.css/normalize.css", 
                      "~/Assets/Plugin/Slick/slick_cdn1.8.1.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
