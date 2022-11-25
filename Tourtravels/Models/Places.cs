

using System.ComponentModel.DataAnnotations;
using Tourtravels.data.Base;

namespace Tourtravels.Models
{
    public class Places : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture ")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public String FullName { get; set; }

      
        public  List<Tour_place> Tours_Places { get; set; }

    }
}
