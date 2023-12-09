

using Business.Abstracts;
using Business.Constants;
using Core.Utilities;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTO;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly EfCarDal _efCarDal;

        public CarManager()
        {
            _efCarDal = new EfCarDal();
        }

        public IResult Add(Car entity)
        {
            if(entity != null && entity.Description.Length>2 && entity.DailyPrice>0)
            {
                _efCarDal.Add(entity);
                return new SuccessResult(Messages.AddCar);
            }
            else
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
        }

        public IResult Delete(int carId)
        {
            var car = _efCarDal.Get(c=>c.Id== carId);
            if(car != null)
            {
                _efCarDal.Delete(car);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _efCarDal.GetAll(),Messages.CarListed);
        }

     

        public IDataResult<Car> GetById(int id)
        {
            var car = _efCarDal.Get(c=>c.Id==id);
            if(car != null)
            {
                return new SuccessDataResult<Car>( car);
            }
            else
            {
                return new ErrorDataResult<Car>();
            }
        }

        public IDataResult<Car> GetCarById(int carId)
        {
            var car = _efCarDal.Get(c => c.Id == carId);
            if(car is null)
            {
                return new ErrorDataResult<Car>();
            }
            else
            {
                return new SuccessDataResult<Car>();
            }
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_efCarDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_efCarDal.GetAll(b => b.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_efCarDal.GetAll(c=>c.ColorId==colorId));
        }

        public IResult Update(Car entity)
        {
          if(entity == null)
            {
                return new ErrorResult();
            }
            else
            {
                _efCarDal.Update(entity);
                return new SuccessResult();
            }
        }

       
      

      
    }
}
