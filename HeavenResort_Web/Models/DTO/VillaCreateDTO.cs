using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeavenResort_Web.Models.DTO
{
    public class VillaCreateDTO
    {

        [Required(ErrorMessage ="The Name field can not be empty.Please try again😉")]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Details { get; set; }
            
        [Required(ErrorMessage ="The Rate field can not be empty😉")]
        public double Rate { get; set; }

        [Required(ErrorMessage ="The Occupancy can not be empty😉")]
        public int Occupancy { get; set; }
        [Required(ErrorMessage = "The Sqft can not be empty😉")]
        public int Sqft { get; set; }

        public string? ImageUrl { get; set; }

        public string? Amenity { get; set; }
    }
}
