using TripEntity = TravelAgencyExploreGo.Data.Models.Entities.Trip;
using TravelAgencyExploreGo.Data.Models.Entities;
namespace TravelAgencyExploreGo.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<TripEntity> ExclusiveDeals { get; set; } = new List<TripEntity>();
        public List<Booking> MyBookings { get; set; } = new List<Booking>();
        public string UserName { get; set; } = null!;
    }
}
