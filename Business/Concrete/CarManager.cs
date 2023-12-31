﻿

using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;

using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTO;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly EfCarDal _efCarDal;

        public CarManager()
        {
            _efCarDal = new EfCarDal();
        }

        [CacheRemoveAspect("ICarService.GetAll")] // ürün ekleme yapıldıktan sonra get ile ilgili tüm cache leri sil.
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect] // burada yapılan bir hata veri tabanına eklenmeden dönecek.
        public IResult Add(Car entity)
        {
           
                _efCarDal.Add(entity);
                return new SuccessResult(Messages.AddCar);
            
           
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

        [CacheAspect]
        [SecuredOperation("car.list")]
        [PerformanceAspect(10)] // 10 saniyeden fazla sürerse log düşecek.
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
                return new SuccessDataResult<Car>(car);
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
