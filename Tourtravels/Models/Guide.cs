using System.ComponentModel.DataAnnotations;
using Tourtravels.data.Base;

namespace Tourtravels.Models
{
    public class Guide :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public String FullName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio Graphy is required")]
        public String   Bio { get; set; }

        //Relastionships
        public List<Tour> tours { get; set; }
    }
}
