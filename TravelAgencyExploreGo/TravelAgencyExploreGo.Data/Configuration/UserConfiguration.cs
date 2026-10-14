using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(EntityValidation.UserFirstNameLengthMax);

            entity
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(EntityValidation.UserLastNameLengthMax);

            entity
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
