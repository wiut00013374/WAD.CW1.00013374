using Microsoft.AspNetCore.Mvc;
using Rent_a_car.Models;
using Rent_a_car.Repos;

namespace Rent_a_car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await _usersRepository.FetchAllUsers();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _usersRepository.RetrieveSingleUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, Users user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            await _usersRepository.ModifyUser(user);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Users>> AddUser(Users user)
        {
            await _usersRepository.AddUser(user);

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _usersRepository.RemoveUser(id);

            return NoContent();
        }
    }
}
//00013374