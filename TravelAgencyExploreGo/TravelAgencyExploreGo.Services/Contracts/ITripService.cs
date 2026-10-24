using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Services.Contracts
{
    public interface ITripService
    {
        List<Trip> GetExclusiveDeals();
    }
}
