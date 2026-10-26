using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelAgencyExploreGo.Models.DTOs.Trip;
using TravelAgencyExploreGo.Services.Contracts;
using TravelAgencyExploreGo.Web.ViewModels.Trip;

namespace TravelAgencyExploreGo.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateBookingViewModel model)
        {
            if(!ModelState.IsValid || model.TripId == Guid.Empty)
            {
                TempData["BookingError"] = "Please check your booking information!";
                return RedirectToAction("Index", "Trip");
            }
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(!Guid.TryParse(userId, out Guid id))
            {
                return Unauthorized();
            }

            CreateBookingDto dto = new CreateBookingDto
            {
                TripId = model.TripId,
                PeopleCount = model.PeopleCount
            };

            bool created = bookingService.CreateBooking(id, dto);

            if (!created)
            {
                TempData["BookingError"] = "Booking failed. Please check trip availability.";

                return RedirectToAction("Index", "Trip");
            }

            TempData["BookingSuccess"] = "Your booking request has been sent to our team!";

            return RedirectToAction("Index", "Trip");
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(Guid id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userId, out Guid currentUserId))
            {
                return Unauthorized();
            }

            bool cancelled = bookingService.CancelBooking(id, currentUserId);

            if (cancelled)
            {
                TempData["BookingSuccess"] = "Your booking has been cancelled!";
            }
            else
            {
                TempData["BookingError"] = "Booking could not be cancelled.";
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
