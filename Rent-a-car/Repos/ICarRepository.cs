using Rent_a_car.Models;

namespace Rent_a_car.Repos
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> FetchAllVehicles();
        Task<Car> RetrieveSingleVehicle(int id);
        Task AddVehicle(Car car);
        Task RemoveVehicle(int id);
        Task ModifyVehicle(Car car);
    }
}
