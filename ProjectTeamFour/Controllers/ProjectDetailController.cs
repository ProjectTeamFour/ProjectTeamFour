using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Models;
using System.Net;
using ProjectTeamFour.Service;

namespace ProjectTeamFour.Controllers
{
    public class ProjectDetailController : Controller
    {
        private ProjectDetailService projectDetailService;

        public ProjectDetailController()
        {

        }


        //private ProjectContext db = new ProjectContext();

        // GET: ProductDetail
        public ActionResult Index()
        {
            ProjectDetailViewModel project = new ProjectDetailViewModel
            {
                Category = "科技設計",
                ProjectStatus = "集資中",
                ProjectName = "窩窩睏床墊｜從工廠到你家！你的第一張全方位好床墊",
                CreatorName = "窩窩睏",
                FundingAmount = 2053000m,
                Fundedpeople = 20,
                ProjectDescription = "",
                ProjectImgUrl = "https://i.imgur.com/KseRcyB.png,https://i.imgur.com/XoyHd8T.png,https://i.imgur.com/GK9q8iW.png,https://i.imgur.com/UfGDPix.png,https://i.imgur.com/CHtcrnu.png,https://i.imgur.com/5KodELQ.png,https://i.imgur.com/iTMb39E.png,https://i.imgur.com/KmYFz9v.gif,https://i.imgur.com/ALhvyjv.png,https://i.imgur.com/74YlEUe.png,https://i.imgur.com/4AN1ZPV.gif,https://i.imgur.com/IgVHTa3.png,https://i.imgur.com/meq8PUW.png,https://i.imgur.com/Fa5WYm5.png,https://i.imgur.com/dS488Qa.png,https://i.imgur.com/XzIcJW0.png,https://i.imgur.com/thG6VBH.png,https://i.imgur.com/r6dMTZL.gif,https://i.imgur.com/kZe7g6c.png,https://i.imgur.com/Dxd0ayK.png,https://i.imgur.com/P5QfjdC.png,https://i.imgur.com/V9aPqgJ.gif,https://i.imgur.com/AlEpL9c.png",
                ProjectVideoUrl = "https://www.youtube.com/embed/_AlH_WRj6Ak",
                AmountThreshold = 1000000,
                Project_Question = "窩窩睏床墊的結構有幾層？,與一般床墊清潔方式差異？有標準清洗方式？,床墊表層有防蟎的功能嗎？,彈力支撐泡棉會不會長年使用下來會壓縮變形？,窩窩睏床墊的四邊透氣泡膠邊框和市面上的床墊設計有什麼差別？,窩窩睏床墊的軟硬度？,是否有保固？以及保固範圍,如果我需要維修或是保固的服務，應該去哪裡尋求幫助？",
                Project_Answer = "一共有6層結構，每層都是精心計算的黃金比例，也是最貼心的人性化設計第1層可拆洗天絲™品牌萊賽爾纖維的表布舒適不悶熱，還有可拆洗設計 。第2層涼爽透氣親水棉層吸走悶熱不適，帶入乾爽空氣。​第3層高支撐泡綿柔軟卻不塌陷，溫柔包覆疲勞的身體。​第4層MIT 高碳鋼獨立筒 高耐震、不變形的高碳鋼獨立筒。第5層四邊泡膠透氣邊框增加床墊的穩定和支撐度。​第6層高支撐釋壓棉從頭到尾都透氣，進一步支撐重量。​,一般床墊清潔需要花大請請專業清潔公司處理，窩窩睏考量到消費者的生活習慣，尤其時有小小孩和毛小孩的家庭，特別設計了採用天絲™品牌萊賽爾纖維的可拆洗式涼感表布，即使沾染到污漬也能輕鬆拆洗，不但清洗變得更容易！更能抑制病菌及塵蟎孳生。,有的，窩窩睏採用天絲™品牌萊賽爾纖維作為可拆洗式的涼感表布，其特性做過吸濕及保濕度檢測，透過濕氣管理功能，有效吸收濕氣，因此不易形成細菌賴以生存的潮濕環境，因此不利細菌滋生，提供一個更加健康衛生的環境。,窩窩睏採用密度高達30，接近於記憶棉的泡綿，加上使用了2.0線徑MIT高碳鋼獨立筒彈簧，除了不易塌陷外，支撐效果與耐用度也比一般床墊好！但長時間睡在同一個位置，床墊的泡綿和彈簧也會些許彈性疲乏。建議固定每半年將床墊前後對調，給彈簧一點時間休息，床墊壽命會更長。,有些床墊會有床緣容易塌陷的問題，這是因為完全沒有使用邊框固定彈簧，好一點的會加入鋼條邊框，但躺坐時會有較為明顯的異物感。而窩窩睏所使用的「透氣泡膠邊框」與國際頂級名床相同，能大大增加位於床緣的穩定度就算翻身到床邊，也能睡得很安心，此外長輩以坐姿要從床邊站起時，也會輕鬆許多。,市面上許多床墊，總是只使用一個數字量表，表示整張床墊的軟硬度。軟、硬、適中就代表了一張床的躺感。​但窩窩睏的 #舒適層 和 #支撐層 卻是不同的軟硬度設計，用來放鬆皮膚與肌肉的舒適層是偏軟的，有著溫柔的包覆感，而用來支撐骨骼的支撐層，擇是軟硬適中的設計，能服貼支撐你的自然身形。窩窩睏床墊的好睡秘密​#窩窩睏舒適層（偏軟）​窩窩睏床墊的舒適層由 #涼爽透氣親水棉層 和 #高支撐泡綿 所組成。舒適層柔軟卻不塌陷，服貼不同身形、還有極具安全感的舒適包覆感 。還能吸走水氣 ，帶入乾爽空氣，床墊就像自帶空調一樣舒爽好睡。​#高碳鋼獨立筒 （軟硬適中）​軟硬適中的高碳鋼獨立筒，有絕佳的 #耐震性、#回彈力 和 #耐用度。窩窩睏更加碼進行支撐力測試，確保最高品質。高品質的材質，才能堅定有力的支撐身體重量，並且讓脊椎保持自然伸展，每晚睡眠都能好好療癒疲憊。​如此一來，躺在窩窩睏上，有舒適層的柔軟包覆感，讓折騰了一天的肌肉在舒適層上好好休息；同時高碳鋼獨立筒又能撐起全身的重量，保護筋骨不傷脊椎。窩窩睏的黃金比例，成就了一張完美的床墊。,窩窩睏募資計畫即將登上於集資車車募資平台募資會提供 100晚試睡計劃：從床墊送到家中的那天開始，有100天的時間可以試睡窩窩睏床墊。不滿意即可申請全額退費，並有專人協助回收床墊。也享有10年保固服務：只要是正常使用，獨立筒若有損壞，我 們將免費提供保固服務。,窩窩睏為了讓大家享有最實惠的價格就可以擁有一張全方位的好床墊，採用工廠直送頂級床墊的新模式，以打破傳統須經過層層中間商後，才能到消費者的家銷售模式只要線上跟我們預約就會派人提供保固服務唷！",
                EndDate = new DateTime(2021, 3, 11),
                StartDate = new DateTime(2021, 2, 1)

            };

            //ViewData.Model = productDetails;
            //return View(productDetails);
            return View(project);
        }
        public ActionResult Summary(ProjectDetailViewModel projectDetail)
        {
            //
            ProjectDetailViewModel vm = new ProjectDetailViewModel()
            {
                //ProjectName = projectDetail.ProjectName,
                //MemberName = input.Name,
                //MemberRegEmail = input.Email,
                //MemberPassword = input.Password,
                //MemberBirth = StringtoDate(input.BirthDay),
                //Gender = input.gender
            };

            //
            return View();
        }

