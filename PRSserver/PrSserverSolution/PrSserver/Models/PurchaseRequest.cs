using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrSserver.Models {
	public class PurchaseRequest {

		public int Id { get; set; }
		[StringLength(120)] public string Description { get; set; }
		[StringLength(120)] public string RejectionReason { get; set; }
		[StringLength(20)] public string DeliveryMode { get; set; }
		[StringLength(15)] public string Status { get; set; }
		[DataType("decimal(12,2)")] public decimal Total { get; set; } = 0;
		public int UserID { get; set; }
		public virtual User User { get; set; }
		public virtual List<PurchaseRequestLineItem> PurchaseRequestLineItems { get; set; }
	}
}