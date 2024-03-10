using HeavenResort_VillaAPI.Models;
using System.Linq.Expressions;

namespace HeavenResort_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository: IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);  
    }
}
