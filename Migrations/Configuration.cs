using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using netmvc.Models;

namespace netmvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<netmvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "netmvc.Models.ApplicationDbContext";
        }

        protected override void Seed(netmvc.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {   var PasswordHash = new PasswordHasher();
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {UserName = "admin@admin.com",
                    Email ="admin@admin.com"
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "admin");
            }
        }
    }
}
