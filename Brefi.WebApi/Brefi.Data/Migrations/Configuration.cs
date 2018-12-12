namespace Brefi.Data.Migrations
{
    using Brefi.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Brefi.Data.BrefiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Brefi.Data.BrefiContext context)
        {
            SeedEquipment(context);
        }

        private void SeedEquipment(BrefiContext context)
        {
            Brend brend1 = new Brend() { Name = "brend1", BriefInfo = "info1", UpdateTime = new DateTime(2018, 12, 10, 18, 30, 25), IsDeleted = false };
            Brend brend2 = new Brend() { Name = "brend2", BriefInfo = "info2", UpdateTime = new DateTime(2018, 12, 10, 18, 30, 25), IsDeleted = false };

            context.Brends.AddOrUpdate(x => x.Id, brend1);
            context.Brends.AddOrUpdate(x => x.Id, brend2);

            Equipment equipment1 = new Equipment() { Brend = brend1, Price = 12, ToolTypeId = 1, Description = "description 1", UpdateTime = new DateTime(2018, 12, 10, 18, 30, 25), IsDeleted = false };
            Equipment equipment2 = new Equipment() { Brend = brend2, Price = 555, ToolTypeId = 2, Description = "description 2", UpdateTime = new DateTime(2018, 12, 10, 18, 30, 25), IsDeleted = false };

            context.Equipments.AddOrUpdate(x => x.Id, equipment1);
            context.Equipments.AddOrUpdate(x => x.Id, equipment2);
        }
    }
}
