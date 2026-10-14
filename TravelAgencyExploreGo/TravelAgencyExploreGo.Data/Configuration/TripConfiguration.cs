using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Data.Configuration
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
                .HasMaxLength(EntityValidation.TripTitleLengthMax);

            entity
                .Property(t => t.Price)
                .HasPrecision(18, 2);

            entity
                .Property(t => t.ImageUrl1)
                .IsRequired()
                .HasMaxLength(EntityValidation.TripImageUrlLengthMax);

            entity
                .Property(t => t.ImageUrl2)
                .IsRequired()
                .HasMaxLength(EntityValidation.TripImageUrlLengthMax);

            entity
                .Property(t => t.ImageUrl3)
                .IsRequired()
                .HasMaxLength(EntityValidation.TripImageUrlLengthMax);

            entity
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(EntityValidation.TripDescriptionLengthMax);

            entity
                .HasOne(t => t.Destination)
                .WithMany(d => d.Trips)
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
