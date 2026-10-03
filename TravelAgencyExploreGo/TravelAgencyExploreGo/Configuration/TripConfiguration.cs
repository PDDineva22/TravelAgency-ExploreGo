using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models;

namespace TravelAgencyExploreGo.Configuration
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> entity)
        {
            entity
                .HasKey(t => t.Id);

            entity
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(EntityValidation.tripTitleLengthMax);

            entity
                .Property(t => t.Price)
                .HasPrecision(18, 2);

            entity
                .Property(t => t.ImageUrl1)
                .IsRequired()
                .HasMaxLength(EntityValidation.tripImageUrlLengthMax);

            entity
                .Property(t => t.ImageUrl2)
                .IsRequired()
                .HasMaxLength(EntityValidation.tripImageUrlLengthMax);

            entity
                .Property(t => t.ImageUrl3)
                .IsRequired()
                .HasMaxLength(EntityValidation.tripImageUrlLengthMax);

            entity
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(EntityValidation.tripDescriptionLengthMax);

            entity
                .HasOne(t => t.Destination)
                .WithMany(d => d.Trips)
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
