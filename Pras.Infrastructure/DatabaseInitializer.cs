using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Pras.DAL.Entities;
using Pras.Shared.Config;

namespace Pras.InfrastructureSt
{
    public class DatabaseInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AppSettings appSettings)
        {
            string adminName = "Admin";
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminName, EmailConfirmed = true };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            if (Boolean.Parse(appSettings.IsClient))
            {
                if (await userManager.FindByNameAsync("test@pras.by") == null)
                {
                    ApplicationUser test = new ApplicationUser { Email = "test@pras.by", UserName = "TestAdmin", EmailConfirmed = true };
                    IdentityResult result = await userManager.CreateAsync(test, "TestAdmin");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(test, "Admin");
                    }
                }

                if (await userManager.FindByNameAsync("sila.fm") == null)
                {
                    ApplicationUser test = new ApplicationUser { Email = "info@sila.fm", UserName = "sila.fm", EmailConfirmed = true };
                    IdentityResult result = await userManager.CreateAsync(test, "Mikalaj2020");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(test, "Admin");
                    }
                }
            }
        }
    }
}
