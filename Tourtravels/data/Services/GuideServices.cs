using Tourtravels.data.Base;
using Tourtravels.Models;

namespace Tourtravels.data.Services
{
    public class GuideServices : EntityBaseRepository<Guide>,IGuidesService
    {
        public GuideServices(AppDbContext context) : base(context)
        {

        }
    }
}
