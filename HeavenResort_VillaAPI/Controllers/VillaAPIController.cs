using AutoMapper;
using HeavenResort_VillaAPI.Data;
using HeavenResort_VillaAPI.Models;
using HeavenResort_VillaAPI.Models.DTO;
using HeavenResort_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
namespace HeavenResort_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaRepository _dbVilla;
        private readonly ILogger<VillaAPIController> _logger;
        private readonly IMapper _mapper;
        public VillaAPIController(ILogger<VillaAPIController> logger, IVillaRepository dbVilla, IMapper mapper)
        {

            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
            this._response = new APIResponse();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<Villa> villas = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDTO>>(villas);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {


                if (id > 0)
                {
                    var villa = await _dbVilla.GetAsync(filter: u => u.Id == id);
                    if (villa != null)
                    {
                        _response.Result = _mapper.Map<VillaDTO>(villa);
                        _response.StatusCode = HttpStatusCode.OK;
                        _response.IsSuccess = true;
                        return Ok(_response);
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("No Data!");
                        return NotFound(_response);
                    }
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Please provide a valid id");
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO villaCreateDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try
            {
                if (await _dbVilla.GetAsync(filter: u => u.Name.ToLower() == villaCreateDTO.Name.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("The name already exist in database");
                    return BadRequest(_response);
                }
                if (villaCreateDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Please Fill In The Required Values");
                    return BadRequest(_response);
                }
                Villa villa = _mapper.Map<Villa>(villaCreateDTO);
                await _dbVilla.CreateAsync(villa);
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;

                return CreatedAtRoute("GetVilla", new { id = villa.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add(("The id is invalid😕"));
                    return BadRequest(_response);
                }
                var villa = await _dbVilla.GetAsync(filter: u => u.Id == id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add(("The id you entered does not exist in database"));
                    return NotFound(_response);
                }
                await _dbVilla.RemoveAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };

            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaUpdateDTO)
        {
            try
            {
                if (villaUpdateDTO == null || id != villaUpdateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add(("Data not valid"));
                    return BadRequest(_response);
                }
                //var villa = _db.Villas.FirstOrDefault(u => u.Id == id)!;
                //villa.Name = villaDTO.Name;
                //villa.Sqft = villaDTO.Sqft;
                //villa.Occupancy = villaDTO.Occupancy;
                Villa model = _mapper.Map<Villa>(villaUpdateDTO);
                await _dbVilla.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };

            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add(("Data is invalid!"));
                    return BadRequest(_response);
                }
                var villa = _dbVilla.GetAsync(filter: u => u.Id == id, tracked: false);
                VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add(("Villa not found!"));
                    return BadRequest(_response);
                }
                patchDTO.ApplyTo(villaDTO, ModelState);
                Villa model = _mapper.Map<Villa>(villaDTO);
                await _dbVilla.UpdateAsync(model);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add(("You should provide the required fields"));
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

    }
}
