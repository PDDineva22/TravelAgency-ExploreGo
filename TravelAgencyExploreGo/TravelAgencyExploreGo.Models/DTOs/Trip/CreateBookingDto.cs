using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
