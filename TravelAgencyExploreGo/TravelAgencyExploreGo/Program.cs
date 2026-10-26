using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Data.Seeding;
using TravelAgencyExploreGo.Services.Contracts;
using TravelAgencyExploreGo.Services.Services;

namespace TravelAgencyExploreGo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<IDestinationsService, DestinationsService>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            builder.Services.AddDbContext<TravelAgencyDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services
                .AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<TravelAgencyDbContext>()
                .AddDefaultTokenProviders();

            // Requirements
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Email requirements
                options.User.RequireUniqueEmail = true;

                // Password requirements
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            using (IServiceScope scope = app.Services.CreateScope())
            {
                await IdentitySeeder.SeedAsync(scope.ServiceProvider);

                TravelAgencyDbContext dbContext = scope.ServiceProvider.GetRequiredService<TravelAgencyDbContext>();
                await ExploreGoSeeder.SeedAsync(dbContext);
            }

                // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
