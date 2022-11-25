using System.ComponentModel.DataAnnotations;

namespace Tourtravels.Models
{
    public class Tour_place
    {
       
        
        public int TourId { get; set; }
        public Tour tour { get; set; } 
        public int PlaceId { get; set; }
        public Places place {get; set; }


    }
}
