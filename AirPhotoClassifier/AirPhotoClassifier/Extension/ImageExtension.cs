using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Extension
{
    static class ImageExtension
    {
        public static Image<Bgr, byte> FillMask( this Image<Bgr,byte> image, Bgr color, Image<Gray, byte> mask)
        {
            image.SetValue(color, mask);
            return image;
        }
    }
}
