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
    public class PurchaseRequestLineItemsController : ApiController
    {
		private PrSModelController db = new PrSModelController();

		private void getTotal(int? purchaserequestId) {
			var pr = db.PurchaseRequests.Find(purchaserequestId);
			if (pr == null) return;
			var lines = db.PurchaseRequestLineItems.Where(li => li.PurchaseRequestId == purchaserequestId);
			pr.Total = lines.Sum(li => li.Quantity * li.Products.Price);
			db.SaveChanges();

		}

        //List out all Purchase Request for one user
        [HttpGet]
        [ActionName("Listone")]
        public JsonRequest ListPRone (int? Id)
        {
            JsonRequest json = new JsonRequest();
            json.Data = db.PurchaseRequestLineItems.Where(li => li.PurchaseRequestId == Id).ToList();
            return json;

        }
		//List out all PurchaseRequestLineItems
		[HttpGet]
		[ActionName("List")]
		public JsonRequest ListPurchaseRequestLineItems() {
			JsonRequest json = new JsonRequest();
			json.Data = db.PurchaseRequestLineItems.ToList();
			return json;
		}

		//Find a specific PurchaseRequestLineItem by Id
		[HttpGet]
		[ActionName("Find")]
		public JsonRequest FindPurchaseRequestLineItemById(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			json.Data = db.PurchaseRequestLineItems.Find(Id);
			return json;
		}

		//Create a new PurchaseRequestLineItem
		[HttpPost]
		[ActionName("Create")]
		public JsonRequest CreateNewPurchaseRequestLineItem(PurchaseRequestLineItem purchaseRequestLineItem) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				json.Data = db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
				db.SaveChanges();
				getTotal(purchaseRequestLineItem.PurchaseRequestId);
				return json;
			}
			json.Message = "failed";
			json.Error = "No values can be null";

			return json;
		}

		//delete a PurchaseRequestLineItem permanitly 
		[HttpPost]
		[ActionName("Delete")]
		public JsonRequest DeletePurchaseRequestLineItem(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			var PurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(Id);
			json.Data = db.PurchaseRequestLineItems.Remove(PurchaseRequestLineItem);
			getTotal(Id);
			db.SaveChanges();
			return json;
		}
		//Make changes to an existing PurchaseRequestLineItem
		[HttpPost]
		[ActionName("Edit")]
		public JsonRequest EditPurchaseRequestLineItem(PurchaseRequestLineItem purchaseRequestLineItem) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				db.Entry(purchaseRequestLineItem).State = EntityState.Modified;
				db.SaveChanges();
				getTotal(purchaseRequestLineItem.PurchaseRequestId);
				json.Data = purchaseRequestLineItem;
				return json;
			}
			json.Error = "Invalaid entry";
			json.Message = "Failed";
			return json;
		}
	}
}
