using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Models.DTOs.Trip;

namespace TravelAgencyExploreGo.Services.Contracts
{
    public interface IBookingService
    {
        bool CreateBooking(Guid userId, CreateBookingDto dto);
        List<Booking> GetUserBookings(Guid userId);
    }
}
