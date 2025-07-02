using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Practice.Infrastructure.DataSeed
{
    public static  class IdentitySeeder
    {
        public static async Task SeedRoleandAdminAsync(IServiceProvider serviceprovider)
        {
            var roleManager = serviceprovider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceprovider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "user", "admin" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin@123";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = "Admin",
                    Email = adminEmail,

                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "admin");
                }

            }
        }
    }
}
