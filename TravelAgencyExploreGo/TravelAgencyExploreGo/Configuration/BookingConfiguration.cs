using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models;

namespace TravelAgencyExploreGo.Configuration
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
                .HasMaxLength(EntityValidation.bookingPeopleCountValueMax);

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
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
