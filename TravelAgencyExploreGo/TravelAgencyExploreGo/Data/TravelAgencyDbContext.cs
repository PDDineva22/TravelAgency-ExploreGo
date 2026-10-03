using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Data.Models;

namespace TravelAgencyExploreGo.Data
{
    public class TravelAgencyDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public TravelAgencyDbContext()
        {
            
        }
        public TravelAgencyDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<Destination> Destinations { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelAgencyDbContext).Assembly);
        }
    }
}
