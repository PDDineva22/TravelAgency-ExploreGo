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
