using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Core.DataAccess.InMemoryForImages
{
    public class ImageSaver
    {
        private string _folderPath;

        public ImageSaver(string folderPath)
        {
            _folderPath=folderPath;
        }

        public void SaveImage(System.Drawing.Image image)
        {
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string fullPath = Path.Combine(_folderPath, fileName);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
