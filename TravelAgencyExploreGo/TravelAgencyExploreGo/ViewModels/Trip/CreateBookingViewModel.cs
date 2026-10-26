using System.ComponentModel.DataAnnotations;
using TravelAgencyExploreGo.Common;

namespace TravelAgencyExploreGo.Web.ViewModels.Trip
{
    public class CreateBookingViewModel
    {
        [Required]
        public Guid TripId { get; set; }

        [Required(ErrorMessage = "Please select the number of travelers.")]
        [Range(EntityValidation.BookingPeopleCountValueMin, EntityValidation.BookingPeopleCountValueMax)]
        public int PeopleCount { get; set; } = 1;

    }
}
