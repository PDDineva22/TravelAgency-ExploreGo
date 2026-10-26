using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TravelAgencyExploreGo.Data.Models;
using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Data.Seeding
{
    public class IdentitySeeder
    {
        /// <summary>
        /// Creates the default Admin role and administrator account.
        /// Before creating them, it checks if they already exist
        /// to prevent duplicate roles and users in the database
        /// </summary>
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            const string adminRole = "Admin";
            const string adminEmail = "admin@explorego.com";
            const string adminPassword = "Admin123!";

            // Create Admin role (if doesn't exist already)
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                // Create it only if it is missing
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

            if (admin == null)
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

                IdentityResult createResult = await userManager.CreateAsync(admin, adminPassword);
                if (!createResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        string.Join(", ",
                            createResult.Errors.Select(e => e.Description)));
                }
            }

            if (!await userManager.IsInRoleAsync(admin, adminRole))
            {
                IdentityResult roleResult =
                    await userManager.AddToRoleAsync(admin, adminRole);

                if (!roleResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        string.Join(", ",
                            roleResult.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
