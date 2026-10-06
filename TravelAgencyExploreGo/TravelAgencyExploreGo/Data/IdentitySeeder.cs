using Microsoft.AspNetCore.Identity;
using TravelAgencyExploreGo.Data.Models;

namespace TravelAgencyExploreGo.Data
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            const string adminRole = "Admin";
            const string adminEmail = "admin@explorego.com";
            const string adminPassword = "Admin123!";

            // Create Admin role (if doesn't exist already)
            if(!await roleManager.RoleExistsAsync(adminRole))
            {
                IdentityRole<Guid> role = new IdentityRole<Guid>(adminRole)
                {
                    Id = Guid.NewGuid()
                };

                IdentityResult roleResult = await roleManager.CreateAsync(role);

                if (!roleResult.Succeeded)
                {
                    throw new Exception(string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                }
            }

            // Find Admin user (if there is any)
            User? admin = await userManager.FindByEmailAsync(adminEmail);

            // Create Admin if doesn't exist
            if(admin == null)
            {
                admin = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "System",
                    LastName = "Admin"
                };

                IdentityResult userResult = await userManager.CreateAsync(admin, adminPassword);

                if (!userResult.Succeeded)
                {
                    throw new Exception(string.Join(", ", userResult.Errors.Select(e => e.Description)));
                }

                if(!await userManager.IsInRoleAsync(admin, adminRole))
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(admin, adminRole);

                    if (!roleResult.Succeeded)
                    {
                        throw new Exception(string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                    }
                }
            }
        }
    }
}
