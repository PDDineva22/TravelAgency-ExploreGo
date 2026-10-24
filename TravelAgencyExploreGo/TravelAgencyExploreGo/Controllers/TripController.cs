using Microsoft.AspNetCore.Mvc;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Web.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService tripService;

        public TripController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        public IActionResult Index()
        {
            List<Trip> trips = tripService.GetAllTrips();

            return View(trips);
        }
    }
}
