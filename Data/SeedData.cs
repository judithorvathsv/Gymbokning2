using Bogus;
using Gymbokning.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace Gymbokning.Data
{
    public class SeedData
    {
        private static Faker fake;

        internal static async Task InitAsync(IServiceProvider services)
        {
            using (var db = services.GetRequiredService<ApplicationDbContext>())
            {
                //if (db.Users.Any()) return;

                const string passWord = "AdminNet21!";
                const string roleName = "Admin";

                var userManager = services.GetRequiredService<Microsoft.AspNetCore.Identity.UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole<int>>>();
                //var roleManager = services.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<IdentityRole<string>>>();

                var role = new IdentityRole<int> { Name = roleName };
                var addRoleResult = await roleManager.CreateAsync(role);

                fake = new Faker("sv");

                var users = GetUsers();
                await db.AddRangeAsync(users);

                foreach (var item in users)
                {
                    var result = await userManager.CreateAsync(item, passWord);
                    if (!result.Succeeded) throw new Exception(String.Join("\n", result.Errors));
                    await userManager.AddToRoleAsync(item, "Admin");
                }

                //var courses = GetCourses();
                //await db.AddRangeAsync(courses);

                await db.SaveChangesAsync();
            }
        }

        private static List<ApplicationUser> GetUsers()
        {
            var users = new List<ApplicationUser>();

            //for (int i = 0; i < 200; i++)
            //{
                //var lName = fake.Name.LastName();
                //var email = fake.Internet.Email($" {lName}");
                var appUser = new ApplicationUser
                {    
                    Email = "admin@Gymbokning.se",
                    UserName = "admin@Gymbokning.se", 
                    Password = "AdminNet21!"
                };
                users.Add(appUser);
           // }
            return users;
        }




        //internal static async Task InitAsync(IServiceProvider services)
        //{
        //    using (var db = services.GetRequiredService<ApplicationDbContext>())
        //    {
        //        //create user.
        //        var passwordHasher = new PasswordHasher();
        //        var user = new IdentityUser("Administrator");
        //        user.PasswordHash = passwordHasher.HashPassword("Admin12345");
        //        user.SecurityStamp = Guid.NewGuid().ToString();

        //        //create and add new Role.
        //        var roleToChoose = new IdentityRole("Admin");
        //        db.Roles.Add(roleToChoose);

        //        //create a role for a user
        //        var role = new IdentityUserRole();
        //        role.RoleId = roleToChoose.Id;
        //        role.UserId = user.Id;

        //        //add the role row and add the user to db
        //        user.Roles.Add(role);
        //        db.Users.Add(user);
        //    }
        //    }
        //}


        //    internal static async Task InitAsync(IServiceProvider services)
        //    {
        //        using (var db = services.GetRequiredService<ApplicationDbContext>())
        //        {
        //                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context));
        //                var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole, int, ApplicationUserRole>(context));

        //                if (!roleManager.Roles.Any())
        //                {
        //                    await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRole.AdminRoleName });
        //                    await roleManager.CreateAsync(new ApplicationRole { Name = ApplicationRole.AffiliateRoleName });
        //                }

        //                if (!userManager.Users.Any(u => u.UserName == "shimmy"))
        //                {
        //                    var user = new ApplicationUser
        //                    {
        //                        UserName = "shimmy",
        //                        Email = "shimmy@gmail.com",
        //                        EmailConfirmed = true,
        //                        PhoneNumber = "0123456789",
        //                        PhoneNumberConfirmed = true
        //                    };

        //                    await userManager.CreateAsync(user, "****");
        //                    await userManager.AddToRoleAsync(user.Id, ApplicationRole.AdminRoleName);
        //                }
        //    }
        //}


        //public static void SeedRoles (Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        //{
        //    if (!roleManager.RoleExistsAsync("Administrator").Result)
        //    {
        //        IdentityRole role = new IdentityRole();
        //        role.Name = "Admin";       
        //        IdentityResult roleResult = roleManager.CreateAsync(role).Result;


        //    }
        //}


        //        internal static async Task InitAsync(IServiceProvider services)
        //        {
        //            using (var db = services.GetRequiredService<ApplicationDbContext>())
        //            {

        //                if (!db.Users.Any())
        //                {
        //                    var roleStore = new Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<IdentityRole>(db);
        //                    var roleManager = new Microsoft.AspNetCore.Identity.RoleManager<IdentityRole<string>>(roleStore);
        //                    var userStore = new UserStore<ApplicationUser>(db);
        //                    var userManager = new UserManager<ApplicationUser>(userStore);

        //                    // Add missing roles
        //                    var role = roleManager.FindByName("Admin");
        //                    if (role == null)
        //                    {
        //                        role = new IdentityRole("Admin");
        //                        roleManager.Create(role);
        //                    }

        //                    // Create test users
        //                    var user = userManager.FindByName("admin@Gymbokning.se");
        //                    if (user == null)
        //                    {
        //                        var newUser = new ApplicationUser()
        //                        {
        //                            UserName="admin@Gymbokning.se",
        //                            Email = "admin@Gymbokning.se",            
        //                        };
        //                        userManager.Create(newUser, "AdminNet21!");
        //                        userManager.SetLockoutEnabled(newUser.Id, false);
        //                        userManager.AddToRole(newUser.Id, "Admin");
        //                    }
        //        }





    }
}
