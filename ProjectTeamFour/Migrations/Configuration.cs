namespace ProjectTeamFour.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectTeamFour.Models.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjectTeamFour.Models.ProjectContext context)
        {
            context.Projects.AddOrUpdate(x => x.ProjectId, new Models.Project()
            {
                ProjectId = 2,
                Title = "Cheerpod 智慧滑鼠 | 一片在手,螢幕隨控",
                MainImage = "p2.jpg",
                CategoryName = "科技設計",
                Pulisher = "cheerdots TW",
                D_DateTime = new DateTime(2021, 2, 10),
                GoalMoney = 10000000,
                NowMoney = 289
            });
            context.productDetails.AddOrUpdate(x => x.Id,
                 new Models.ProjectDetail
                 {
                     Id = 1,
                     ProductName = "開啟與孩子的第一場程式冒險 《解碼傳說 CO·DECODE》",
                     CreatorName = "Papacode-程式老爹",
                     Category = "遊戲出版",
                     FundedPeople = 828,
                     GoalAmount = 140113,
                     FundedAmount = 1609173,
                     DeadLine=new DateTime(2021,3,1)
                 },
            new Models.ProjectDetail { Id = 2, ProductName = "Cheerpod 智慧滑鼠 | 一片在手,螢幕隨控",
                CreatorName = "cheerdots TW", Category = "科技設計", FundedPeople = 5, GoalAmount = 10000000,
                DeadLine=new DateTime(2021,3,2)}
            );
        }
    }
}
