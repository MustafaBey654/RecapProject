using Business.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _userService.GetAllUser();
            if (result.Data == null)
            {
                return BadRequest(result.Message);
            }
            else
            {

                return Ok(result.Data);
            }
        }


        [HttpGet("{userId}")]

        public IActionResult GetUserById([FromRoute(Name = "userId")] int userId)
        {
            var result = _userService.GetUserById(userId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddUser")]

        public IActionResult AddUser([FromBody] User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateUser")]

        public IActionResult UpdateUser([FromBody] User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                _userService.Update(user);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveUser([FromRoute(Name = "id")] int id)
        {
            var result = _userService.GetUserById(id);
            if (result.Success)
            {
                _userService.Delete(result.Data);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
