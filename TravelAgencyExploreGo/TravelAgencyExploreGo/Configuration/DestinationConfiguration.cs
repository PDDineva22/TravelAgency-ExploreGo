using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models;

namespace TravelAgencyExploreGo.Configuration
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> entity)
        {
            entity
                .HasKey(d => d.Id);

            entity
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(EntityValidation.destinationNameLengthMax);

            entity
                .Property(d => d.Country)
                .IsRequired()
                .HasMaxLength(EntityValidation.destinationCountryLengthMax);

            entity
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(EntityValidation.destinationDescriptionLengthMax);

            entity
                .Property(d => d.ImageUrl)
                .IsRequired()
                .HasMaxLength(EntityValidation.destinationImageUrlLengthMax);
        }
    }
}
