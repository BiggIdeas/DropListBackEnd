using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Droplist.api.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public int DepartmentName { get; set; }
		public int BuildingId { get; set; }

		//navigation properties
		public virtual ICollection<Droplist> Droplists { get; set; }
		public virtual ICollection<Section> Sections { get; set; }

	}
}