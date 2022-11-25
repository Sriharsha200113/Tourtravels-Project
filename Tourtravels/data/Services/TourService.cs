using Microsoft.EntityFrameworkCore;
using Tourtravels.data.Base;
using Tourtravels.data.ViewModels;
using Tourtravels.Models;

namespace Tourtravels.data.Services
{
    public class TourService : EntityBaseRepository<Tour>, ITourService
    {
        private readonly AppDbContext _context;
        public TourService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewTourAsync(NewTourvm data)
        {
            var newTour = new Tour()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                PackageId = data.PackageId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Persons = data.Persons,
                TourCategory = data.TourCategory,
                GuideId = data.GuideId
            };

            _context.Tour.AddAsync(newTour);
            await _context.SaveChangesAsync();

            //places
            foreach (var placeid in data.PlaceIds)
            {
                var newPlace = new Tour_place()
                {
                    TourId = newTour.Id,
                    PlaceId = placeid
                };
                await _context.Tour_Places.AddAsync(newPlace);  

            }
            await _context.SaveChangesAsync();  
        }

        public async Task<Tour> GetTourByIdAsync(int id)
        {
            var tourDetails = await _context.Tour
               .Include(p => p.package)
               .Include(g => g.Guide)
               .Include(tp => tp.Tours_Places).ThenInclude(p => p.place)
               .FirstOrDefaultAsync(n => n.Id == id);
            return tourDetails;
        }

        public async Task<Tourdropdown> GetTourdropdownValues()
        {
            var response = new Tourdropdown()
            {
                Places = await _context.Place.OrderBy(n => n.FullName).ToListAsync(),
                Packages = await _context.Package.OrderBy(n => n.Name).ToListAsync(),
                Guides = await _context.Guides.OrderBy(n => n.FullName).ToListAsync(),
            };


            return response;
        }

        public async Task UpdateTourAsync(NewTourvm data)
        {
            var dbtour = await _context.Tour.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbtour != null)
            {

                dbtour.Name = data.Name;
                dbtour.Description = data.Description;
                dbtour.Price = data.Price;
                dbtour.ImageUrl = data.ImageUrl;
                dbtour.PackageId = data.PackageId;
                dbtour.StartDate = data.StartDate;
                dbtour.EndDate = data.EndDate;
                dbtour.Persons = data.Persons;
                dbtour.TourCategory = data.TourCategory;
                dbtour.GuideId = data.GuideId;

                await _context.SaveChangesAsync();
            }

            var existplace = _context.Tour_Places.Where(n => n.TourId == data.Id).ToList();
            _context.Tour_Places.RemoveRange(existplace);
            await _context.SaveChangesAsync();




            //places
            foreach (var placeid in data.PlaceIds)
            {
                var newPlace = new Tour_place()
                {
                    TourId = data.Id,
                    PlaceId = placeid
                };
                await _context.Tour_Places.AddAsync(newPlace);

            }
            await _context.SaveChangesAsync();
        
        }
    }
}
