using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularBudget.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace AngularBudget.Controllers
{
    
    [RoutePrefix("api/BudgetItems")]
    public class BudgetItemsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public class ControllerParams
        {
            
            public int HId { get; set; }
            
        }

        public class IdParam
        {
            public int id { get; set; }
        }
        
        [HttpPost]
        [Route("GetBudgetItems")]
        public async Task<List<BudgetItem>> GetBudgetItems(ControllerParams selected)
        {
            return await db.GetBudgetItems(selected.HId);
        }

        [HttpPost]
        [Route("GetValues")]
        public IHttpActionResult Get()
        {
            var r = new Random();
            var user = db.Users.Find(User.Identity.GetUserId());
            var house = db.Households.Find(user.HouseholdId);
            

            return Ok(new dynamic[]
            {

            new
                {
                    key = "Actual",
                    color = "#51A351",

                    values = (from c in house.Categories
                             where c.CategoryType.Name == "Expense"
                             let asum = (from t in c.Transactions
                                select t.Amount).DefaultIfEmpty().Sum()
                            select new
                            {
                                x = c.Name,
                                y = asum
                            }).ToArray()
                    
                },
                new
                {
                    key = "Budgeted",
                    color = "#BD362F",
                    values = (from c in house.Categories
                             where c.CategoryType.Name == "Expense"
                             let bsum = (from t in c.BudgetItems
                                select t.Amount).DefaultIfEmpty().Sum()
                            select new
                            {
                                x = c.Name,
                                y = bsum
                            }).ToArray()
                }
            });
        }
    }
}
