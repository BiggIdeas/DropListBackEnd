namespace Droplist.api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Droplists", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Droplists", new[] { "DepartmentId" });
            AddColumn("dbo.Droplists", "SectionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Droplists", "SectionId");
            AddForeignKey("dbo.Droplists", "SectionId", "dbo.Sections", "SectionId", cascadeDelete: true);
            DropColumn("dbo.Droplists", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Droplists", "DepartmentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Droplists", "SectionId", "dbo.Sections");
            DropIndex("dbo.Droplists", new[] { "SectionId" });
            DropColumn("dbo.Droplists", "SectionId");
            CreateIndex("dbo.Droplists", "DepartmentId");
            AddForeignKey("dbo.Droplists", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
