using Microsoft.AspNetCore.Mvc;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Web.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationsService destinationsService;

        public DestinationsController(IDestinationsService destinationsService)
        {
            this.destinationsService = destinationsService;
        }

        public IActionResult Index()
        {
            List<Destination> destinations = destinationsService.GetAllDestinations();

            return View(destinations);
        }
    }
}
