using AngularBudget.Models;
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
        [Route("GetGroup")]
        public async Task<Household> GetGroup(ControllerParams selected)
        {
            return await db.Households.FindAsync(selected.HId);
        }

        [HttpPost]
        [Route("GetUsers")]
        public  List<ApplicationUser> GetUsers(ControllerParams selected)
        {
            return db.Users.Where(u=>u.HouseholdId == selected.HId).ToList();
        }

        [HttpPost]
        [Route("CreateJoinHousehold")]
        public void  CreateJoinHousehold(HouseholdViewModel hvm)
        {
            //string err = "";
            //var user = db.Users.Find(User.Identity.GetUserId());
            //if (hvm.Code == null) // create household
            //{
            //    if (hvm.Name == null)
            //        return err;
            //    Household h = new Household { Name = hvm.Name };
            //    db.Households.Add(h);
            //    db.SaveChanges();
            //    h.AddCategories();

            //    user.HouseholdId = h.Id;
            //}
            //else // join household
            //{

            //    var invite = db.Invitations.FirstOrDefault(m => m.Code == hvm.Code);
            //    if (invite != null && user.Email == invite.Email)
            //    {
            //        user.HouseholdId = invite.HouseholdId;
            //        db.Entry(user).Property(p => p.HouseholdId).IsModified = true;
            //    }
            //    else
            //    {
            //        ViewBag.Error = "Sorry, The code and email combination does not match. ";
            //        return View();
            //    }

            //}
            ////ApplicationSignInManager SignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

            ////HttpContext.GetOwinContext().Authentication.SignOut();
            ////await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            //await ControllerContext.HttpContext.RefreshAuthentication(user);
            //db.SaveChanges();

            //return RedirectToAction("Dashboard");
            //return await db.GetUsers(selected.HId);
            
        }

        [HttpPost]
        [Route("InviteUsers")]
        public async Task<List<ApplicationUser>> InviteUsers(ControllerParams selected)
        {
            return await db.GetUsers(selected.HId);
            
        }

        [HttpPost]
        [Route("JoinHousehold")]
        public async Task<List<ApplicationUser>> JoinHousehold(ControllerParams selected)
        {
            return await db.GetUsers(selected.HId);
        }

        [HttpPost]
        [Route("LeaveHousehold")]
        public async Task<List<ApplicationUser>> LeaveHousehold(ControllerParams selected)
        {
            return await db.GetUsers(selected.HId);
        }

    }
}
