using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeavenResort_VillaAPI.Models.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field can not be empty.Please try again😉")]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Details { get; set; }

        [Required]
        public double Rate { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public int Sqft { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public string Amenity { get; set; }
    }
}
