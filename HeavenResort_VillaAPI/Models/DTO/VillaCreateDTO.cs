﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeavenResort_VillaAPI.Models.DTO
{
    public class VillaCreateDTO
    {

        [Required(ErrorMessage ="The Name field can not be empty.Please try again😉")]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Details { get; set; }
            
        [Required]
        public double Rate { get; set; }

        public int Occupancy { get; set; }

        public int Sqft { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }
    }
}
