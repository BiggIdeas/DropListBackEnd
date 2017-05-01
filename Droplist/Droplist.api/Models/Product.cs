using System.Collections.Generic;

namespace Droplist.api.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		public int ItemNumber { get; set; }
		public string Description { get; set; }

		public virtual ICollection<DroplistItem> DroplistItems { get; set; }
		public virtual Building Building { get; set; }


	}
}