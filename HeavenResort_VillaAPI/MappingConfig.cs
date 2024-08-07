﻿using AutoMapper;
using HeavenResort_VillaAPI.Models;
using HeavenResort_VillaAPI.Models.DTO;

namespace HeavenResort_VillaAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
            CreateMap<VillaNumber,VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
