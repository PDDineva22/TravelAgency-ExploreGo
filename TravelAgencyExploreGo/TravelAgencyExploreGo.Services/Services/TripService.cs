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
        /// <summary>
        /// Deletes a trip only if it has no bookings
        /// </summary>
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
        /// <summary>
        /// Updates the information of an existing trip.
        /// The trip can only be edited if it has no bookings,
        /// to avoid changing details of trips that users have already booked
        /// </summary>
        public bool EditTrip(Trip trip)
        {
            Trip? existingTrip = dbContext.Trips.Find(trip.Id);

            // Do not allow editing trips that already have bookings
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
            List<Trip> allTrips = dbContext.Trips
                .Include(t => t.Destination)
                .OrderBy(t => t.StartDate)
                .ThenBy(t => t.DiscountPrice)
                .ThenByDescending(t => t.AvailableSeats)
                .ToList();

            return allTrips;
        }

        public List<Trip> GetExclusiveDeals()
        {
            List<Trip> exclusiveDeals = dbContext.Trips
                .Include(t => t.Destination)
                .Where(t => t.DiscountPrice != null && t.DiscountPrice < t.Price)
                .OrderBy(t => t.DiscountPrice)
                .ThenBy(t => t.Title)
                .Take(3)
                .ToList();

            return exclusiveDeals;
        }
    }
}
