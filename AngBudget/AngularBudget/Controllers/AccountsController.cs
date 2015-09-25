using AngularBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularBudget.Controllers
{
    [Models.Authorize]
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public class ControllerParams
        {

            public int HId { get; set; }
            public int id { get; set; }

        }

        public class IdParam
        {
            public int id { get; set; }
        }

        [HttpPost]
        [Route("GetAccounts")]
        public IHttpActionResult GetAccounts(ControllerParams selected)
        {
            var Accounts = db.Accounts.Where(a=>a.HouseholdId == selected.HId).ToList();
            return Ok(Accounts);
        }

        [HttpPost]
        [Route("GetAccountDetails")]
        public IHttpActionResult GetAccountDetails(ControllerParams selected)
        {
           
            var Account = db.Accounts.Find(selected.id);
            return Ok(Account);
        }

        [HttpPost]
        [Route("UpdateAccount")]
        public IHttpActionResult UpdateAccount(Account Account)
        {
            //var Account = db.Accounts.Find(selected.id);
            db.Entry(Account).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(Account);
        }

    }
}

