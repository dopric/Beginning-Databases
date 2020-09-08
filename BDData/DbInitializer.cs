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

        private  static void CheckRole(RoleManager<AppRole> manager, string roleName, string description="not set")
        {
            try
            {
                var found =  manager.RoleExistsAsync(roleName).Result;
                if (!found)
                {
                     var res = manager.CreateAsync(new AppRole() { Name = roleName, Description = description }).Result;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static void Seed(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            foreach (var role in new List<string> { "admin", "free" })
            {
                 CheckRole(roleManager, role);
            }
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                IdentityResult result =  userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    Email = "opric.dragan@gmail.com"
                }, "Emi99sgdo$").Result;

                if (result.Succeeded)
                {
                    AppUser user =  userManager.FindByNameAsync("admin").Result;
                     var res = userManager.AddToRoleAsync(user, "admin").Result;
                }
                else
                {
                    throw new Exception("USer can not be created");
                }
            }
        }
    }
}
