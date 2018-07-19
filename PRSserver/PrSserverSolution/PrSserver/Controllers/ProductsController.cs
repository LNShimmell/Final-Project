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
    public class ProductsController : ApiController
    {
		private PrSModelController db = new PrSModelController();


		//List out all Products
		[HttpGet]
		[ActionName("List")]
		public JsonRequest ListProducts() {
			JsonRequest json = new JsonRequest();
			json.Data = db.Products.ToList();
			return json;
		}

		//Find a specific Product by Id
		[HttpGet]
		[ActionName("Find")]
		public JsonRequest FindProductById(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			json.Data = db.Products.Find(Id);
			return json;
		}

		//Create a new Product
		[HttpPost]
		[ActionName("Create")]
		public JsonRequest CreateNewProduct(Product Product) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				json.Data = db.Products.Add(Product);
				db.SaveChanges();
				return json;
			}
			json.Message = "failed";
			json.Error = "No values can be null";
			return json;
		}

		//delete a Product permanitly 
		[HttpPost]
		[ActionName("Delete")]
		public JsonRequest DeleteProduct(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			var Product = db.Products.Find(Id);
			json.Data = db.Products.Remove(Product);
			db.SaveChanges();
			return json;
		}
		//Make changes to an existing Product
		[HttpPost]
		[ActionName("Edit")]
		public JsonRequest EditProduct(Product Product) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				db.Entry(Product).State = EntityState.Modified;
				db.SaveChanges();
				json.Data = Product;
				return json;
			}
			json.Error = "Invalaid entry";
			json.Message = "Failed";
			return json;
		}
	}
}
