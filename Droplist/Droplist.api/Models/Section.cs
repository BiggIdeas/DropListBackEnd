using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Droplist.api.Models
{
	public class Section
	{
		public int SectionId { get; set; }
		public int DepartmentId { get; set; }
		public int BuildingId { get; set; }
		public string SectionName { get; set; } 


		public virtual Department Department { get; set; }
		public virtual Building Building { get; set; }



	}
}