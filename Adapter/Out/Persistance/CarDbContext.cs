using Hexagonal.Application.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Adapter.Out.Persistance
{
    public class CarDbContext : DbContext
    {
       public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }

        public DbSet<CarEfEntity> Cars => Set<CarEfEntity>();
    }
}
