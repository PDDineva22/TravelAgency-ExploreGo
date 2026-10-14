using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Data.Models.Entities
{
    public class Destination
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(EntityValidation.DestinationNameLengthMax, MinimumLength = EntityValidation.DestinationNameLengthMin)]
        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(EntityValidation.DestinationCountryLengthMax, MinimumLength = EntityValidation.DestinationCountryLengthMin)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(EntityValidation.DestinationDescriptionLengthMax, MinimumLength = EntityValidation.DestinationDescriptionLengthMin)]
        public string Description { get; set; } = null!;
        
        [Url]
        [Required]
        [MaxLength(EntityValidation.DestinationImageUrlLengthMax)]
        public string ImageUrl { get; set; } = null!;
        public virtual ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
