using Tourtravels.data.Base;
using Tourtravels.Models;

namespace Tourtravels.data.Services
{
    public class PackageService :EntityBaseRepository<Package>,IPackageService
    {
        public PackageService(AppDbContext context) :base(context)
        {

        }
    }
}
