using Microsoft.AspNetCore.Mvc;
using Tourtravels.data;
using Microsoft.EntityFrameworkCore;
using Tourtravels.data.Services;
using Tourtravels.Models;

namespace Tourtravels.Controllers
{
    public class GuidesController : Controller
    {
        private readonly IGuidesService _service;
        public GuidesController(IGuidesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allGuides = await _service.GetAllAsync();
            return View(allGuides);
        }

        //Details

        public async Task<IActionResult> Details (int id)
        {
            var GuideDetails =await _service.GetByIdAsync(id);
            if(GuideDetails == null) return NotFound();
            return View(GuideDetails);

        }
        //creatw
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName,Bio")]Guide guide)
        {
            if(!ModelState.IsValid)
            {
                await _service.AddAsync(guide);
                return RedirectToAction(nameof(Index)); 
            }
            return View(guide); 
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var GuideDetails = await _service.GetByIdAsync(id);
            if (GuideDetails == null) return NotFound();
            return View(GuideDetails);

           
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureUrl,FullName,Bio")] Guide guide)
        {
            if (id==guide.Id)
            {
                await _service.UpdateAsync(id,guide);
                return RedirectToAction(nameof(Index));
            }
            return View(guide);
        }
        //deel
        public async Task<IActionResult> Delete(int id)
        {
            var GuideDetails = await _service.GetByIdAsync(id);
            if (GuideDetails == null) return NotFound();
            return View(GuideDetails);


        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var GuideDetails = await _service.GetByIdAsync(id);
            if (GuideDetails == null) return NotFound();
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
