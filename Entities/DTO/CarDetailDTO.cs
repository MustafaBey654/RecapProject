using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CarDetailDTO
    {
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public decimal Price { get; set; }
    }
}
