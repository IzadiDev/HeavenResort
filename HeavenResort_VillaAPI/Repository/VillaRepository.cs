using HeavenResort_VillaAPI.Data;
using HeavenResort_VillaAPI.Models;
using HeavenResort_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HeavenResort_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db):base(db)
        {

            _db = db;
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _dbSet.Update(entity);
            await SaveAsync();
            return entity;
        }

    }
}
