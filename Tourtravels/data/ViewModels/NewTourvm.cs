using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tourtravels.data.Base;
using Tourtravels.data;

namespace Tourtravels.Models
{
    public class NewTourvm 
    {
        public int Id { get; set; }

        [Display(Name = "Tour name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Tour description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in ₹")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Tour poster URL")]
        [Required(ErrorMessage = "Tour poster URL is required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Tour start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Tour end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Number of persons")]
        [Required(ErrorMessage = "Number is required")]

        public int Persons { get; set; }
        public TourCategory TourCategory { get; set; }

        //Relationships
        [Display(Name = "Select  Place(s)")]
        [Required(ErrorMessage = "Tour Place(s) is required")]
        public List<int> PlaceIds { get; set; }

        [Display(Name = "Select a Package")]
        [Required(ErrorMessage = "Tour Package is required")]
        public int PackageId { get; set; }

        [Display(Name = "Select a Guide")]
        [Required(ErrorMessage = "Tour Package is required")]
        public int GuideId { get; set; }
    }
}
