using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constants;
using Core.DataAccess.DefaultImage;
using Core.DataAccess.InMemoryForImages;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly EfCarImageDal _efCarImageDal;
        private readonly ImageSaver _imageSaver;
        private readonly ICarService _carService;

        public CarImageManager(ICarService carService)
        {
            _efCarImageDal = new EfCarImageDal();
            _carService = carService;
            _imageSaver = new ImageSaver(@"C:\Users\Mustafa\Desktop\NetMauiProjects\RecapProject\Core\DataAccess\DefaultImage\");

        }

      

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var resimler = _efCarImageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (resimler < 5)
            {

               // _efCarImageDal.Add(carImage);
                // ImagePath'i Image türüne dönüştürün
                //using (System.Drawing.Image image = System.Drawing.Image.FromFile(carImage.ImagePath))
                //{

                //    _imageSaver.SaveImage(image);
                //}

                _efCarImageDal.AddFromfile(file,carImage);

                return new SuccessResult(Messages.AddImage);
            }
            else
            {
                return new ErrorResult(Messages.InvalidImage);
            }
        }

        public IResult Delete(CarImage carImage)
        {
            var myCarImage = _efCarImageDal.Get(c => c.Id == carImage.Id);
            if (myCarImage is not null)
            {
                _efCarImageDal.Delete(myCarImage);

                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public Stream GetCarImageStream(int carId)
        {
            var result = _carService.GetCarById(carId);
            if (result.Data is not null)
            {
                var myImageCar = _efCarImageDal.Get(c => c.CarId == carId);
                if (myImageCar is not null)
                {
                    // Assuming ImagePath is the path to the image file
                    var imageStream = File.OpenRead(myImageCar.ImagePath);
                    return imageStream;
                }
                
            }
            else if(result.Data is null)
            {
                throw new Exception("Böyle Bir Araç yok");
            }
            else
            {
                using (DefaultImage defaultImage = new())
                {
                    defaultImage.LoadImagesFromDirectory(); // Load the default images

                    if (defaultImage.images.Any())
                    {
                        var image = defaultImage.images[0];
                        var ms = new MemoryStream();
                        image.Save(ms, ImageFormat.Jpeg);
                        ms.Position = 0; // Reset the stream position to the beginning
                        return ms;
                    }
                    else
                    {
                        throw new Exception("resim yok");
                    }
                }
            }

            throw new Exception("not found");
        }

        public IDataResult<List<CarImage>> GetCarImages()
        {
            
             return new SuccessDataResult<List<CarImage>>(_efCarImageDal.GetAll());

        }

      

        public IDataResult<CarImage> GetByImageCar(int imageId)
        {
            var carImage = _efCarImageDal.GetByCarImage(imageId);
            if (carImage is not null)
            {
                return new SuccessDataResult<CarImage>(carImage);
            }
            else
            {
                return new ErrorDataResult<CarImage>();
            }
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var myCarımage = _efCarImageDal.Get(c => c.Id == carImage.Id);
            if (myCarımage is not null)
            {
                _efCarImageDal.Update(file,carImage);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
