using Business.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetAll();
            if (result.Data == null)
            {
                return BadRequest(result.Message);
            }
            else
            {

                return Ok(result.Data);
            }
        }


        [HttpGet("{colorId}")]

        public IActionResult GetColorById([FromRoute(Name = "colorId")] int colorId)
        {
            var result = _colorService.GetColorById(colorId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddColor")]

        public IActionResult AddColor([FromBody] Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateColor")]

        public IActionResult UpdateColor([FromBody] Color color)
        {
            var result = _colorService.GetColorById(color.Id);
            if (result.Success)
            {
                _colorService.Update(color);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveColor([FromRoute(Name = "id")] int id)
        {
            var result = _colorService.GetColorById(id);
            if (result.Success)
            {
                _colorService.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
