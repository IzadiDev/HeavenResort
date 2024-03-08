using HeavenResort_VillaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeavenResort_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa>()
            {
                new Villa{Id= 1, Name = "BeachVilla"},
                new Villa{Id= 2, Name="PoolVilla"}
            };
        }
    }
}
