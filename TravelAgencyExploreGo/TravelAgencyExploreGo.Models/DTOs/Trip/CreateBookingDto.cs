using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Models.DTOs.Trip
{
    public class CreateBookingDto
    {
        public Guid TripId { get; set; }
        [Required]
        [Range(EntityValidation.BookingPeopleCountValueMin, EntityValidation.BookingPeopleCountValueMax)]
        public int PeopleCount { get; set; }
    }
}
