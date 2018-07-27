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
    public class UsersController : ApiController{




		private PrSModelController db = new PrSModelController();


        [HttpGet]
        public JsonRequest Authenticate(string username, string password)
        {
            if (username == null || password == null)
            {
                return new JsonRequest { Error = "invalid entry, please input username and password into the appropraite fields.", Message = "Failed", Result = "failed" };
            }
            var user = db.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);
            return new JsonRequest { Error = null, Data = user, Message = "success", Result = "login" };
        }

        //List out all Users
        [HttpGet]
		[ActionName("List")]
		public JsonRequest ListUsers() {
			JsonRequest json = new JsonRequest();
			json.Data = db.Users.ToList();
			return json;
		}

		//Find a specific User by Id
		[HttpGet]
		[ActionName("Find")]
		public JsonRequest FindUserById(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			json.Data = db.Users.Find(Id);
			return json;
		}

		//Create a new User
		[HttpPost]
		[ActionName("Create")]
		public JsonRequest CreateNewUser(User User) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				json.Data = db.Users.Add(User);
				db.SaveChanges();
				return json;
			}
			json.Message = "failed";
			json.Error = "No values can be null";
			return json;
		}

		//delete a User permanitly 
		[HttpPost]
		[ActionName("Delete")]
		public JsonRequest DeleteUser(int? Id) {
			JsonRequest json = new JsonRequest();
			if (Id == null) {
				json.Message = "Failed";
				json.Error = "Id must not be null";
				return json;
			}
			var User = db.Users.Find(Id);
			json.Data = db.Users.Remove(User);
			db.SaveChanges();
			return json;
		}
		//Make changes to an existing User
		[HttpPost]
		[ActionName("Edit")]
		public JsonRequest EditUser(User User) {
			JsonRequest json = new JsonRequest();
			if (ModelState.IsValid) {
				db.Entry(User).State = EntityState.Modified;
				db.SaveChanges();
				json.Data = User;
				return json;
			}
			json.Error = "Invalaid entry";
			json.Message = "Failed";
			return json;
		}
	}
}
