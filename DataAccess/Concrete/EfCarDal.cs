
using Core.DataAccess.Eframework;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarDal:BaseRepository<Car,EfDbContext>,ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using(var context = new EfDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Colors
                             on c.ColorId equals r.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDTO
                             {
                                 CarID = c.Id,
                                 ColorName = r.Name,
                                 BrandName = b.Name,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 Price = c.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
