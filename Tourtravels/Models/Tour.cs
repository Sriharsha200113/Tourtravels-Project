using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tourtravels.data.Base;
using Tourtravels.data;

namespace Tourtravels.Models
{
    public class Tour : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Persons { get; set; }
        public TourCategory TourCategory { get; set; }

       

        //relationship
        public List<Tour_place> Tours_Places { get; set; }
        //Package
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package package { get; set; }

        //Guide
        public int GuideId { get; set; }
        [ForeignKey("GuideId")]
        public Guide Guide { get; set; }    
        


    }
}
