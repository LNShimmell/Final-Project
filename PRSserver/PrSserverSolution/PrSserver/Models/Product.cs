using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrSserver.Models {
	public class Product {
		public int ID { get; set; }

		[Required]
		public int VendorID { get; set; }
		public virtual Vendor Vendor { get; set; }
		[StringLength(30)]
		[Required]
		public string Partnum { get; set; }
		[StringLength(30)]
		[Required]
		public string Name { get; set; }
		[DataType("decimal(12,2)")]
		[Required]
		public decimal Price { get; set; }
		[Required]
		[StringLength(255)]
		public string Unit { get; set; }
		[StringLength(1000)]
		public string Photopath { get; set; }

		public bool Active { get; set; }
	}
}