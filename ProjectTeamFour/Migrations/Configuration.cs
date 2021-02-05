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
        }
    }
}
