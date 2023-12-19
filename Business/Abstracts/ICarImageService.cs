
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Abstracts
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IDataResult<CarImage> GetByImageCar(int imageId);
        Stream GetCarImageStream(int carId);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file  ,CarImage carImage);
        IDataResult<List<CarImage>> GetCarImages();
    }
}
