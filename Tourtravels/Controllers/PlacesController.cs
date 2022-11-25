using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Tourtravels.data;
using Tourtravels.data.Services;
using Tourtravels.Models;

namespace Tourtravels.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlacesService _service;
        public PlacesController(IPlacesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName")]Places places)
        {
           
            if(!ModelState.IsValid)
            {
                await _service.AddAsync(places);
                return RedirectToAction(nameof(Index));

            }
                return View(places);

            
           
        }

        public async Task<IActionResult> Details(int id)
        {
            var PlaceDetails = await _service.GetByIdAsync(id);
            if (PlaceDetails == null) return View("Not Found");
            return View(PlaceDetails);
        }

        public async Task <IActionResult> Edit(int id)
        {

            var PlaceDetails = await _service.GetByIdAsync(id);
            if (PlaceDetails == null) return View("Not Found");
            return View(PlaceDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureUrl,FullName")] Places places)
        {
              if(!ModelState.IsValid)
            {
                await _service.UpdateAsync(id, places);
                return RedirectToAction(nameof(Index));

            }
                return View(places);

            
           
            
        }

        public async Task<IActionResult> Delete(int id)
        {

            var PlaceDetails = await _service.GetByIdAsync(id);
            if (PlaceDetails == null) return View("Not Found");
            return View(PlaceDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            var PlaceDetails = await _service.GetByIdAsync(id);
            if (PlaceDetails == null)
            {
                return View("Not Found");
            }
            
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));

            





        }
    }
}
