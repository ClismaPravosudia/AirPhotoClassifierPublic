using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Components
{
    class SegmenеtedImage
    {
        private Mat _mask;
        private Mat _image;

        private SuperPixel[] _superPixels;

        public SegmenеtedImage(Mat image)
        {
            Image = image;
        }
        public Mat Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public Mat Mask
        {
            get
            {
                return _mask;
            }
        }
    }
}
