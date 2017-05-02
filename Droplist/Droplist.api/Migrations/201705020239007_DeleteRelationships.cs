namespace Droplist.api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Products", new[] { "BuildingId" });
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String());
            DropColumn("dbo.Departments", "BuildingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "BuildingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "DepartmentName", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Price");
            CreateIndex("dbo.Products", "BuildingId");
            AddForeignKey("dbo.Products", "BuildingId", "dbo.Buildings", "BuildingId");
        }
    }
}
