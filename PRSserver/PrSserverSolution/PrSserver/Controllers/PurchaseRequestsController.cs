using PrSserver.Models;
using PrSserver.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PrSserver.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PurchaseRequestsController : ApiController {
		private PrSModelController db = new PrSModelController();

		

		//List out all PurchaseRequests
		[HttpGet]
		[ActionName("List")]
		public JsonRequest ListPurchaseRequests() {
			JsonRequest json = new JsonRequest();
			json.Data = db.PurchaseRequests.ToList();
			return json;
		}

		//Find a specific PurchaseRequest by Id
		[HttpGet]
		[ActionName("Find")]
		public JsonRequest FindPurchaseRequestById(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			json.Data = db.PurchaseRequests.Find(Id);
			return json;
		}

		//Create a new PurchaseRequest
		[HttpPost]
		[ActionName("Create")]
		public JsonRequest CreateNewPurchaseRequest(PurchaseRequest PurchaseRequest) {
			JsonRequest json = new JsonRequest();

            if(!ModelState.IsValid){
                json.Message = "failed";
                json.Error = "No values can be null";
                return json;
            }
            else
            {
                json.Data = db.PurchaseRequests.Add(PurchaseRequest);
                db.SaveChanges();
                return json;
            }
		}

		//delete a PurchaseRequest permanitly 
		[HttpPost]
		[ActionName("Delete")]
		public JsonRequest DeletePurchaseRequest(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			var PurchaseRequest = db.PurchaseRequests.Find(Id);
            var lineitems = db.PurchaseRequestLineItems.Where(li => li.PurchaseRequestId == Id);
			json.Data = db.PurchaseRequests.Remove(PurchaseRequest);
			db.SaveChanges();
			return json;
		}
		//Make changes to an existing PurchaseRequest
		[HttpPost]
		[ActionName("Edit")]
		public JsonRequest EditPurchaseRequest(PurchaseRequest purchaseRequest) {
            purchaseRequest.PurchaseRequestLineItems = null;
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				db.Entry(purchaseRequest).State = EntityState.Modified;
                db.SaveChanges();
				json.Data = purchaseRequest;
				return json;
			}
			json.Error = "Invalaid entry";
			json.Message = "Failed";
			return json;
		}
		//[HttpGet]
		//[ActionName("Total")]
		//public JsonRequest GetTotal(int? Id) {
		//	JsonRequest json = new JsonRequest();
		//	GetTotal purchaseProduct = new GetTotal();
		//	purchaseProduct.PurchaseRequest = db.PurchaseRequests.Where(p => p.Id == Id);
		//	List<PurchaseRequestLineItem> PRLI = db.PurchaseRequestLineItems.Where(prli => prli.PurchaseRequestId == Id).ToList();
		//	purchaseProduct.purchaseRequestLineItems = PRLI;
		//	//List<decimal> subtotal = new List<decimal>();
		//	//List<int> quant = new List<int>();
		//	List<decimal> actual = new List<decimal>();

		//	foreach (var st in PRLI) {
		//		actual.Add((db.Products.Find(st.ProductId).Price) * (db.PurchaseRequestLineItems.Find(st.Id).Quantity));
		//	}
		//	purchaseProduct.Total = actual.Sum();
		//	purchaseProduct.PR.Total = purchaseProduct.Total;
			

			
		//	//db.Entry(PurchaseRequest).State = EntityState.Modified;
		//	json.Data = purchaseProduct;

		//	return json;
			

		
	}
}
