using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrSserver.Models {
	public class Vendor {
		public int Id { get; set; }
		[Index(IsUnique = true)]
		[StringLength(15)]
		[Required]
		public string Code { get; set; }
		[Required]
		[StringLength(30)]
		public string Name { get; set; }
		[Required]
		[StringLength(60)]
		public string Address { get; set; }
		[Required]
		[StringLength(50)]
		public string City { get; set; }
		[Required]
		[StringLength(40)]
		public string State { get; set; }
		[Required]
		[StringLength(20)]
		public string Phone { get; set; }
		[Required]
		[StringLength(15)]
		public string Zip { get; set; }
		[Required]
		[StringLength(255)]
		public string Email { get; set; }
		[Required]
		public bool IsPreapproved { get; set; }
		[Required]
		public bool Active { get; set; }
	}
}