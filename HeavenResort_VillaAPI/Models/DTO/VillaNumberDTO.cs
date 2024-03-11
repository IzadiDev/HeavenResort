using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeavenResort_VillaAPI.Models.DTO
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
