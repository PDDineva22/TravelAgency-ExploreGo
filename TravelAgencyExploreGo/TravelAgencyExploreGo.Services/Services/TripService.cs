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
        public void AddTrip(Trip trip)
        {
            trip.Id = Guid.NewGuid();

            dbContext.Trips.Add(trip);
            dbContext.SaveChanges();
        }

        public bool DeleteTrip(Guid id)
        {
            Trip? trip = dbContext.Trips.Find(id);
            if (trip == null)
            {
                return false;
            }
            if(dbContext.Bookings.Any(b => b.TripId == id))
            {
                return false;
            }

            dbContext.Trips.Remove(trip);
            dbContext.SaveChanges();

            return true;
        }

        public bool EditTrip(Trip trip)
        {
            Trip? existingTrip = dbContext.Trips.Find(trip.Id);

            if (existingTrip == null)
            {
                return false;
            }

            if (dbContext.Bookings.Any(b => b.TripId == trip.Id))
            {
                return false;
            }

            existingTrip.Title = trip.Title;
            existingTrip.Description = trip.Description;
            existingTrip.StartDate = trip.StartDate;
            existingTrip.EndDate = trip.EndDate;
            existingTrip.Price = trip.Price;
            existingTrip.DiscountPrice = trip.DiscountPrice;
            existingTrip.AvailableSeats = trip.AvailableSeats;
            existingTrip.Image1 = trip.Image1;
            existingTrip.Image2 = trip.Image2;
            existingTrip.DestinationId = trip.DestinationId;

            dbContext.SaveChanges();

            return true;
        }
        public Trip? GetTripById(Guid id)
        {
            return dbContext.Trips.Find(id);
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
