using CA.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Data.Db
{
    public interface IAppDbContext
    {
        DbSet<CarAdvert> Adverts { get; set; }
        DbSet<FuelType> FuelTypes { get; set; }
    }
}