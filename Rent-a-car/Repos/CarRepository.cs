using Microsoft.EntityFrameworkCore;
using Rent_a_car.DAL;
using Rent_a_car.Models;

namespace Rent_a_car.Repos
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Car>> FetchAllVehicles()
        {
            var cars = await _dbContext.cars.Include(b => b.user).ToListAsync();
            return cars;
        }

        public async Task<Car> RetrieveSingleVehicle(int id)
        {
            return await _dbContext.cars.Include(b => b.user).FirstOrDefaultAsync(b => b.CarId == id);
        }

        public async Task AddVehicle(Car car)
        {
            await _dbContext.cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveVehicle(int id)
        {
            var car = await _dbContext.cars.FirstOrDefaultAsync(b => b.CarId == id);
            if (car != null)
            {
                _dbContext.cars.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task ModifyVehicle(Car car)
        {
            _dbContext.Entry(car).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
//00013374