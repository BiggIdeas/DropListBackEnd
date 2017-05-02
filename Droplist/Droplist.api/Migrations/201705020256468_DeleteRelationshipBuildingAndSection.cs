namespace Droplist.api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRelationshipBuildingAndSection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sections", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Sections", new[] { "BuildingId" });
            DropColumn("dbo.Sections", "BuildingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sections", "BuildingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sections", "BuildingId");
            AddForeignKey("dbo.Sections", "BuildingId", "dbo.Buildings", "BuildingId", cascadeDelete: true);
        }
    }
}
