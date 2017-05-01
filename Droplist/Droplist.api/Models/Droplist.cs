using System;
using System.Collections.Generic;

namespace Droplist.api.Models
{
	public class Droplist
	{
		// scalar properties
		public int DroplistId { get; set; }
		public string DroplistName { get; set; }
		public string Description { get; set; }
		public DateTime? CreatedOnDate { get; set; }

		// navigation properties
		public virtual Building Building { get; set; }
		public virtual Employee Employee { get; set; }
		public virtual Department Department { get; set; }
		public virtual ICollection<DroplistItem> DroplistItem { get; set; }

	}
}