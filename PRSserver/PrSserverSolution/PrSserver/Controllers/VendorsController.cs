using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PrSserver.Models;
using PrSserver.Utility;

namespace PrSserver.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VendorsController : ApiController
    {
		private PrSModelController db = new PrSModelController();


		//List out all Vendors
		[HttpGet]
		[ActionName("List")]
		public JsonRequest ListVendors() {
			JsonRequest json = new JsonRequest();
			json.Data = db.Vendors.ToList();
			return json;
		}

		//Find a specific vendor by Id
		[HttpGet]
		[ActionName("Find")]
		public JsonRequest FindVendorById(int? Id) {
			JsonRequest json = new JsonRequest();
			if(Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			json.Data = db.Vendors.Find(Id);
			return json;
		}

		//Create a new Vendor
		[HttpPost]
		[ActionName("Create")]
		public JsonRequest CreateNewVendor(Vendor vendor) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				json.Data = db.Vendors.Add(vendor);
				db.SaveChanges();
				return json;
			}
				json.Message = "failed";
				json.Error = "No values can be null";
				return json;
		}

		//delete a vendor permanitly 
		[HttpPost]
		[ActionName("Delete")]
		public JsonRequest DeleteVendor(int? Id) {
			JsonRequest json = new JsonRequest();
			if(Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			var vendor = db.Vendors.Find(Id);
			json.Data = db.Vendors.Remove(vendor);
			db.SaveChanges();
			return json;
		}
		//Make changes to an existing Vendor
		[HttpPost]
		[ActionName("Edit")]
		public JsonRequest EditVendor(Vendor vendor) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				db.Entry(vendor).State = EntityState.Modified;
				db.SaveChanges();
				json.Data = vendor;
				return json;
			}
			json.Error = "Invalaid entry";
			json.Message = "Failed";
			return json;
		}
    }
}
