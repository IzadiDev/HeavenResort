using HeavenResort_Web.Models;
using HeavenResort_Web.Models.DTO;
using HeavenResort_Web.Services.IServices;
using static HeavenResort_Utility.SD;

namespace HeavenResort_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaURL;
        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration):base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaURL = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public async Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
        {
            return await SendAsync<T>(new APIRequest
            {
                APIType = APIType.POST,
                URL = villaURL + "/api/VillaNumberAPI",
                Data = dto
            });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await SendAsync<T>(new APIRequest
            {
                APIType= APIType.DELETE,
                URL = villaURL + "/api/VillaNumberAPI/" + id
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await SendAsync<T>(new APIRequest
            {
                APIType = APIType.GET,
                URL = villaURL + "/api/VillaNumberAPI",
            });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await SendAsync<T>(new APIRequest
            {
                APIType = APIType.GET,
                URL = villaURL+ "/api/VillaNumberAPI/" + id,
                Data= id
            });
        }

        public async Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto)
        {
            return await SendAsync<T>(new APIRequest
            {
                APIType = APIType.PUT,
                URL = villaURL + "/api/VillaNumberAPI/" + dto.VillaNo,
                Data = dto
            });
        }
    }
}
