namespace Droplist.api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Cellphone = c.String(),
                        Address = c.String(),
                        EmployeeNumber = c.Int(nullable: false),
                        Role = c.String(),
                        Building_BuildingId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId)
                .Index(t => t.Building_BuildingId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingNumber = c.Int(nullable: false),
                        BuildingName = c.String(),
                        Telephone = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Droplists",
                c => new
                    {
                        DroplistId = c.Int(nullable: false, identity: true),
                        DroplistName = c.String(),
                        Description = c.String(),
                        CreatedOnDate = c.DateTime(),
                        Building_BuildingId = c.Int(),
                        Department_DepartmentId = c.Int(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.DroplistId)
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Building_BuildingId)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                        Building_BuildingId = c.Int(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.SectionId)
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Building_BuildingId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.DroplistItems",
                c => new
                    {
                        DroplistItemId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        DroplistId = c.Int(nullable: false),
                        AisleNumber = c.String(),
                        AisleRow = c.String(),
                        AisleColumn = c.Int(nullable: false),
                        Completed = c.DateTime(),
                        Rejected = c.DateTime(),
                    })
                .PrimaryKey(t => t.DroplistItemId)
                .ForeignKey("dbo.Droplists", t => t.DroplistId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.DroplistId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ItemNumber = c.Int(nullable: false),
                        Description = c.String(),
                        Building_BuildingId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Buildings", t => t.Building_BuildingId)
                .Index(t => t.Building_BuildingId);
            
            AddColumn("dbo.AspNetUsers", "Employee_EmployeeId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Employee_EmployeeId");
            AddForeignKey("dbo.AspNetUsers", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Droplists", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DroplistItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.DroplistItems", "DroplistId", "dbo.Droplists");
            DropForeignKey("dbo.Sections", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Sections", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Droplists", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Droplists", "Building_BuildingId", "dbo.Buildings");
            DropIndex("dbo.Products", new[] { "Building_BuildingId" });
            DropIndex("dbo.DroplistItems", new[] { "DroplistId" });
            DropIndex("dbo.DroplistItems", new[] { "ProductId" });
            DropIndex("dbo.Sections", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Sections", new[] { "Building_BuildingId" });
            DropIndex("dbo.Droplists", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Droplists", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Droplists", new[] { "Building_BuildingId" });
            DropIndex("dbo.Employees", new[] { "Building_BuildingId" });
            DropIndex("dbo.AspNetUsers", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.AspNetUsers", "Employee_EmployeeId");
            DropTable("dbo.Products");
            DropTable("dbo.DroplistItems");
            DropTable("dbo.Sections");
            DropTable("dbo.Departments");
            DropTable("dbo.Droplists");
            DropTable("dbo.Buildings");
            DropTable("dbo.Employees");
        }
    }
}
