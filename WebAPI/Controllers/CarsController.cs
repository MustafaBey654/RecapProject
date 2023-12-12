using Business.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public IActionResult GetAllCars()
        {
            var result = _carService.GetAll();
            if (result.Data == null)
            {
                return BadRequest(result.Message);
            }
            else
            {

                return Ok(result.Data);
            }
        }


        [HttpGet("{carId}")]

        public IActionResult GetCarById([FromRoute(Name = "carId")] int carId)
        {
            var result = _carService.GetCarById(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Add")]

        public IActionResult Add([FromBody] Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateCar")]

        public IActionResult UpdateCar([FromBody] Car car)
        {
            var result = _carService.GetCarById(car.Id);
            if (result.Success)
            {
                _carService.Update(car);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveCar([FromRoute(Name = "id")] int id)
        {
            var result = _carService.GetCarById(id);
            if (result.Success)
            {
                _carService.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
