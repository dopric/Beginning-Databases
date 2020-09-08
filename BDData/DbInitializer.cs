using BDData.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BDData
{
    public static class DbInitializer
    {

        private async static Task CheckRoleAsync(RoleManager<AppRole> manager, string roleName, string description="not set")
        {
            if(!await manager.RoleExistsAsync(roleName))
            {
                await manager.CreateAsync(new AppRole() { Name = roleName, Description = description });
            }
        }
        public async static Task Seed(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            foreach (var role in new List<string> { "admin", "free" })
            {
                await CheckRoleAsync(roleManager, role);
            }
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                IdentityResult result = await userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    Email = "opric.dragan@gmail.com"
                }, "12345");
                if (result.Succeeded)
                {
                    AppUser user = await userManager.FindByNameAsync("admin");
                    await userManager.AddToRoleAsync(user, "admin");
                }
            }
        }
    }
}
