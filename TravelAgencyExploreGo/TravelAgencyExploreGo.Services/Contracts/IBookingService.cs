using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Models.DTOs.Trip;

namespace TravelAgencyExploreGo.Services.Contracts
{
    public interface IBookingService
    {
        bool CreateBooking(Guid userId, CreateBookingDto dto);
        List<Booking> GetUserBookings(Guid userId);
        List<Booking> GetAllBookings();

        bool ConfirmBooking(Guid bookingId);
        bool RejectBooking(Guid bookingId);
        bool CancelBooking(Guid bookingId, Guid userId);
    }
}
