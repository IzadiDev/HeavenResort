using HeavenResort_VillaAPI.Models;

namespace HeavenResort_VillaAPI.Repository.IRepository
{
    public interface IVillaNumberRepository: IRepository<VillaNumber>
    {
        Task UpdateAsync(VillaNumber entity);
    }
}
