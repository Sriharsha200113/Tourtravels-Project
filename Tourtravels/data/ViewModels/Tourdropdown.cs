using Tourtravels.Models;

namespace Tourtravels.data.ViewModels
{
    public class Tourdropdown
    {
        public Tourdropdown()
        {
            Guides = new List<Guide>();
            Packages = new List<Package>();
            Places = new List<Places>();
        }

        public List<Guide> Guides { get; set; }
        public List<Package> Packages { get; set; }
        public List<Places> Places { get; set; }
    }
}
