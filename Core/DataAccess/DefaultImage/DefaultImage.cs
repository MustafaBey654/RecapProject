using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.DefaultImage
{
    public class DefaultImage : IDisposable
    {

        
        public List<Image> images { get; set; }

        public DefaultImage()
        {
            images = new List<Image>();
        }

        public void Dispose()
        {
            foreach (var image in images)
            {
                image.Dispose();
            }
        }

        public void LoadImagesFromDirectory()
        {
            //Projenin çalışma zamanı dizinine göre resim yolu
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "DefaultLogo");

            foreach (var filePath in Directory.GetFiles(folderPath))
            {
                if (Path.GetExtension(filePath).ToLower() == ".jpg" ||
                    Path.GetExtension(filePath).ToLower() == ".png")
                {
                    Image image = Image.FromFile(filePath);
                    images.Add(image);

                }
            }
        }

    }
}
