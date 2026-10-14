using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Data.Models.Entities
{
    public class Trip
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(EntityValidation.TripTitleLengthMax, MinimumLength = EntityValidation.TripTitleLengthMin)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(EntityValidation.TripDescriptionLengthMax, MinimumLength = EntityValidation.TripDescriptionLengthMin)]
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Range(typeof(decimal), EntityValidation.TripPriceValueMin, EntityValidation.TripPriceValueMax)]
        public decimal Price { get; set; }
        [Range(EntityValidation.TripAvailableSeatsCountMin, EntityValidation.TripAvailableSeatsCountMax)]
        public int AvailableSeats { get; set; }
        [Url]
        [Required]
        [MaxLength(EntityValidation.TripImageUrlLengthMax)]
        public string ImageUrl1 { get; set; } = null!;
        [Url]
        [Required]
        [MaxLength(EntityValidation.TripImageUrlLengthMax)]
        public string ImageUrl2 { get; set; } = null!;
        [Url]
        [Required]
        [MaxLength(EntityValidation.TripImageUrlLengthMax)]
        public string ImageUrl3 { get; set; } = null!;
        [ForeignKey(nameof(DestinationId))]
        public Guid DestinationId { get; set; }
        public virtual Destination Destination { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
