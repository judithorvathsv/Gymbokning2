using Bogus;
using Gymbokning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Data
{
    public class SeedData
    {
   

        internal static async Task InitAsync(IServiceProvider services)
        {
            using (var db = services.GetRequiredService<ApplicationDbContext>())
            {            

                const string passWord = "AdminNet21!";
                const string roleName = "Admin";

                var userManager = services.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();            

                var role = new IdentityRole { Name = roleName };
                var addRoleResult = await roleManager.CreateAsync(role);         

                var users = GetUsers();
                await db.AddRangeAsync(users);

                foreach (var item in users)
                {
                    var result = await userManager.CreateAsync(item, passWord);
                    if (!result.Succeeded) throw new Exception(String.Join("\n", result.Errors));
                    await userManager.AddToRoleAsync(item, "Admin");
                }
                await db.SaveChangesAsync();
            }
        }

        private static List<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>();
      
                var appUser = new ApplicationUser
                {    
                    Email = "admin@Gymbokning.se",
                    UserName = "admin@Gymbokning.se", 
                    Password = "AdminNet21!",
                    FirstName = "AdminF",
                    LastName = "AdminL"
                };
                users.Add(appUser);
     
            return users;
        }
    }
}
