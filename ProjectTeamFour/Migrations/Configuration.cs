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
                Title = "Cheerpod ���z�ƹ� | �@���b��,�ù��H��",
                MainImage = "p2.jpg",
                CategoryName = "��޳]�p",
                Pulisher = "cheerdots TW",
                D_DateTime = new DateTime(2021, 2, 10),
                GoalMoney = 10000000,
                NowMoney = 289
            });
            context.productDetails.AddOrUpdate(x => x.Id,
                 new Models.ProjectDetail
                 {
                     Id = 1,
                     ProductName = "�}�һP�Ĥl���Ĥ@���{���_�I �m�ѽX�ǻ� CO�PDECODE�n",
                     CreatorName = "Papacode-�{���ѯR",
                     Category = "�C���X��",
                     FundedPeople = 828,
                     GoalAmount = 140113,
                     FundedAmount = 1609173,
                     DeadLine=new DateTime(2021,3,1)
                 },
                new Models.ProjectDetail 
                {   Id = 2, 
                    ProductName = "Cheerpod ���z�ƹ� | �@���b��,�ù��H��",
                    CreatorName = "cheerdots TW", 
                    Category = "��޳]�p", 
                    FundedPeople = 5, 
                    GoalAmount = 10000000,
                    DeadLine=new DateTime(2021,3,2)}
            );
        }
    }
}
