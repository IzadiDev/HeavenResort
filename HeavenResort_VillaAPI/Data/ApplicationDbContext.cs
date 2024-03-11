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
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.",
                    ImageUrl = "~/Assets/Villa1.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft=550,
                    Amenity="",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                 new Villa()
                 {
                     Id = 2,
                     Name = "Luxury Villa",
                     Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.",
                     ImageUrl = "~/Assets/Villa2.jpg",
                     Occupancy = 3,
                     Rate = 300,
                     Sqft = 400,
                     Amenity = "",
                     CreatedDate = DateTime.Now,
                     UpdatedDate = DateTime.Now,
                 },
                  new Villa()
                  {
                      Id = 3,
                      Name = "Royal Villa",
                      Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.",
                      ImageUrl = "~/Assets/Villa3.jpg",
                      Occupancy = 4,
                      Rate = 400,
                      Sqft = 600,
                      Amenity = "",
                      CreatedDate = DateTime.Now,
                      UpdatedDate = DateTime.Now,
                  },
                   new Villa()
                   {
                       Id = 4,
                       Name = "Royal Villa",
                       Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.",
                       ImageUrl = "~/Assets/Villa4.jpg",
                       Occupancy = 2,
                       Rate = 400,
                       Sqft = 250,
                       Amenity = "",
                       CreatedDate = DateTime.Now,
                       UpdatedDate = DateTime.Now,
                   },
                    new Villa()
                    {
                        Id = 5,
                        Name = "Royal Villa",
                        Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor.",
                        ImageUrl = "~/Assets/Villa5.jpg",
                        Occupancy = 3,
                        Rate = 100,
                        Sqft = 200,
                        Amenity = "",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    }
                );
        }
    }
}
