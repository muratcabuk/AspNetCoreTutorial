using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using SMS.Core.Enums;

namespace SMS.Core.FileImage
{
   public  class ImageManager: IImageManager
    {

        public  async Task<MemoryStream> AddWatermark(MemoryStream memoryStream, string watermarkText,
            Coordinates coordinates)
        {


            return memoryStream;
        }

        public  async Task<MemoryStream> AddWatermark(MemoryStream memoryStream, string watermarkText,
            Point point)
        {


            return memoryStream;
        }

        public  async Task<MemoryStream> ResizeImage(MemoryStream memoryStream, int width, int height)
        {



            return memoryStream;
        }


    }
}
