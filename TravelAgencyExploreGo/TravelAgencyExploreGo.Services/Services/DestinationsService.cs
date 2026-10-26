using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Services.Services
{
    public class DestinationsService : IDestinationsService
    {
        private readonly TravelAgencyDbContext dbContext;

        public DestinationsService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddDestination(Destination destination)
        {
            destination.Id = Guid.NewGuid();
            dbContext.Destinations.Add(destination);
            dbContext.SaveChanges();
        }

        public bool DeleteDestination(Guid id)
        {
            Destination? destination = dbContext.Destinations.Find(Id);

            if (destination == null)
            {
                return false;
            }
            bool hasTrips = dbContext.Trips.Any(t => t.DestinationId == id);
            if (hasTrips)
            {
                return false;
            }

            dbContext.Destinations.Remove(destination);
            dbContext.SaveChanges();
            return true;
        }

        public bool EditDestination(Destination destination)
        {
            Destination? existing = dbContext.Destinations.Find(destination.Id);

            if (existing == null)
            {
                return false;
            }
            existing.Name = destination.Name;
            existing.Country = destination.Country;
            existing.Description = destination.Description;
            existing.ImageUrl = destination.ImageUrl;

            dbContext.SaveChanges();
            return true;
        }

        public Destination? GetDestinationById(Guid id)
        {
            return dbContext.Destinations.Find(id);
        }
        public List<Destination> GetAllDestinations()
        {
            return dbContext.Destinations
                .OrderBy(d => d.Country)
                .ThenBy(d => d.Name)
                .ThenBy(d => d.Country)
                .ThenByDescending(d => d.Description)
                .ToList();
        }
    }
}
