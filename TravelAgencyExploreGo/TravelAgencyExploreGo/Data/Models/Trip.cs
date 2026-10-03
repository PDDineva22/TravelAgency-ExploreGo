using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Data.Models
{
    public class Trip
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(EntityValidation.tripTitleLengthMax, MinimumLength = EntityValidation.tripTitleLengthMin)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.tripDescriptionLengthMax, MinimumLength = EntityValidation.tripDescriptionLengthMin)]
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Range(typeof(decimal), EntityValidation.tripPraceValueMin, EntityValidation.tripPraceValueMax)]
        public decimal Price { get; set; }
        [Range(EntityValidation.tripAvailableSeatsCountMin, EntityValidation.tripAvailableSeatsCountMax)]
        public int AvailableSeats { get; set; }
        [Url]
        [Required]
        [MaxLength(EntityValidation.tripImageUrlLengthMax)]
        public string ImageUrl1 { get; set; } = null!;
        [Url]
        [Required]
        [MaxLength(EntityValidation.tripImageUrlLengthMax)]
        public string ImageUrl2 { get; set; } = null!;
        [Url]
        [Required]
        [MaxLength(EntityValidation.tripImageUrlLengthMax)]
        public string ImageUrl3 { get; set; } = null!;
        [ForeignKey(nameof(DestinationId))]
        public Guid DestinationId { get; set; }
        public virtual Destination Destination { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
