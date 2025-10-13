using KSocial.Data.Helpers.Constants;
using KSocial.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSocial.Data.Helpers
{
    public static class DbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                foreach (var roleName in AppRoles.All)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                    }
                }
            }

            if (!userManager.Users.Any())
            {
                var userPassword = "Test@00";

                var newAdmin = new User()
                {
                    UserName = "admin.admin",
                    Email = "admin@admin.admin",
                    FullName = "Admin",
                    ProfilePictureUrl = "",
                    EmailConfirmed = true
                };

                var resultNewAdmin = await userManager.CreateAsync(newAdmin, userPassword);
                if (resultNewAdmin.Succeeded)
                    await userManager.AddToRoleAsync(newAdmin, AppRoles.Admin);
            }
        }
    }
}
