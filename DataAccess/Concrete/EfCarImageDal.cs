using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Eframework;
using Core.DataAccess.InMemoryForImages;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Abstracts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfCarImageDal : BaseRepository<CarImage, EfDbContext>, ICarImageDal
    {


        public void AddFromfile(IFormFile file, CarImage carImage)
        {
            // Dosyanın adını GUID ile değiştir
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Dosyanın kaydedileceği yol
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DefaultImage", fileName);

            // Dosyanın zaten var olup olmadığını kontrol et
            if (!File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Dosyayı belirtilen yola kaydet
                    file.CopyTo(stream);
                }
            }

            // Dosyanın yolunu CarImage nesnesine ata
            carImage.ImagePath = path;

            // CarImage nesnesini veritabanına ekle
            using (var context = new EfDbContext())
            {
                var addedEntity = context.Entry(carImage);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public CarImage GetByCarImage(int id)
        {
            using (var context = new EfDbContext())
            {
                return context.CarImages.Find(id);
            }
        }

        public void Update(IFormFile file, CarImage carImage)
        {
            // Dosyanın adını GUID ile değiştir
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Dosyanın kaydedileceği yol
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DefaultImage", fileName);

            // Dosyanın zaten var olup olmadığını kontrol et
            if (!File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Dosyayı belirtilen yola kaydet
                    file.CopyTo(stream);
                }
            }

            // Dosyanın yolunu CarImage nesnesine ata
            carImage.ImagePath = path;

            // CarImage nesnesini veritabanında güncelle
            using (var context = new EfDbContext())
            {
                var updatedEntity = context.Entry(carImage);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
