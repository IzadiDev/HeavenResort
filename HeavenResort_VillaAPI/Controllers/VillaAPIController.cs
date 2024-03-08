using HeavenResort_VillaAPI.Models;
using HeavenResort_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HeavenResort_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return new List<VillaDTO>()
            {
                new VillaDTO{Id= 1, Name = "BeachVilla"},
                new VillaDTO{Id= 2, Name="PoolVilla"}
            };
        }
    }
}
