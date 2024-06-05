using Microsoft.EntityFrameworkCore;
using Rent_a_car.DAL;
using Rent_a_car.Models;

namespace Rent_a_car.Repos
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Users>> FetchAllUsers()
        {
            var users = await _dbContext.users.ToListAsync();
            return users;
        }

        public async Task<Users> RetrieveSingleUser(int id)
        {
            return await _dbContext.users.FirstOrDefaultAsync(b => b.UserId == id);
        }

        public async Task AddUser(Users user)
        {
            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveUser(int id)
        {
            var users = await _dbContext.users.FirstOrDefaultAsync(b => b.UserId == id);
            if (users != null)
            {
                _dbContext.users.Remove(users);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task ModifyUser(Users users)
        {
            _dbContext.Entry(users).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
