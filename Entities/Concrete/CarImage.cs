using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstracts;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime SaveDate { get; set; }


        public CarImage()
        {
            // Resim yolu GUID ile oluşturulur ve tarih sistem tarafından atanır.
            ImagePath = Guid.NewGuid().ToString();
            SaveDate = DateTime.Now;
        }



    }
}
