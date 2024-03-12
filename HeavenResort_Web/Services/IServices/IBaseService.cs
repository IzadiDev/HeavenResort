using HeavenResort_Web.Models;

namespace HeavenResort_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest aPIRequest);
    }
}
