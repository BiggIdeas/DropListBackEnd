using System;
using System.Collections.Generic;

namespace Droplist.api.Models
{
	public class Droplist
	{
		// scalar properties
		public int DroplistId { get; set; }
		public int BuildingId { get; set; }
		public int EmployeeId { get; set; }
		public int SectionId { get; set; }
		public string DroplistName { get; set; }
		public string Description { get; set; }
		public DateTime? CreatedOnDate { get; set; }

		// navigation properties
		public virtual Building Building { get; set; }
		public virtual Employee Employee { get; set; }
		public virtual Section Section { get; set; }
		public virtual ICollection<DroplistItem> DroplistItems { get; set; }
	}
}