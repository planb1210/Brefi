namespace Brefi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brends", "UpdateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Brends", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Equipments", "UpdateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Equipments", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipments", "IsDeleted");
            DropColumn("dbo.Equipments", "UpdateTime");
            DropColumn("dbo.Brends", "IsDeleted");
            DropColumn("dbo.Brends", "UpdateTime");
        }
    }
}
