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
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public class Parameter
        {
            public int AccId { get; set; }
            public int Id { get; set; }
        }

        [Route("GetTransactions")]
        [HttpPost]
        public IHttpActionResult GetTransactions(Parameter param)
        {
            var trans = (from account in db.Accounts
                         where account.Id == param.AccId
                         from transaction in account.Transactions
                         select new
                         {
                             Id = transaction.Id,
                             Amount = transaction.Amount,
                             Description = transaction.Description,
                             Category = transaction.Category.Name,
                             UpdatedBy = transaction.UpdatedBy.UserName,
                             TransDate = transaction.TransDate,
                             RecAmount = transaction.RecAmount
                         }).ToList();
            return Ok(trans);
        }
    }
}
