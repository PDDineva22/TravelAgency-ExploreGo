using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DestinationsController : Controller
    {
        private readonly IDestinationsService destinationsService;

        public DestinationsController(IDestinationsService destinationsService)
        {
            this.destinationsService = destinationsService;
        }
        public ActionResult Index()
        {
            return View(destinationsService.GetAllDestinations());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form", new Destination());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Country,Description,ImageUrl")] Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", destination);
            }

            destinationsService.AddDestination(destination);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Destination? destination = destinationsService.GetDestinationById(id);

            if (destination == null)
            {
                return NotFound();
            }

            return View("Form", destination);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Country,Description,ImageUrl")] Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", destination);
            }

            bool success = destinationsService.EditDestination(destination);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            bool success = destinationsService.DeleteDestination(id);

            if (!success)
            {
                TempData["Error"] = "Destination cannot be deleted. It may have trips.";
            }

            return RedirectToAction("Index");
        }
    }
}
