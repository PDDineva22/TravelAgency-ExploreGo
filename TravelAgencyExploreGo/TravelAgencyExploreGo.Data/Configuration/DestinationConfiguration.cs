using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Data.Configuration
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
                .HasMaxLength(EntityValidation.DestinationNameLengthMax);

            entity
                .Property(d => d.Country)
                .IsRequired()
                .HasMaxLength(EntityValidation.DestinationCountryLengthMax);

            entity
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(EntityValidation.DestinationDescriptionLengthMax);

            entity
                .Property(d => d.ImageUrl)
                .IsRequired()
                .HasMaxLength(EntityValidation.DestinationImageUrlLengthMax);
        }
    }
}
