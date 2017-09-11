using CA.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Data.Db
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CarAdvert> Adverts { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
    }
}