namespace ProjectTeamFour.Migrations
{
    using ProjectTeamFour.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectTeamFour.Models.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectTeamFour.Models.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //第一個提案
            context.Projects.AddOrUpdate((x) => x.ProjectId, new Project
            {
                ProjectId = 1,
                MemberId = 1,
                ProjectName = "窩窩睏床墊｜從工廠到你家！你的第一張全方位好床墊",
                Category = "科技設計",
                ProjectStatus = "集資中",
                StartDate = new DateTime(2021, 2, 1),
                EndDate = new DateTime(2021, 3, 11),
                Fundedpeople = 20,
                FundingAmount = 2053000m,
                AmountThreshold = 1000000m,
                CreatorName = "窩窩睏",
                ProjectMainUrl = "https://i.imgur.com/fEmjPny.png",//提案瀏覽頁的頁面照片
                ProjectCoverUrl = "https://i.imgur.com/LAEi48q.png",//提案詳細頁的影片覆蓋照片
                ProjectDescription = "",
                ProjectImgUrl = "https://i.imgur.com/KseRcyB.png,https://i.imgur.com/XoyHd8T.png,https://i.imgur.com/GK9q8iW.png,https://i.imgur.com/UfGDPix.png,https://i.imgur.com/CHtcrnu.png,https://i.imgur.com/5KodELQ.png,https://i.imgur.com/iTMb39E.png,https://i.imgur.com/KmYFz9v.gif,https://i.imgur.com/ALhvyjv.png,https://i.imgur.com/74YlEUe.png,https://i.imgur.com/4AN1ZPV.gif,https://i.imgur.com/IgVHTa3.png,https://i.imgur.com/meq8PUW.png,https://i.imgur.com/Fa5WYm5.png,https://i.imgur.com/dS488Qa.png,https://i.imgur.com/XzIcJW0.png,https://i.imgur.com/thG6VBH.png,https://i.imgur.com/r6dMTZL.gif,https://i.imgur.com/kZe7g6c.png,https://i.imgur.com/Dxd0ayK.png,https://i.imgur.com/P5QfjdC.png,https://i.imgur.com/V9aPqgJ.gif,https://i.imgur.com/AlEpL9c.png",
                ProjectVideoUrl = "https://www.youtube.com/watch?v=_AlH_WRj6Ak",
                Project_Question = "窩窩睏床墊的結構有幾層？,與一般床墊清潔方式差異？有標準清洗方式？,床墊表層有防蟎的功能嗎？,彈力支撐泡棉會不會長年使用下來會壓縮變形？,窩窩睏床墊的四邊透氣泡膠邊框和市面上的床墊設計有什麼差別？,窩窩睏床墊的軟硬度？,是否有保固？以及保固範圍,如果我需要維修或是保固的服務，應該去哪裡尋求幫助？",
                Project_Answer = "一共有6層結構，每層都是精心計算的黃金比例，也是最貼心的人性化設計第1層可拆洗天絲™品牌萊賽爾纖維的表布舒適不悶熱，還有可拆洗設計 。第2層涼爽透氣親水棉層吸走悶熱不適，帶入乾爽空氣。​第3層高支撐泡綿柔軟卻不塌陷，溫柔包覆疲勞的身體。​第4層MIT 高碳鋼獨立筒 高耐震、不變形的高碳鋼獨立筒。第5層四邊泡膠透氣邊框增加床墊的穩定和支撐度。​第6層高支撐釋壓棉從頭到尾都透氣，進一步支撐重量。​,一般床墊清潔需要花大請請專業清潔公司處理，窩窩睏考量到消費者的生活習慣，尤其時有小小孩和毛小孩的家庭，特別設計了採用天絲™品牌萊賽爾纖維的可拆洗式涼感表布，即使沾染到污漬也能輕鬆拆洗，不但清洗變得更容易！更能抑制病菌及塵蟎孳生。,有的，窩窩睏採用天絲™品牌萊賽爾纖維作為可拆洗式的涼感表布，其特性做過吸濕及保濕度檢測，透過濕氣管理功能，有效吸收濕氣，因此不易形成細菌賴以生存的潮濕環境，因此不利細菌滋生，提供一個更加健康衛生的環境。,窩窩睏採用密度高達30，接近於記憶棉的泡綿，加上使用了2.0線徑MIT高碳鋼獨立筒彈簧，除了不易塌陷外，支撐效果與耐用度也比一般床墊好！但長時間睡在同一個位置，床墊的泡綿和彈簧也會些許彈性疲乏。建議固定每半年將床墊前後對調，給彈簧一點時間休息，床墊壽命會更長。,有些床墊會有床緣容易塌陷的問題，這是因為完全沒有使用邊框固定彈簧，好一點的會加入鋼條邊框，但躺坐時會有較為明顯的異物感。而窩窩睏所使用的「透氣泡膠邊框」與國際頂級名床相同，能大大增加位於床緣的穩定度就算翻身到床邊，也能睡得很安心，此外長輩以坐姿要從床邊站起時，也會輕鬆許多。,市面上許多床墊，總是只使用一個數字量表，表示整張床墊的軟硬度。軟、硬、適中就代表了一張床的躺感。​但窩窩睏的 #舒適層 和 #支撐層 卻是不同的軟硬度設計，用來放鬆皮膚與肌肉的舒適層是偏軟的，有著溫柔的包覆感，而用來支撐骨骼的支撐層，擇是軟硬適中的設計，能服貼支撐你的自然身形。窩窩睏床墊的好睡秘密​#窩窩睏舒適層（偏軟）​窩窩睏床墊的舒適層由 #涼爽透氣親水棉層 和 #高支撐泡綿 所組成。舒適層柔軟卻不塌陷，服貼不同身形、還有極具安全感的舒適包覆感 。還能吸走水氣 ，帶入乾爽空氣，床墊就像自帶空調一樣舒爽好睡。​#高碳鋼獨立筒 （軟硬適中）​軟硬適中的高碳鋼獨立筒，有絕佳的 #耐震性、#回彈力 和 #耐用度。窩窩睏更加碼進行支撐力測試，確保最高品質。高品質的材質，才能堅定有力的支撐身體重量，並且讓脊椎保持自然伸展，每晚睡眠都能好好療癒疲憊。​如此一來，躺在窩窩睏上，有舒適層的柔軟包覆感，讓折騰了一天的肌肉在舒適層上好好休息；同時高碳鋼獨立筒又能撐起全身的重量，保護筋骨不傷脊椎。窩窩睏的黃金比例，成就了一張完美的床墊。,窩窩睏募資計畫即將登上於集資車車募資平台募資會提供 100晚試睡計劃：從床墊送到家中的那天開始，有100天的時間可以試睡窩窩睏床墊。不滿意即可申請全額退費，並有專人協助回收床墊。也享有10年保固服務：只要是正常使用，獨立筒若有損壞，我 們將免費提供保固服務。,窩窩睏為了讓大家享有最實惠的價格就可以擁有一張全方位的好床墊，採用工廠直送頂級床墊的新模式，以打破傳統須經過層層中間商後，才能到消費者的家銷售模式只要線上跟我們預約就會派人提供保固服務唷！",
                ProjectPlansCount = 4


            });
            //第一個提案的會員資料
            context.Members.AddOrUpdate((x) => x.MemberId, new Member
            {
                MemberId=1,
                MemberAccount="NO1member",
                MemberPassword= "NO1memberPassword",
                MemberName= "窩窩睏",
                MemberAddress= "100台北市中正區重慶南路一段122號",
                MemberBirth=new DateTime(1980,1,1),
                MemberConEmail="1234@gmail.com",
                MemberRegEmail = "1234@gmail.com",
                MemberMessage="",
                MemberPhone="0935-123456",
                MemberTeamName = "窩窩睏",
                MemberWebsite= "https://www.facebook.com/%E7%AA%A9%E7%AA%A9%E7%9D%8F-WO-WO-COO-113398027184309",
                AboutMe= "窩窩睏的工廠成立將近50年， 曾為多家知名及國際品牌床墊代工。 以近50年職人經驗，精心計算床墊結構的黃金比例 ，用心挑選頂級用料，去除層層高額成本， 用最真實的價格，最誠懇的保證，守護全家大小的睡眠健康。 窩窩睏 你的第一張全方位萬元好床。",
                Gender="男",
                ProfileImgUrl= "https://i.imgur.com/LNPGyBE.jpg",
                
            });
            //第一個提案內的方案
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 1,
                PlanId = 1,
                ProjectPlanId = 1,
                PlanTitle = "【台制 單人標準 1 張】",
                PlanDescription = "台制單人｜90 x 188 x 26 cm±1cm 原價 20,800 元(現省 9, 000元)► 免費搬運舊床墊至管理處或巷口► 全台灣寄送免運費(台灣本島)► 偏遠地區須加運費",
                PlanFundedPeople = 1,
                PlanShipDate = new DateTime(2021, 3, 29),
                PlanImgUrl = "https://i.imgur.com/dmoLRa1.png",
                PlanePrice = 11800m,
                QuantityLimit = 0

            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 1,
                PlanId = 2,
                ProjectPlanId = 2,
                PlanTitle = "【台制 單人加大 1 張】",
                PlanDescription = "台制單人加大｜105 x 188 x 26 cm±1cm 原價 24,800 元(現省 12, 000元)► 免費搬運舊床墊至管理處或巷口► 全台灣寄送免運費(台灣本島)",
                PlanFundedPeople = 3,
                PlanShipDate = new DateTime(2021, 3, 29),
                PlanImgUrl = "https://i.imgur.com/eZ84taV.png",
                PlanePrice = 12800m,
                QuantityLimit = 0
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 1,
                PlanId = 3,
                ProjectPlanId = 3,
                PlanTitle = "【台制 雙人標準 1 張】",
                PlanDescription = "台制雙人｜150 x 188 x 26 cm±1cm 原價 29,800 元(現省 15,000元)► 免費搬運舊床墊至管理處或巷口► 全台灣寄送免運費(台灣本島)► 偏遠地區須加運費",
                PlanFundedPeople = 20,
                PlanShipDate = new DateTime(2021, 3, 29),
                PlanImgUrl = "https://i.imgur.com/eZ84taV.png",
                PlanePrice = 14800m,
                QuantityLimit = 0
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 1,
                PlanId = 4,
                ProjectPlanId = 4,
                PlanTitle = "【台制 雙人特大 1 張】",
                PlanDescription = "台制雙人特大｜180 x 210 x 26 cm±1cm 原價 41,800 元(現省 21,000元)► 免費搬運舊床墊至管理處或巷口► 全台灣寄送免運費(台灣本島)► 偏遠地區須加運費",
                PlanFundedPeople = 15,
                PlanShipDate = new DateTime(2021, 3, 29),
                PlanImgUrl = "https://i.imgur.com/eZ84taV.png",
                PlanePrice = 20800m,
                QuantityLimit = 0
            });
            //第二個提案
            context.Projects.AddOrUpdate((x) => x.ProjectId, new Project
            {
                ProjectId = 2,
                MemberId = 2,
                ProjectName = "不讓土地哭泣——預購手工木餐具・讓這片土地不受農藥污染",
                Category = "生活",
                ProjectStatus = "集資中",
                StartDate = new DateTime(2021, 2, 1),
                EndDate = new DateTime(2021, 3, 22),
                Fundedpeople = 46,
                FundingAmount = 105760m,
                AmountThreshold = 400000m,
                CreatorName = "魟魚與貓",
                ProjectMainUrl = "https://i.imgur.com/fY4fvf2.jpg",//提案瀏覽頁的頁面照片
                ProjectCoverUrl = "https://i.imgur.com/eCm2xgg.jpg",//提案詳細頁的影片覆蓋照片
                ProjectDescription = "  在苗栗獅潭山區中，有一片即將被種植生薑的土地。目前，它還保有純淨，並沒有化學農藥的污染， 我們想要讓它一直保持下去，不過現在，我們需要協助了！,【募資緣由】我們在2020年購買了這片將近1500坪的土地，準備開始夢想已久的自給自足生活。但，因為當初並沒有資金可以讓我們做整地，而原地主又提出幫我們免費整地，交換我們讓他種植生薑一年，對當時的我們來說，是一個很划算的交換。 但是，隨著搬進了我們在這片土地上搭建的小木屋後，漸漸察覺我們對於這片土地的熱愛原來如此濃厚。想到土地即將面對這樣無情的對待，心裡滿是不捨和難過，而且隨著我們搬遷過來的三隻貓咪，也有可能因為誤觸農藥而死亡，這一切都讓我們後悔著當初並沒有深思熟慮。考慮過再去申請貸款，但是如果加上原本購買土地所需支付的貸款，負擔會太過於沈重。原本對於已經沒有方法的我們來說只能放棄，眼睜睜地看著一切發生，但是募資的想法突然出現在我們的腦海裡面，也才發現，也許一切都還有機會。,【所需的資金】整地的費用，再加上我們與原本即將種植生薑的農人契作的種苗費用、種植人力費用、與其他雜支，保守預估大約至少需要40萬。又或者，如果屆時募資金額足夠，我們也考慮更改種植項目（須提出申請與更改費用），以更為自然的多種作物種植，來取代傳統的單一作物種植方式，讓土地注入更多元的生命，延續它應有的活力。,【回饋方案】我們會用自己手工製作的木餐具與木製品來進行回饋，作品完成後，會塗上數層的食用等級亞麻仁油與其製成的護木蠟，絕對安全無毒！,【聯絡我們】如果有任何的問題，也歡迎直接到我們的粉絲專頁詢問魟魚與貓，任何方面的問題我們都很樂意回答。有興趣的朋友，也可以持續關注我們的分享，也許能夠帶給您一些不同想法，去創作屬於自己獨特的生活。木製作品產地：台灣木材來源：美國、緬甸、台灣等。創作者：魟魚與貓（陳鍵輝）所有這些作品，都是我們用熱愛生命的活力去創作出來的，每一件作品都是我們生活中的剪影，是我們生命中的一部分，也期望可以成為您生命中的一小部分，而能在您的生活中，更添加一些美好。希望喜愛木製品、喜歡我們的生活、支持我們理念的朋友們，可以幫我們分享，或實際成為我們的贊助者，和我們一起成為這片土地的守護者之一。也許有天，您會有機會來到這片土地上，它一定會感受到您，並給予最大的歡迎。,【關於魟魚與貓】從都市移居鄉間，再從鄉間搬到了山上，一步一步，我們遵循著自己的內心，找到了方向與生活。在跌跌撞撞與悲喜交織的路途上，描繪出了那腦海中的夢想，雖然並不是一切都能如願，但有時換了角度，呈現的景色卻意外地更加美好。,【故事大綱】大家好，我是魟魚，與妻子貓一起帶著出生不久的女兒栗子，在台灣苗栗山區開始建造自己的家園，也開始了夢想，那年是2020年。這一切並不是一時的想法或衝動，而是在2013 - 2015年，我們一起在澳洲打工度假時所發芽的種子。在那邊我們看見了另一種生活與可能，也撇見了彼此內心深處渴望的一切。那段時間，我們在不同的農場碰觸了大自然，而祂以極其愉悅舒適的方式告知我們該何去何從，只是後來內心的掙扎與衝突就沒那麼容易應付。回台後，感受到文化與內心的衝擊，而靈魂也不再安靜無語。無法再過著朝九晚五的生活，木工便是詢問自己後得到的答案。開始一遍自學木工與農業一邊打工，體驗到了內心的狂喜，但同時卻也是生活最為困苦的時候，也多虧妻子的支持才能度過那最為艱苦的時期。,【轉捩點】2017年，開始了第一次的鄉村移居，住進台中太平山區幾十年沒人居住的土屋，興奮地著手了第一次的老屋整修，心靈無限滿足。同時，這一年我們的人生也有了非常重大的轉變，我們不再將動物視為食物或產品，徹底改變了我們的飲食，也解放了靈魂。2018年，再次移居苗栗鄉間，一樣是多年沒人居住的老屋，繼續累積著房屋整修的經驗，也用更多的農耕嘗試、更多的生活體驗、更多的內在思考，去慢慢丟棄了多餘的物品與既定觀念，放下更多的自我，去體驗更多的愛與慈悲，用更多不同的角度去看待出現身邊的人事物，相信一切的安排自有其道理。2019年，栗子來到我們身邊，完整了我們，讓我們體驗到圓滿的意義。2020年，找到了家園，感受到夢想成真的喜悅，也開始了自給自足的實踐，獨力建造自己的房子，夢境就這樣一一實現。現在，我們極其享受每一天的每分每秒，無法忍受彼此必須短暫分離的時刻，也無法接受任何時光的蹉跎。,【友善大地的生活】在這棟小屋裡，我們使用太陽能來提供電力，除了大瓦數的機具需要使用發電機來運作外，其餘生活與創作上的電力使用都供應無虞。而水則是利用雨水回收系統儲存在水塔裡面，也即將度過我們的第一個乾季，而水塔還有八分滿。當然，所有這一切都是必須先調整生活習慣，將不必要的消耗減到最低，紀錄與觀察能源使用量，進而去評估自己真正所需的一切。在我們的土地上看不見電線桿，也不用擔心電磁波過強的問題，對我們來說也是一個非常大且意外的收穫。,【學習簡單】你一定會好奇我們如何維持生活、賺取生活費，或者直接認定我們有著強力的後盾，或是已經賺夠了錢而提早退休；但是，只有真正認識我們，接觸我們的生活，才會知道原來生活可以非常簡單，金錢也絕非打造夢想的唯一途徑。當然，我們也還在學習當中，學習更進一步的自給自足、學習拋下更多我們認為必須擁有的非必要事物。,【感謝所有】我們並不是來享受大自然的一切，而是成為自然裡的一部分。不過度消耗資源、不污染土地，也不自以為是地認為人類是主宰萬物的主人，我們感謝與驚嘆大自然的運作與給予，神秘又令人敬畏！感謝來到我們身邊的人事物，讓我們成為我們現在的自己。",
                ProjectImgUrl = "https://i.imgur.com/7rins05h.jpg,https://i.imgur.com/4YWh6muh.jpg,https://i.imgur.com/Rw5euhuh.jpg,https://i.imgur.com/HS2ypXdh.jpg,https://i.imgur.com/zIWYmIVh.jpg,https://i.imgur.com/N9yfyQIh.jpg,https://i.imgur.com/2kjzV0Th.jpg",
                ProjectVideoUrl = "https://www.youtube.com/watch?v=l-IXCqSzNZA&feature=emb_logo",
                Project_Question = "木餐具使用上的注意事項,為什麼要使用木餐具？,如何保養？發霉了還有救嗎？",
                Project_Answer = "木製品並非一定不耐用，只要能夠注意幾點，絕對可以有很長的使用年限！而魟魚與貓所製作的木餐具皆使用亞麻仁籽油反覆數層地塗裝，絕對安全無毒！雖然保養很麻煩，但只要偶爾花一點時間，就可以延續它的生命，且不傷荷包，其實是非常划算的！也能夠藉由這樣的練習，來戒除快速時尚以及浪費金錢的惡習哦！絕對百利而無害！【平時應注意事項】*避免使用洗碗機或是烘碗機清洗木餐具，容易造成彎曲或裂痕。*清洗後，放置通風處陰乾即可。*可僅用菜瓜布搭配溫水清洗，避免使用鋼刷或過多的化學清潔劑。*可浸泡用醋或檸檬的稀釋液中來消除異味，但注意需完全乾燥後再收。*常常甚至天天使用是最好的保養方式。*如使用一陣子後有缺角或斷裂，可自行用砂紙研磨修補，再進行保養的步驟即可。*保養油可使用生飲無妨的食用油品，家中常備的油即可，不必另外購買。,首要的原因當然是溫暖又好看！不論是拿在手上或是放入口中，都散發著溫潤的能量，樸實且典雅，而且不會燙手或燙口哦！不過如果再更進一步思考使用木餐具的理由，會發現它所帶來的正向影響是非常廣闊的。木餐具的碳排放量非常地低，材料取得容易且便宜，最重要的是，它是少數不需要經由工廠就能被製作出來。意思就是，每個有意願的人都能夠做得出來！也意味著，不會有大量的能源消耗，也不會有大量污水和廢棄物的排放，更不會有後續無謂的包裝垃圾和運輸能源的消耗等等，光是這些，就能夠減少很多污染及能源的浪費，而且還有更多層面沒有提及呢！如果壞了、發霉了也無妨，因為它會自行分解，不會藉由你的手來造成環境的傷害！,由於木材的天然特性，剛開始的使用及清潔後，容易有纖維反翹的現象，造成表面粗糙，屬於正常現象，但不會造成使用的問題，請不用擔心。建議持續使用一週以上，可以進行一次的砂磨。清洗放置完全乾燥後，再利用#600或#800的水砂紙沾些食用油來砂磨，表面光滑後再靜置任其吸收油質，可視情況來定期使用同樣方式保養，之後反翹的現象就會漸漸減少甚至消失，木材便會逐漸穩定。隨著使用，木餐具也可能會因食材的色素改變顏色，也是正常現象，請不用擔心。,如果木餐具因為閒置太久或環境太過於潮濕而形成黴菌，請不要慌張，先觀察黴菌狀況。如果黴菌只在表面，尚未侵入木材纖維，直接清洗即可。但如果已經侵入纖維，請用溫水加小蘇打及食鹽浸泡來去除黴菌，陰乾後可以再用噴槍或瓦斯爐點火來烘烤，讓表面形成碳化，冷卻後再進行清潔保養即可。",
                ProjectPlansCount = 8


            });
            //第二個提案的會員資料
            context.Members.AddOrUpdate((x) => x.MemberId, new Member
            {
                MemberId = 2,
                MemberAccount = "NO2member",
                MemberPassword = "NO2memberPassword",
                MemberName = "魟魚與貓",
                MemberAddress = "100台北市中正區重慶南路一段122號",
                MemberBirth = new DateTime(1988, 11, 1),
                MemberConEmail = "1234@gmail.com",
                MemberRegEmail = "1234@gmail.com",
                MemberMessage = "",
                MemberPhone = "0935-123456",
                MemberTeamName = "魟魚與貓",
                MemberWebsite = "https://www.facebook.com/rayandcatsworkingshop",
                AboutMe = "我們是一對嘗試自給自足、尋找屬於自己的生活模式的夫妻，現在育有一個小孩，並帶著三隻貓咪，在苗栗山區開始我們夢想。在這裡我們自己動手蓋了一間不到十坪的小木屋，近1500坪的土地是畫紙，我們即將在上面畫出天堂。 利用農業的自給自足、木工技能的創作，以及消費欲望的降低，我們得以過著深居簡出的日子。創作只為了賺取生活所需並滿足心靈，家人間在生活中的彼此陪伴與成長才是一切。 我們捨棄了大多數的便利，丟棄一件件我們原本無法放手的物品與觀念，發現原來那些都是捆綁著我們的枷鎖，才開始看見自由的模樣。我們想要分享，讓他人也能看見，黑暗外的一切原來是一片綠意盎然的光明。",
                Gender = "男",
                ProfileImgUrl = "https://i.imgur.com/cdLjTOu.jpg",

            });
            //第二個提案中的方案
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 1,
                PlanTitle = "【單純贊助，不需要任何回饋！】",
                PlanFundedPeople = 11,
                PlanDescription = "喜歡我們的生活理想與實踐，以少量的金額付出，來實際支持我們的理念。",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/eCm2xgg.jpg",
                PlanePrice = 500m,
                QuantityLimit=0
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 2,
                PlanTitle = "【友善無毒農產品回饋方案】",
                PlanFundedPeople = 23,
                PlanDescription = "此方案可以收到我們（一年或更久之後）在這片土地上所種植的生鮮農產品，或者是我們自行加工的農產品。但是！無法保證作物的美觀或作物的種類，也許，可以當作福袋的心情來訂購喔！（笑）【可以保證的是：友善環境與無毒栽培】",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/hSE6nFa.jpg",
                PlanePrice = 800m,
                QuantityLimit = 20
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 3,
                PlanTitle = "【早鳥優惠的簡約餐具方案】",
                PlanFundedPeople = 10,
                PlanDescription = "一隻湯匙一雙筷子間單人生不過如此但是因為是早鳥再多一雙筷子也是剛好此方案包含湯匙x1支筷子x2雙島森家餐具袋x1只【約略尺寸】湯匙長約20cm寬5cm筷子長約23cm餐具袋長24cm寬7.5cm（收摺後）手工製作，難免誤差，感謝諒解",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/WRP6FKn.jpg",
                PlanePrice = 980m,
                QuantityLimit = 20
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 4,
                PlanTitle = "【簡約餐具方案】",
                PlanFundedPeople = 0,
                PlanDescription = "一隻湯匙一雙筷子間單人生不過如此此方案包含湯匙x1支筷子x1雙島森家餐具袋x1只【約略尺寸】湯匙長約20cm寬5cm筷子長約23cm餐具袋長24cm寬7.5cm（收摺後）手工製作，難免誤差，感謝諒解",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/QHpTRMu.jpg",
                PlanePrice = 980m,
                QuantityLimit = 20
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 4,
                PlanTitle = "【好像有點豪華方案】",
                PlanFundedPeople = 3,
                PlanDescription = "此方案包含筷子一雙、湯匙一支、喝湯深湯匙一支、餐叉一支、甜點水果叉一支、奶油果醬抹刀一支、島森家餐具袋一只約略尺寸筷子 長23cm湯匙 長20cm 寬5cm深湯匙 長17cm 寬5.5cm餐叉 長20cm水果叉 長14cm抹刀 長19cm餐具袋長24cm寬12 - 15cm（收摺後）",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/wnqwp61.jpg",
                PlanePrice = 1980m,
                QuantityLimit = 20
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 5,
                PlanTitle = "【來點下午茶方案】",
                PlanFundedPeople = 5,
                PlanDescription = "啊！好美！此方案包含手刻點心盤x2手刻杯墊x2咖啡量豆勺x1點心水果叉x2奶油果醬抹刀x1約略尺寸點心盤直徑 14 - 15cm 厚2cm杯墊直徑 10cm 厚1 - 1.5cm咖啡量豆勺 10 - 16cm 豆量約15克點心叉 13 - 14cm抹刀 18 - 20cm",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/sLuiuPH.jpg",
                PlanePrice = 2180m,
                QuantityLimit = 20
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 6,
                PlanTitle = "【好像一切都有了呢！】",
                PlanFundedPeople = 6,
                PlanDescription = "此方案包含有手把大砧板一片、大炒菜匙一支、中炒菜匙一支、攪拌匙一支、飯匙一支、料理長筷一雙、大湯杓一支約略尺寸手把大砧板 30x55cm(含手把)炒菜匙 大35x8cm 中26x7cm攪拌匙 35x5cm飯匙 21x6cm長筷 37.5cm大湯勺 42x8cm",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/aLPQXYg.jpg",
                PlanePrice = 3880m,
                 QuantityLimit = 20
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 7,
                PlanTitle = "【無開關感應式小夜燈】",
                PlanFundedPeople = 8,
                PlanDescription = "此方案包含全木製5vLED小夜燈組x1(內建LED燈、電子線路、高級電子零件)木質感應開關x1約略尺寸整體長寬高23x23x38cm底座直徑23 - 24cm 厚度約4cm小夜燈開啟方式https://www.youtube.com/watch?v=HoEgP1jn16U",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/YnlACWO.jpg",
                PlanePrice = 2680m,
                QuantityLimit = 20
            });
            context.Plans.AddOrUpdate((x) => x.PlanId, new Plan
            {
                ProjectId = 2,
                ProjectPlanId = 8,
                PlanTitle = "【簡約棧板盤案】",
                PlanFundedPeople = 3,
                PlanDescription = "此方案包含全木製5vLED小夜燈組x1(內建LED燈、電子線路、高級電子零件)木質感應開關x1約略尺寸整體長寬高23x23x38cm底座直徑23 - 24cm 厚度約4cm小夜燈開啟方式https://www.youtube.com/watch?v=HoEgP1jn16U",
                PlanShipDate = new DateTime(2021, 3, 21),
                PlanImgUrl = "https://i.imgur.com/RYrTiN5.jpg",
                PlanePrice = 3980m,
                QuantityLimit=20
            });
            //第三個提案
            context.Projects.AddOrUpdate((x) => x.ProjectId, new Project
            {
                ProjectId = 3,
                MemberId = 3,
                ProjectName = "#先浪狗變少——相信動物協會「紮女養成計」，前進桃園！",
                Category = "公共在地",
                ProjectStatus = "集資中",
                StartDate = new DateTime(2021, 2, 7),
                EndDate = new DateTime(2021, 4, 7),
                Fundedpeople = 2642,
                FundingAmount = 4790327m,
                AmountThreshold = 5200000m,
                CreatorName = "FaithForAnimals",
                ProjectMainUrl = "https://i.imgur.com/OQB8O5P.jpg",//提案瀏覽頁的頁面照片
                ProjectCoverUrl = "https://i.imgur.com/JwjyIza.jpg",//提案詳細頁的影片覆蓋照片
                ProjectDescription= "親愛的朋友，在台灣生長的這幾十年，你是否遇過下列令你懷疑人生的時候呢？靠著自己的實力拿了筆獎金，你承諾周圍的朋友這筆錢要部分捐給流浪動物。上網打開數個募款頁，有很多作法：收容、急傷⋯⋯，很多矛盾：人犬衝突、安樂死......，很多團體及個人的名稱：友善、尊敬......。最後你選擇把錢捐給了一個有名的團體並分享在社群，但......。,回到鄉下，阿公家新養的母狗不在，堂妹說，今天帶去車程一小時外的獸醫院結紮了，因為上個月生了一窩，家裏只是想要養一隻狗，沒想到會生這麼多。「幼犬呢？」你問。堂妹說：「阿公裝塑膠袋拿去河裡淹了......。」堂妹接著說：「對面鄰居阿府，上星期也把養半年的狗載去丟了，他一直不喜歡牠。」......你感到震懾。這些人，都是你親近的人，你知道他們不是壞人，那事情為什麼會這樣？,埋首於浪犬前線任務多年、經歷無數打磨，現在，相信動物協會提出了一個最有效率的浪浪解決方案——高強度絕育計畫。針對從未被飼主責任妥善規範及照顧的狗兒，我們有一個強而有力的主張 —— #先浪狗變少。,必須知道！浪浪變少大秘寶：絕育，絕育，絕育！,加碼了解！「高強度絕育計畫」國際共識：80%！,2016-2020年10月，相信動物協會共絕育了北北基的8,818隻母狗。現在台北新北的母犬絕育比例都超過80 %，基隆則在2018年底就有 85.6％的成績。,帶著北北基豐碩的成果，相信動物協會決定於2020年前進桃園。年初完成桃園市浪犬族群調查後，我們馬上發現擴區桃園的困難：,相信動物協會的眼界放眼全台高強度絕育計畫，代表的意義不止是區域性的有效減量，雖然這樣已經非常值得！除了提供絕育資源，家戶訪查是最直接的教育，還有過程中動保網絡及專業志工的累積培育。而協會的目光也從未止步於區域，我們渴望打磨出一個有效的、在地的，台灣流浪動物問題處理模板——希望幫助民間及公家機關找到良性合作平衡，使地方及中央對進程有共識不至政令斷層。盼行動可供更多單位複製借鑑，加速擴散 #先浪狗變少 的動保能量。",
                ProjectImgUrl = "https://i.imgur.com/twUjqYXl.jpg,https://i.imgur.com/88HaqLBl.jpg,https://i.imgur.com/Hg2cEDgl.jpg,https://i.imgur.com/xQonBnrl.jpg,https://i.imgur.com/a6vioWGl.jpg,https://i.imgur.com/dpkGabUl.jpg,https://i.imgur.com/CqpsAhSl.jpg,https://i.imgur.com/zTxmIwGl.jpg,https://i.imgur.com/GsIQcp1l.jpg,https://i.imgur.com/3QTSMpQl.jpg,https://i.imgur.com/n35AzFol.jpg,https://i.imgur.com/eLoDdnxl.jpg,https://i.imgur.com/rCHmEDbl.jpg,https://i.imgur.com/USXUbj0l.jpg,https://i.imgur.com/tIAyMryl.jpg,https://i.imgur.com/uNLXCunl.jpg,https://i.imgur.com/RYNk1Qal.jpg,https://i.imgur.com/isIUk5Yl.jpg,https://i.imgur.com/EPjPCGkl.jpg,https://i.imgur.com/xdNx3MJl.jpg",
                ProjectVideoUrl = "https://www.youtube.com/watch?v=40vGu9I2SAc&feature=emb_logo",
                Project_Question = "為什麼相信動物協會只絕育母犬？,相信動物協會目前服務的區域在哪裡?,請問可以寄送到海外嗎？運費如何計算？,請問可以單買或加購回饋品嗎?,回饋品預計何時寄出？,如果我忘記填寫尺寸、或是寄送、發票資訊填寫錯誤，請問我可以在哪裡修改?,會有收據或發票嗎?可以打統編或抬頭嗎?,請問相信動物 x 半隻羊立體書實驗室 聯名桌曆會由支持者自己組裝嗎？,「前線體驗營」＆「執行長演講」有地點限制嗎？,關於募資計畫的問題要如何聯繫你們？,請問回饋品的製造產地？",
                Project_Answer = "相信動物協會的主力全放在母犬絕育，很多人疑問我們為何不絕育公犬？因為在人力及資源有限的情況下，母犬絕育比公犬絕育優先且有效。假設一個地區有10隻公犬及10隻母犬，捕捉公犬與母犬所花費的時間及資源相同。絕育了9隻公犬後，僅存的1隻未絕育公犬一樣能讓10隻母犬懷孕。就算絕育了10隻公犬，母犬一旦發情，還是可以吸引其他地區公犬前來交配。絕育公犬完全無益於降低繁殖數量。而絕育1隻母犬，則會直接減少狗群的生產力。相信動物選擇全力進行母犬絕育，才能使有限人物力發揮最大效益。,北北基桃。,可以，海外運費金額因不同國家及包裹重量會有差異，需另計。請來信詢問 info@faithforanimals.org.tw,目前回饋品不開放單買或加購，僅在此募資計畫以方案形式贈送。,2021/2/7前支持募資案的贊助者，會在4/30前寄出回饋品！2021 / 2 / 8 - 3 / 9的贊助者，回饋品寄送會在5 / 31前完成。回饋品統一以包裹寄送。為響應環保，包裝皆使用重複利用之材料。,請於募資頁面右上方選取您的贊助紀錄進行相關資料修改即可。,若是選擇「隨喜贊助」方案，我們將開立捐款收據。若選擇其餘回饋方案，我們將開立發票。統編及抬頭資訊，請在回饋調查欄位填寫。收據/發票統一以紙本型式，郵局寄送。,不會，我們會在寄送前幫您組裝完畢。,「前線體驗營」地點為北北基桃，贊助成功後會有專人與您聯繫安排時間地點；「執行長演講」地點以台灣本島為主，若有其他疑問歡迎聯絡我們。,請於週一至週五10-19點 撥打(02)2701-3623 相信動物辦公室或來信詢問info@faithforanimals.org.tw,購物袋及開瓶器為陸製，其他都是台灣製造喔！",
                ProjectPlansCount = 8


            });
        }
    }
}
