using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Services.Services
{
    public class TripService : ITripService
    {
        private readonly TravelAgencyDbContext dbContext;

        public TripService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public List<Trip> GetAllTrips()
        {
            return dbContext.Trips
                .Include(t => t.Destination)
                .OrderBy(t => t.StartDate)
                .ThenBy(t => t.DiscountPrice)
                .ThenByDescending(t => t.AvailableSeats)
                .ToList();
        }

        public List<Trip> GetExclusiveDeals()
        {
            return dbContext.Trips
                .Include(t => t.Destination)
                .Where(t => t.DiscountPrice != null && t.DiscountPrice < t.Price)
                .OrderBy(t => t.DiscountPrice)
                .ThenBy(t => t.Title)
                .Take(3)
                .ToList();
        }
    }
}
