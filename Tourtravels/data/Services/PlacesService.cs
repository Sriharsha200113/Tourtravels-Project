using Microsoft.EntityFrameworkCore;
using System.Collections;
using Tourtravels.data.Base;
using Tourtravels.Models;

namespace Tourtravels.data.Services
{
    public class PlacesService : EntityBaseRepository<Places>, IPlacesService
    {
        private readonly AppDbContext _context;
        public PlacesService(AppDbContext context) :base(context) {}

       
    }
}
