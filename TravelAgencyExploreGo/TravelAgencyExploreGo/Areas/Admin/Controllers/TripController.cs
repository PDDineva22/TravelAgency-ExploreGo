using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TripController : Controller
    {
        private readonly ITripService tripService;
        private readonly IDestinationsService destinationsService;

        public TripController(ITripService tripService, IDestinationsService destinationsService)
        {
            this.tripService = tripService;
            this.destinationsService = destinationsService;
        }
        public IActionResult Index()
        {
            List<Trip> trips = tripService.GetAllTrips();
            return View(trips);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Destinations = destinationsService.GetAllDestinations();

            Trip trip = new Trip();
            return View("Form", trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trip trip)
        {
            ModelState.Remove("Destination");
            ModelState.Remove("Bookings");
            ValidateTrip(trip);

            if (!ModelState.IsValid)
            {
                ViewBag.Destinations = destinationsService.GetAllDestinations();
                return View("Form", trip);
            }
            tripService.AddTrip(trip);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Trip? trip = tripService.GetTripById(id);
            if (trip == null)
            {
                return NotFound();
            }

            ViewBag.Destinations = destinationsService.GetAllDestinations();
            return View("Form", trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Trip trip)
        {
            ModelState.Remove("Destination");
            ModelState.Remove("Bookings");

            ValidateTrip(trip);
            if (!ModelState.IsValid)
            {
                ViewBag.Destinations = destinationsService.GetAllDestinations();
                return View("Form", trip);
            }

            bool success = tripService.EditTrip(trip);

            if (success == false)
            {
                TempData["Error"] = "Trip cannot be edited if it has bookings.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            bool success = tripService.DeleteTrip(id);

            if (success == false)
            {
                TempData["Error"] = "Trip cannot be deleted if it has bookings.";
            }

            return RedirectToAction("Index");
        }

        private void ValidateTrip(Trip trip)
        {
            if (trip.StartDate.Date < DateTime.Today)
            {
                ModelState.AddModelError("StartDate", "Start date cannot be in the past.");
            }

            if (trip.EndDate <= trip.StartDate)
            {
                ModelState.AddModelError("EndDate", "End date must be after start date.");
            }

            if (trip.DiscountPrice.HasValue && trip.DiscountPrice.Value >= trip.Price)
            {
                ModelState.AddModelError("DiscountPrice", "Discount price must be lower than price.");
            }

            Destination? destination = destinationsService
                .GetAllDestinations()
                .FirstOrDefault(d => d.Id == trip.DestinationId);

            if (destination == null)
            {
                ModelState.AddModelError("DestinationId", "Choose a destination.");
            }
        }
    }
}
