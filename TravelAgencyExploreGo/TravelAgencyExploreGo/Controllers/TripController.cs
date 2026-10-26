using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Models.DTOs.User;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Web.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService tripService;
        private readonly IUserService userService;

        public TripController(ITripService tripService, IUserService userService)
        {
            this.tripService = tripService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            List<Trip> trips = tripService.GetAllTrips();

            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                Guid id;
                if(Guid.TryParse(userId, out id))
                {
                    ContactDto? contact = userService.GetUserContact(id);

                    if(contact != null)
                    {
                        ViewBag.FullName = contact.FullName;
                        ViewBag.Email = contact.Email;
                        ViewBag.PhoneNumber = contact.PhoneNumber;
                    }
                }
            }
            return View(trips);
        }
    }
}
