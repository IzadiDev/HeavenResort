using HeavenResort_VillaAPI.Data;
using HeavenResort_VillaAPI.Models;
using HeavenResort_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HeavenResort_VillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(VillaNumber entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }
    }
}
