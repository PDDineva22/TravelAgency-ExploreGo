using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Services.Contracts
{
    public interface IDestinationsService
    {
        List<Destination> GetAllDestinations();
        Destination? GetDestinationById(Guid id);
        void AddDestination(Destination destination);
        bool EditDestination(Destination destination);
        bool DeleteDestination(Guid id);
    }
}
