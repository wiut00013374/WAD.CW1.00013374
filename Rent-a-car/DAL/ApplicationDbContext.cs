using Microsoft.EntityFrameworkCore;
using Rent_a_car.Models;

namespace Rent_a_car.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Car> cars { get; set; }
        public DbSet<Users> users { get; set; }
    }
}
