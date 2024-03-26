using AutoMapper;
using HeavenResort_Web.Models;
using HeavenResort_Web.Models.DTO;
using HeavenResort_Web.Services;
using HeavenResort_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HeavenResort_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<VillaNumberDTO> villaNumbers = new();
            var response = await _villaNumberService.GetAllAsync<APIResponse>();
            if(response !=null && response.IsSuccess)
            {
                villaNumbers = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(villaNumbers);
        }


        public IActionResult CreateVillaNumber()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateDTO villaNumberCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<APIResponse>(villaNumberCreateDTO);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(villaNumberCreateDTO);
        }

        public async Task<IActionResult> UpdateVillaNumber(int villaNO)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNO);
            if (response != null && response.IsSuccess)
            {
                var villa = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaNumberUpdateDTO>(villa));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateDTO villaNumberUpdateDTO)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNumberUpdateDTO.VillaNo);
            if (response != null && response.IsSuccess)
            {
                await _villaNumberService.UpdateAsync<APIResponse>(villaNumberUpdateDTO);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(UpdateVillaNumber), new { villaId = villaNumberUpdateDTO.VillaNo });
        }

        public async Task<IActionResult> DeleteVillaNumber(int villaNO)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNO);
            if (response != null && response.IsSuccess)
            {
                var villa = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                return View(villa);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDTO villaNumberDTO)
        {
            var response = await _villaNumberService.GetAsync<APIResponse>(villaNumberDTO.VillaNo);
            if (response != null && response.IsSuccess)
            {
                await _villaNumberService.DeleteAsync<APIResponse>(villaNumberDTO.VillaNo);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(DeleteVillaNumber), new { villaNO = villaNumberDTO.VillaNo });
        }
    }
}
