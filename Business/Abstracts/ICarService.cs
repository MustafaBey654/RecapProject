using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int brandId);

        IDataResult<Car> GetCarById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int carId);

        IDataResult<List<CarDetailDTO>> GetCarDetails();


    }
}
