using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Data.Models;

namespace TravelAgencyExploreGo.Data
{
    public class TravelAgencyDbContext : DbContext
    {
        public TravelAgencyDbContext()
        {
            
        }
        public TravelAgencyDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<Destination> Destinations { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelAgencyDbContext).Assembly);
        }
    }
}
