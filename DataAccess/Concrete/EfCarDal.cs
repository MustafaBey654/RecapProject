using DataAccess.Abstracts;
using DataAccess.Concrete.InMemories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarDal : ICarDal
    {
        private InMemoryContext _context;

        public EfCarDal(InMemoryContext context)
        {
            _context = context;
        }

        public void Add(Car car)
        {
           _context.Cars.Add(car);
        }

        public void Delete(Car car)
        {
           var myCar = _context.Cars.SingleOrDefault(c=>c.Id == car.Id);
            if(myCar is not null)
            {
                _context.Cars.Remove(myCar);
            }
            else
            {
                throw new Exception("not found");
            }
        }

        public List<Car> GetAll()
        {
            return _context.Cars;
        }

        public Car GetById(int id)
        {
            var car = _context.Cars.Find(c => c.Id == id);
            if(car is not null)
            {
                return car;
            }
            else
            {
                 throw new Exception("not found car");
            }
        }

        public void Update(Car car)
        {
            var mycar = _context.Cars.FirstOrDefault(c => c.Id == car.Id);
            mycar.DailyPrice = car.DailyPrice;
            mycar.ModelYear = car.ModelYear;
            mycar.BrandId = car.BrandId;
            mycar.ColorId = car.ColorId;
            mycar.Description = car.Description;
            

        }  
    }
}
