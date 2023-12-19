using Business.Abstracts;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageCarController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public ImageCarController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }




        [HttpGet]
        public IActionResult GetAllCarImages()
        {
            var result = _carImageService.GetCarImages();
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

        public IActionResult GetImageById([FromRoute(Name = "carId")] int carId)
        {
            var result = _carImageService.GetCarImageStream(carId);

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateCarImage")]

        public IActionResult UpdateImageCar([FromForm(Name = "Image")] IFormFile file,[FromForm] CarImage carImage)
        {
            var result = _carImageService.GetByImageCar(carImage.CarId);
            if (result.Data is not null)
            {
                _carImageService.Update(file, carImage);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("{imageId}")]
        public IActionResult RemoveCarImage([FromRoute(Name = "imageId")] int imageId)
        {
            var result = _carImageService.GetByImageCar(imageId);
            if (result is not null)
            {
               
                _carImageService.Delete(result.Data);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }





    }
}
