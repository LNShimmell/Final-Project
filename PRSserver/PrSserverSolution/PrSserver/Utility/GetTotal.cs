using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrSserver.Models;

namespace PrSserver.Utility {
	public class GetTotal {

		public IEnumerable<PurchaseRequestLineItem> purchaseRequestLineItems { get; set; }
		public IEnumerable<PurchaseRequest> PurchaseRequest { get; set; }
		public virtual PurchaseRequest PR { get; set; }
		public virtual Product Product { get; set; }
		public virtual PurchaseRequestLineItem GetPurchaseRequestLineItem { get; set; }
		public decimal Total { get; set; }

	}
}