using Microsoft.AspNetCore.Mvc;
using Rent_a_car.Models;
using Rent_a_car.Repos;

namespace Rent_a_car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carsRepository;

        public CarController(ICarRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<Car>> GetVehicles()
        {
            return await _carsRepository.FetchAllVehicles();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetVehicle(int id)
        {
            var car = await _carsRepository.RetrieveSingleVehicle(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }
            await _carsRepository.ModifyVehicle(car);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Car>> AddVehicle(Car car)
        {
            await _carsRepository.AddVehicle(car);

            return CreatedAtAction("GetVehicle", new { id = car.CarId }, car);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveVehicle(int id)
        {
            await _carsRepository.RemoveVehicle(id);

            return NoContent();
        }
    }
}
//00013374