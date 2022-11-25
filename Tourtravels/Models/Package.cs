using System.ComponentModel.DataAnnotations;
using Tourtravels.data.Base;
using Tourtravels.data;

namespace Tourtravels.Models
{
    public class Package :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Package")]
        public string Image { get; set; }
        [Display(Name = "Name of the package")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public List<Tour> tours { get; set; }

    }
}
