namespace Droplist.api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Droplists", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Sections", "Building_BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Droplists", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Sections", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Building_BuildingId" });
            DropIndex("dbo.Droplists", new[] { "Building_BuildingId" });
            DropIndex("dbo.Droplists", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Droplists", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Sections", new[] { "Building_BuildingId" });
            DropIndex("dbo.Sections", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Products", new[] { "Building_BuildingId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Employees", name: "Building_BuildingId", newName: "BuildingId");
            RenameColumn(table: "dbo.Droplists", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Droplists", name: "Building_BuildingId", newName: "BuildingId");
            RenameColumn(table: "dbo.Products", name: "Building_BuildingId", newName: "BuildingId");
            RenameColumn(table: "dbo.Sections", name: "Building_BuildingId", newName: "BuildingId");
            RenameColumn(table: "dbo.Droplists", name: "Department_DepartmentId", newName: "DepartmentId");
            RenameColumn(table: "dbo.Sections", name: "Department_DepartmentId", newName: "DepartmentId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
            AlterColumn("dbo.Employees", "BuildingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Droplists", "BuildingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Droplists", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Droplists", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sections", "BuildingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sections", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "BuildingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Droplists", "BuildingId");
            CreateIndex("dbo.Droplists", "EmployeeId");
            CreateIndex("dbo.Droplists", "DepartmentId");
            CreateIndex("dbo.Sections", "DepartmentId");
            CreateIndex("dbo.Sections", "BuildingId");
            CreateIndex("dbo.Products", "BuildingId");
            CreateIndex("dbo.Employees", "BuildingId");
            AddForeignKey("dbo.Employees", "BuildingId", "dbo.Buildings", "BuildingId", cascadeDelete: true);
            AddForeignKey("dbo.Droplists", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Sections", "BuildingId", "dbo.Buildings", "BuildingId", cascadeDelete: true);
            AddForeignKey("dbo.Droplists", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Sections", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Droplists", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Sections", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Droplists", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Employees", new[] { "BuildingId" });
            DropIndex("dbo.Products", new[] { "BuildingId" });
            DropIndex("dbo.Sections", new[] { "BuildingId" });
            DropIndex("dbo.Sections", new[] { "DepartmentId" });
            DropIndex("dbo.Droplists", new[] { "DepartmentId" });
            DropIndex("dbo.Droplists", new[] { "EmployeeId" });
            DropIndex("dbo.Droplists", new[] { "BuildingId" });
            AlterColumn("dbo.Products", "BuildingId", c => c.Int());
            AlterColumn("dbo.Sections", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Sections", "BuildingId", c => c.Int());
            AlterColumn("dbo.Droplists", "EmployeeId", c => c.Int());
            AlterColumn("dbo.Droplists", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Droplists", "BuildingId", c => c.Int());
            AlterColumn("dbo.Employees", "BuildingId", c => c.Int());
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameColumn(table: "dbo.Sections", name: "DepartmentId", newName: "Department_DepartmentId");
            RenameColumn(table: "dbo.Droplists", name: "DepartmentId", newName: "Department_DepartmentId");
            RenameColumn(table: "dbo.Sections", name: "BuildingId", newName: "Building_BuildingId");
            RenameColumn(table: "dbo.Products", name: "BuildingId", newName: "Building_BuildingId");
            RenameColumn(table: "dbo.Droplists", name: "BuildingId", newName: "Building_BuildingId");
            RenameColumn(table: "dbo.Droplists", name: "EmployeeId", newName: "Employee_EmployeeId");
            RenameColumn(table: "dbo.Employees", name: "BuildingId", newName: "Building_BuildingId");
            RenameColumn(table: "dbo.AspNetUsers", name: "EmployeeId", newName: "Employee_EmployeeId");
            CreateIndex("dbo.Products", "Building_BuildingId");
            CreateIndex("dbo.Sections", "Department_DepartmentId");
            CreateIndex("dbo.Sections", "Building_BuildingId");
            CreateIndex("dbo.Droplists", "Employee_EmployeeId");
            CreateIndex("dbo.Droplists", "Department_DepartmentId");
            CreateIndex("dbo.Droplists", "Building_BuildingId");
            CreateIndex("dbo.Employees", "Building_BuildingId");
            AddForeignKey("dbo.Sections", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Droplists", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Sections", "Building_BuildingId", "dbo.Buildings", "BuildingId");
            AddForeignKey("dbo.Droplists", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Employees", "Building_BuildingId", "dbo.Buildings", "BuildingId");
        }
    }
}
