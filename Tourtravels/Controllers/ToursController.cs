using Microsoft.AspNetCore.Mvc;
using Tourtravels.data;
using Microsoft.EntityFrameworkCore;
using Tourtravels.data.Services;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tourtravels.Models;


namespace Tourtravels.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService _service;
        public ToursController(ITourService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var alltours = await _service.GetAllAsync(n=> n.package);
            return View(alltours);
        }

        //details
        public async Task<IActionResult> Details(int id)
        {
            var TourDetail = await _service.GetTourByIdAsync(id);
            return View(TourDetail);
        }

        //create
        public async Task<IActionResult> Create()
        {
            var tourdropdown = await _service.GetTourdropdownValues();
            ViewBag.Packages = new SelectList(tourdropdown.Packages, "Id", "Name");
            ViewBag.Guides = new SelectList(tourdropdown.Guides, "Id", "FullName");
            ViewBag.Places = new SelectList(tourdropdown.Places, "Id", "FullName");
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(NewTourvm tour)
        {

            if(!ModelState.IsValid)
            {
                var tourdropdown = await _service.GetTourdropdownValues();
                ViewBag.Packages = new SelectList(tourdropdown.Packages, "Id", "Name");
                ViewBag.Guides = new SelectList(tourdropdown.Guides, "Id", "FullName");
                ViewBag.Places = new SelectList(tourdropdown.Places, "Id", "FullName");
                return View();
            }
            await _service.AddNewTourAsync(tour);
            return RedirectToAction(nameof(Index));
        }

        //edit

        public async Task<IActionResult> Edit(int id)
        {
            var tourDetails = await _service.GetTourByIdAsync(id);
            if (tourDetails == null) return View("Not Fpund");

            var response = new NewTourvm()
            {
                Id = tourDetails.Id,
                Name = tourDetails.Name,
                Description = tourDetails.Description,
                Price = tourDetails.Price,
                StartDate = tourDetails.StartDate,
                EndDate = tourDetails.EndDate,
                Persons = tourDetails.Persons,
                ImageUrl = tourDetails.ImageUrl,
                TourCategory = tourDetails.TourCategory,
                PackageId = tourDetails.PackageId,
                GuideId = tourDetails.GuideId,
                PlaceIds = tourDetails.Tours_Places.Select(n => n.PlaceId).ToList(),
            };
            var tourdropdown = await _service.GetTourdropdownValues();
            ViewBag.Packages = new SelectList(tourdropdown.Packages, "Id", "Name");
            ViewBag.Guides = new SelectList(tourdropdown.Guides, "Id", "FullName");
            ViewBag.Places = new SelectList(tourdropdown.Places, "Id", "FullName");
            return View(response);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id,NewTourvm tour)
        {
            if (id != tour.Id) return View("Not Found");
            if(!ModelState.IsValid)
            {
                var tourdropdown = await _service.GetTourdropdownValues();
                ViewBag.Packages = new SelectList(tourdropdown.Packages, "Id", "Name");
                ViewBag.Guides = new SelectList(tourdropdown.Guides, "Id", "FullName");
                ViewBag.Places = new SelectList(tourdropdown.Places, "Id", "FullName");
                return View();
            }
            await _service.UpdateTourAsync(tour);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Sunny()
        {
            return View("OrderCompleted");
        }

    }
}
