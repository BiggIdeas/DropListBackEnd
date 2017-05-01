using System;
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

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}