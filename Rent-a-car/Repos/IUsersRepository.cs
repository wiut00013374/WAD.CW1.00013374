using Rent_a_car.Models;

namespace Rent_a_car.Repos
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> FetchAllUsers();
        Task<Users> RetrieveSingleUser(int id);
        Task AddUser(Users user);
        Task ModifyUser(Users user);
        Task RemoveUser(int id);
    }
}
