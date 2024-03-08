using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeavenResort_VillaAPI.Models.DTO
{
    public class VillaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The Name field can not be empty.Please try again😉")]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Occupancy { get; set; }
        public int Sqft { get; set; }
    }
}
