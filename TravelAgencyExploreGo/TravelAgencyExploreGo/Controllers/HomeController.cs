using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Models;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITripService tripService;

        public HomeController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        public IActionResult Index()
        {
            List<Trip> deals = tripService.GetExclusiveDeals();

            return View(deals);
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
