using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularBudget.Models;
using System.Threading.Tasks;

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
    }
}
