using Microsoft.EntityFrameworkCore;

namespace Rent_a_car.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
