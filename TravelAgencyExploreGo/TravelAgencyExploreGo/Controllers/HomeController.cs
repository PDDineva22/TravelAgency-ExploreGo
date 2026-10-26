using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Models;
using TravelAgencyExploreGo.Models.DTOs.User;
using TravelAgencyExploreGo.Services.Contracts;
using TravelAgencyExploreGo.Web.ViewModels.Home;

namespace TravelAgencyExploreGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITripService tripService;
        private readonly IUserService userService;
        private readonly IBookingService bookingService;

        public HomeController(ITripService tripService, IUserService userService, IBookingService bookingService)
        {
            this.tripService = tripService;
            this.userService = userService;
            this.bookingService = bookingService;
        }

        // Load personal booking information only for logged-in users
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.ExclusiveDeals = tripService.GetExclusiveDeals();
            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
                // Each user should see only their own reservations on the home page
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Guid id;
                if(Guid.TryParse(userId, out id))
                {
                    model.MyBookings = bookingService.GetUserBookings(id);
                    ContactDto? contact = userService.GetUserContact(id);

                    if(contact != null)
                    {
                        model.UserName = contact.FullName;
                    }
                }
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
