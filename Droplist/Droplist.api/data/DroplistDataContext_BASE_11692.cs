﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Droplist.api.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Droplist.api.data
{
	public class DroplistDataContext : IdentityDbContext<User>
	{
		public DroplistDataContext() : base("droplist.api")
		{

		}
		public IDbSet<Building> Buildings { get; set; }
		public IDbSet<Department> Departments { get; set; }
		public IDbSet<Models.Droplist> Droplists { get; set; }
		public IDbSet<DroplistItem> DroplistItem { get; set; }
		public IDbSet<Employee> Employee { get; set; }
		public IDbSet<Product> Products { get; set; }
		public IDbSet<Section> Sections { get; set; }





		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			// building has many drop lists, drivers?, stockers?

			modelBuilder.Entity<Building>()
				.HasMany(Building => Building.Droplists)
				.WithRequired(droplist => droplist.Building)
				.HasForeignKey(droplist => droplist.BuildingId)
				.WillCascadeOnDelete(false);


			modelBuilder.Entity<Building>()
			.HasMany(Building => Building.Employees)
			.WithRequired(employee => employee.Building)
			.HasForeignKey(employee => employee.BuildingId);

			modelBuilder.Entity<Building>()
			.HasMany(Building => Building.Sections)
			.WithRequired(section => section.Building)
			.HasForeignKey(section => section.BuildingId);

			modelBuilder.Entity<Building>()
			.HasMany(Building => Building.Products)
			.WithRequired(product => product.Building)
			.HasForeignKey(product => product.BuildingId)
							.WillCascadeOnDelete(false);


			modelBuilder.Entity<Employee>()
				.HasMany(Employee => Employee.Droplists)
				.WithRequired(droplist => droplist.Employee)
				.HasForeignKey(droplist => droplist.EmployeeId);

			modelBuilder.Entity<Department>()
				.HasMany(Department => Department.Droplists)
				.WithRequired(droplist => droplist.Department)
				.HasForeignKey(droplist => droplist.DepartmentId);

			modelBuilder.Entity<Department>()
				.HasMany(Department => Department.Sections)
				.WithRequired(section => section.Department)
				.HasForeignKey(section => section.DepartmentId);

			modelBuilder.Entity<Models.Droplist>()
				.HasMany(droplist => droplist.DroplistItems)
				.WithRequired(DroplistItem => DroplistItem.Droplist)
				.HasForeignKey(DroplistItem => DroplistItem.DroplistId);

			modelBuilder.Entity<Product>()
				.HasMany(product => product.DroplistItems)
				.WithRequired(DroplistItem => DroplistItem.Product)
				.HasForeignKey(DroplistItem => DroplistItem.ProductId);

			modelBuilder.Entity<User>()
				.HasOptional(user => user.Employee)
				.WithOptionalDependent(employee => employee.User)
				.Map(m => m.MapKey("EmployeeId"));

			

			base.OnModelCreating(modelBuilder);
		}
	}
}