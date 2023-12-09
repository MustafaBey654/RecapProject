
using Core.DataAccess.Eframework;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarDal:BaseRepository<Car,EfDbContext>
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using(var context = new EfDbContext())
            {
                var result = from c in context.Cars
                             join r in context.Colors
                             on c.ColorId equals r.Id
                             select new CarDetailDTO
                             {
                                 CarID = c.Id,
                                 Color = r.Name,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 Price = c.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
