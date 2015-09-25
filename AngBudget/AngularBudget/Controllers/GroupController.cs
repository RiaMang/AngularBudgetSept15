using AngularBudget.Helpers;
using AngularBudget.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularBudget.Controllers
{
    [RoutePrefix("api/Group")]
    public class GroupController : ApiController
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
        [Models.Authorize]
        [Route("GetGroup")]
        public async Task<List<Household>> GetGroup(ControllerParams selected)
        {
            //    var group = await db.Households.FindAsync(selected.HId);
            //    return Ok(group);
            return await db.GetGroup(selected.HId); 
        }

        [HttpPost]
        [Models.Authorize]
        [Route("GetUsers")]
        public async Task<List<ApplicationUser>> GetUsers(ControllerParams selected)
        {
            //var users = db.Users.Where(u=>u.HouseholdId == selected.HId).ToList();
            //return Ok(users);
            return await db.GetUsers(selected.HId);
        }

        [HttpPost]
        [Route("CreateJoinHousehold")]
        public IHttpActionResult  CreateJoinHousehold(HouseholdViewModel hvm)
        {
            //string err = "";
            var user = db.Users.Find(User.Identity.GetUserId());
            if (hvm.Code == null) // create household
            {
                if (hvm.Name == null)
                    return BadRequest("Household Name must be provided.");
                Household h = new Household { Name = hvm.Name };
                db.Households.Add(h);
                db.SaveChanges();
                h.AddCategories();

                user.HouseholdId = h.Id;
            }
            else // join household
            {

                var invite = db.Invitations.FirstOrDefault(m => m.Code == hvm.Code);
                if (invite != null && user.Email == invite.Email)
                {
                    user.HouseholdId = invite.HouseholdId;
                    db.Entry(user).Property(p => p.HouseholdId).IsModified = true;
                }
                else
                {
                    return BadRequest("Sorry, The code and email combination does not match. ");
                    
                }

            }

            // REFRESH AUTHENTICATION
            //ApplicationSignInManager SignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

            //HttpContext.GetOwinContext().Authentication.SignOut();
            //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            //await ControllerContext.HttpContext.RefreshAuthentication(user);
            db.SaveChanges();
            
            return Ok();
        }

        [HttpPost]
        [Models.Authorize]
        [Route("InviteUsers")]
        public async Task<List<ApplicationUser>> InviteUsers(ControllerParams selected)
        {
            return await db.GetUsers(selected.HId);
            
        }

        [HttpPost]
        [System.Web.Http.Authorize]
        [Route("JoinHousehold")]
        public async Task<List<ApplicationUser>> JoinHousehold(ControllerParams selected)
        {
            return await db.GetUsers(selected.HId);
        }

        [HttpPost]
        [Models.Authorize]
        [Route("LeaveHousehold")]
        public async Task<List<ApplicationUser>> LeaveHousehold(ControllerParams selected)
        {
            return await db.GetUsers(selected.HId);
        }

    }
}
