namespace AngularBudget.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularBudget.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularBudget.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var admin = userManager.FindByEmail("admin@coderfoundry.com");
            if (admin == null)
            {
                admin = new ApplicationUser()
                {
                    UserName = "admin@coderfoundry.com",
                    Email = "admin@coderfoundry.com",
                    HouseholdId = 1,
                    Name = "Ria"
                };
                userManager.Create(admin, "Abc123!");
            }

        }
    }
}
