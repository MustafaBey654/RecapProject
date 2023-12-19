
using Core.DataAccess.Eframework;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Abstracts
{
    public interface ICarImageDal :IEntityRepository<CarImage>
    {
        void AddFromfile(IFormFile file, CarImage carImage);
        CarImage GetByCarImage(int id);
        void Update(IFormFile file, CarImage carImage);
    }
}
