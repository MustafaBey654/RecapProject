using Business.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var result = _brandService.GetAll();
            if (result.Data == null)
            {
                return BadRequest(result.Message);
            }
            else
            {

                return Ok(result.Data);
            }
        }


        [HttpGet("{brandId}")]

        public IActionResult GetBrandById([FromRoute(Name = "brandId")]int brandId)
        {
            var result = _brandService.GetBrandById(brandId);

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

        public IActionResult Add([FromBody]Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateBrand")]
    
        public IActionResult UpdateBrand([FromBody]Brand brand)
        {
            var result = _brandService.GetBrandById(brand.Id);
            if (result.Success)
            {
                _brandService.Update(brand);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveBrand([FromRoute(Name ="id")]int id)
        {
            var result = _brandService.GetBrandById(id);
            if (result.Success)
            {
                _brandService.Delete(result.Data.Id);
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
