using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        public IActionResult Index()
        {
            var bookings = bookingService.GetAllBookings();

            return View(bookings);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(Guid id)
        {
            bool isApproved = bookingService.ConfirmBooking(id);
            if (isApproved)
            {
                TempData["Success"] = "Booking confirmed successfully";
            }
            else
            {
                TempData["Error"] = "Booking could not be confirmed";
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reject(Guid id)
        {
            bool isRejected = bookingService.RejectBooking(id);
            if (isRejected)
            {
                TempData["Success"] = "Booking rejected successfully";
            }
            else
            {
                TempData["Error"] = "Booking could not be rejected";
            }

            return RedirectToAction("Index");
        }
    }
}
