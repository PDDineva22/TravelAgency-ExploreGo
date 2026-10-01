using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Data.Models
{
    public class Destination
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(EntityValidation.destinationNameLengthMax, MinimumLength = EntityValidation.destinationNameLengthMin)]
        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(EntityValidation.destinationCountryLengthMax, MinimumLength = EntityValidation.destinationCountryLengthMin)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(EntityValidation.destinationDescriptionLengthMax, MinimumLength = EntityValidation.destinationDescriptionLengthMin)]
        public string Description { get; set; } = null!;
        
        [Url]
        [Required]
        [MaxLength(EntityValidation.destinationImageUrlLengthMax)]
        public string ImageUrl { get; set; } = null!;
        public virtual ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
