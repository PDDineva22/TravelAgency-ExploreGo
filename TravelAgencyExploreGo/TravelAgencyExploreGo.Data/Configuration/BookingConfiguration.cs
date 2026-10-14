using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Data.Configuration
{

    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> entity)
        {
            entity
                .HasKey(b => b.Id);

            entity
                .Property(b => b.PeopleCount)
                .IsRequired()
                .HasMaxLength(EntityValidation.BookingPeopleCountValueMax);

            entity
                .Property(b => b.TotalPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            entity
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(b => b.Trip)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TripId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
