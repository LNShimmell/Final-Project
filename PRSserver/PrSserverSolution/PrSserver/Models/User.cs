using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrSserver.Models {
	public class User {
		public int Id { get; set; }
		[Required]
		[StringLength(30)]
		[Index(IsUnique = true)]
		public string UserName { get; set; }
		[Required]
		[StringLength(30)]
		public string Lname { get; set; }
		[Required]
		[StringLength(30)]
		public string Fname { get; set; }
		[Required]
		[StringLength(30)]
		public string Password { get; set; }
		[Required]
		[StringLength(30)]
		public string Phone { get; set; }
		[Required]
		[StringLength(255)]
		public string Email { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsReviewer { get; set; }
		public bool IsActive { get; set; }
	}
}