using Business.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetAllCustomer();
            if (result.Data == null)
            {
                return BadRequest(result.Message);
            }
            else
            {

                return Ok(result.Data);
            }
        }


        [HttpGet("{customerId}")]

        public IActionResult GetCustomerById([FromRoute(Name = "customerId")] int customerId)
        {
            var result = _customerService.GetCustomerById(customerId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddCustomer")]

        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateCustomer")]

        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            var result = _customerService.GetCustomerById(customer.CustomerId);
            if (result.Success)
            {
                _customerService.Update(customer);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveCustomer([FromRoute(Name = "id")] int id)
        {
            var result = _customerService.GetCustomerById(id);
            if (result.Success)
            {
                _customerService.Delete(result.Data);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
