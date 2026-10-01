using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models;

namespace TravelAgencyExploreGo.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(EntityValidation.userFirstNameLengthMax);

            entity
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(EntityValidation.userLastNameLengthMax);

            entity
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
