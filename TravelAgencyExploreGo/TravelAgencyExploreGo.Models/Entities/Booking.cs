using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data.Models.Enums;

namespace TravelAgencyExploreGo.Data.Models.Entities
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(TripId))]
        public Guid TripId { get; set; }
        public virtual Trip Trip { get; set; } = null!;

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        [Range(EntityValidation.BookingPeopleCountValueMin, EntityValidation.BookingPeopleCountValueMax)]
        public int PeopleCount { get; set; }

        [Range(typeof(decimal), EntityValidation.BookingTotalPriceValueMin, EntityValidation.BookingTotalPriceValueMax)]
        public decimal TotalPrice { get; set; }
        public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;
    }
}
