using AutoMapper;
using HeavenResort_Web.Models;
using HeavenResort_Web.Models.DTO;

namespace HeavenResort_Web
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa,VillaDTO>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
