using Business.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public IActionResult GetAllRentals()
        {
            var result = _rentalService.GetAll();
            if (result.Data == null)
            {
                return BadRequest(result.Message);
            }
            else
            {

                return Ok(result.Data);
            }
        }


        [HttpGet("{rentalId}")]

        public IActionResult GetRentalById([FromRoute(Name = "rentalId")] int rentalId)
        {
            var result = _rentalService.GetRentalById(rentalId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddRental")]

        public IActionResult AddCustomer([FromBody] Rental rental)
        {
            var result = _rentalService.AddRental(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateRental")]

        public IActionResult UpdateRental([FromBody] Rental rental)
        {
            var result = _rentalService.GetRentalById(rental.Id);
            if (result.Success)
            {
                _rentalService.UpdateRental(rental);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveRental([FromRoute(Name = "id")] int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result.Success)
            {
                _rentalService.RemoveRental(result.Data);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