        //public ActionResult Details(int? Id)
        //{
        //    Project project = db.Projects.Find(Id);
        //    if (Id==null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    if(project==null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        return View(project);
        //    }

        //}

        public ActionResult Details()
        {
            //List<Plan> plans = new List<Plan>()
            //{
            //    new Plan
            //    {
            //        ProjectId = 1,
            //        PlanId = 1,
            //        ProjectPlanId = 1,
            //        PlanTitle = "【台制 單人標準 1 張】",
            //        PlanDescription = "台制單人｜90 x 188 x 26 cm±1cm 原價 20,800 元(現省 9, 000元)► 免費搬運舊床墊至管理處或巷口► 全台灣寄送免運費(台灣本島)► 偏遠地區須加運費",
            //        PlanFundedPeople = 1,
            //        PlanShipDate = new DateTime(2021, 3, 29),
            //        PlanImgUrl = "https://i.imgur.com/dmoLRa1.png",
            //        PlanPrice = 11800m,
            //        QuantityLimit = 0
            //    }
            //};
            //return View(plans);
            //ProjectDetailViewModel plancards = new ProjectDetailViewModel()
            //{
            //    PlanCardItem = new List<SelectPlanListViewModel>()
            //    {
            //        new SelectPlanListViewModel()
            //        {
            //            PlanCardItems = new List<SelectPlanViewModel>()
            //            {
            //                new SelectPlanViewModel
            //                {
            //                ProjectId = 1,
            //                PlanId = 1,
            //                ProjectPlanId = 1,
            //                PlanTitle = "【台制 單人標準 1 張】",
            //                PlanDescription = "台制單人｜90 x 188 x 26 cm±1cm 原價 20,800 元(現省 9, 000元)► 免費搬運舊床墊至管理處或巷口► 全台灣寄送免運費(台灣本島)► 偏遠地區須加運費",
            //                PlanFundedPeople = 1,
            //                PlanShipDate = new DateTime(2021, 3, 29),
            //                PlanImgUrl = "https://i.imgur.com/dmoLRa1.png",
            //                PlanPrice = 11800m,
            //                QuantityLimit = 0
            //                },
            //                new SelectPlanViewModel{ProjectId=1,PlanTitle="【基礎方案，現省380元】",PlanPrice=1580,PlanFundedPeople=6,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP，帶給你一趟精彩絕倫的程式解謎故事！", PlanShipDate=new DateTime(2021, 5, 1)},
            //                new SelectPlanViewModel{ProjectId=2,PlanTitle="【2+1完整方案，現省490元】",PlanPrice=1820,PlanFundedPeople=88,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP＋額外收錄解碼手冊：內含額外的擴充APP挑戰，將解密40個程式關卡以及彩蛋，跟著老爹一起完整探索九大程式航道！", PlanShipDate=new DateTime(2021, 5, 1)},
            //                new SelectPlanViewModel{ProjectId=3,PlanTitle=" ",PlanPrice=3280,PlanFundedPeople=228,PlanDescription="完整收錄4大冒險故事＋250張獨特卡牌＋專屬遊戲APP，帶給你一趟精彩絕倫的程式解謎故事！", PlanShipDate=new DateTime(2021, 5, 1)},
            //                new SelectPlanViewModel{ProjectId=4,PlanTitle=" ",PlanPrice=3480,PlanFundedPeople=11,PlanDescription="額外收錄《Coding Ocean：海霸》以及四本藏寶圖擴充，把冦丁海洋全部一起帶回家！！！", PlanShipDate=new DateTime(2021, 5, 1)},
            //                new SelectPlanViewModel{ProjectId=5,PlanTitle=" ",PlanPrice=6800,PlanFundedPeople=3,PlanDescription="《解碼傳說 CO·DECODE》4組與4本完整大解析，揪團挑戰最佳方案！！", PlanShipDate=new DateTime(2021, 5, 1)},
            //                new SelectPlanViewModel{ProjectId=6,PlanTitle=" ",PlanPrice=16400,PlanFundedPeople=3,PlanDescription="《解碼傳說 CO·DECODE》10組與10本完整大解析，揪團挑戰最佳方案！！", PlanShipDate=new DateTime(2021, 5, 1)}
            //            }
            //        },
            //    }
            //};
            return View();
        }
    }
}
