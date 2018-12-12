namespace Brefi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BriefInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToolTypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Brend_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brends", t => t.Brend_Id)
                .Index(t => t.Brend_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "Brend_Id", "dbo.Brends");
            DropIndex("dbo.Equipments", new[] { "Brend_Id" });
            DropTable("dbo.Equipments");
            DropTable("dbo.Brends");
        }
    }
}
