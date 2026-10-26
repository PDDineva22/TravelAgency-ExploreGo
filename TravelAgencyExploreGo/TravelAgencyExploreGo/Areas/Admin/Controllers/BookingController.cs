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
        /// <summary>
        /// Allows an administrator to approve a pending booking request.
        /// Calls the booking service to confirm the reservation
        /// and a message showing whether the operation was successful or not
        /// </summary>
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
        /// <summary>
        /// Allows an administrator to reject a pending booking request
        /// The request is marked as Cancelled, and the administrator
        /// receives a message showing the result of the operation
        /// </summary>
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
