using ExerciseAssiatant.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseAssiatant.Utilities
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

         public static void CheckRoles(string roleName)
         {
             var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

             if (!roleManager.RoleExists(roleName))
             {
                 roleManager.Create(new IdentityRole(roleName));
             }
        } 

        internal static void CheckSuperUser()
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("admin@mail.com");

            if (userAsp == null)
            {
                createUserASP("admin@mail.com", "admin123", "Admin");
                userAsp = userManager.FindByName("admin@mail.com");
                var adm = new Admin
                {
                    UserId= userAsp.Id
                };
               
            }
        
        }

        private static void createUserASP(string email, string password, string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = email,
                Email = email
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, role);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}