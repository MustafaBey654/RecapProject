using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemories
{
    public class InMemoryContext
    {
        public List<Car> Cars;

        public InMemoryContext()
        {
            Cars =  new List<Car>
        {
            new Car { Id = 1, DailyPrice = 100, ModelYear = 2020, BrandId = 1, ColorId = 1, Description = "Car 1" },
            new Car { Id = 2, DailyPrice = 200, ModelYear = 2021, BrandId = 2, ColorId = 2, Description = "Car 2" },
                    };
        }
    }
}
