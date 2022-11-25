using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Tourtravels.data;
using Tourtravels.data.Services;
using Tourtravels.Models;
namespace Tourtravels.Controllers
{
    
    public class PackagesController : Controller
    {
        private readonly IPackageService _service;

        public PackagesController(IPackageService service)
        {
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }


        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Image,Name,Description")] Package package)
        {
            if (!ModelState.IsValid)
            {
                await _service.AddAsync(package);
                return RedirectToAction(nameof(Index));
            }
            return View(package);
        }

        //Details
        
        public async Task<IActionResult> Details(int id)
        {
            var packageDetails = await _service.GetByIdAsync(id);
            if (packageDetails == null) return View("NotFound");
            return View(packageDetails);
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var packageDetails = await _service.GetByIdAsync(id);
            if (packageDetails == null) return View("NotFound");
            return View(packageDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Name,Description")] Package package)
        {
            if (!ModelState.IsValid)
            {
                await _service.UpdateAsync(id, package);
                return RedirectToAction(nameof(Index));
            }
        
            return View(package);
        }   

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var packageDetails = await _service.GetByIdAsync(id);
            if (packageDetails == null) return View("NotFound");
            return View(packageDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var packageDetails = await _service.GetByIdAsync(id);
            if (packageDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
