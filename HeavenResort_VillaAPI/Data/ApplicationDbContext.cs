using HeavenResort_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeavenResort_VillaAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }
    }
}
