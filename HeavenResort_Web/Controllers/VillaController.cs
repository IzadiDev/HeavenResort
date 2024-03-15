using AutoMapper;
using HeavenResort_Web.Models;
using HeavenResort_Web.Models.DTO;
using HeavenResort_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HeavenResort_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var list = new List<VillaDTO>();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if(response.Result != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public IActionResult CreateVilla()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO villaCreateDTO)
        {
            if(ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(villaCreateDTO);
                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View(villaCreateDTO);
        }

        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);
            if(response != null && response.IsSuccess)
            {
                var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaUpdateDTO>(villa));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO villaUpdateDTO)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaUpdateDTO.Id);
            if (response != null && response.IsSuccess)
            {
                await _villaService.UpdateAsync<APIResponse>(villaUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(UpdateVilla), new {villaId=villaUpdateDTO.Id});
        }

        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);
            if (response != null && response.IsSuccess)
            {
                var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(villa);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO villaDTO)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaDTO.Id);
            if (response != null && response.IsSuccess)
            {
                await _villaService.DeleteAsync<APIResponse>(villaDTO.Id);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(DeleteVilla), new { villaId = villaDTO.Id });
        }
    }
}
