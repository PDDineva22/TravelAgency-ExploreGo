using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Services.Contracts
{
    public interface ITripService
    {
        List<Trip> GetExclusiveDeals();
        List<Trip> GetAllTrips();

        Trip? GetTripById(Guid id);
        void AddTrip(Trip trip);
        bool EditTrip(Trip trip);
        bool DeleteTrip(Guid id);
    }
}
