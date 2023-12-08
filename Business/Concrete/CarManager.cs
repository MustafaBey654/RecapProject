using Business.Abstracts;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly EfCarDal _efCarDal;

        public CarManager(EfCarDal efCarDal)
        {
            _efCarDal = efCarDal;
        }

        public void Add(Car car)
        {
            _efCarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _efCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
           return _efCarDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _efCarDal.GetById(id);
        }

        public void Update(Car car)
        {
            _efCarDal.Update(car);
        }
    }
}
