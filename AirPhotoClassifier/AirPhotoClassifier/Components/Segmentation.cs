using Emgu.CV;
using Emgu.CV.XImgproc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Components
{
    class Segmentation
    {
        private SupperpixelSLIC _algorithm;
        private Mat             _inputImage;
        private int             _sizeSuperPixel;
        public int SuperPixelCount => _algorithm.NumberOfSuperpixels;

        public Segmentation(Mat image, int sizeSuperPixel, float ruler)
        {
            _inputImage = image;
            _algorithm = new SupperpixelSLIC(image, SupperpixelSLIC.Algorithm.SLIC, sizeSuperPixel, ruler);
            _algorithm.Iterate();
        }

        public Mat GetInputImage()
        {
            return _inputImage;
        }
        public Mat GetSuperPixelContourMask()
        {
            Mat mask = new Mat();
            _algorithm.GetLabelContourMask(mask);
            return mask;
        }

        public int[,] GetSuperPixelsToImage()
        {
            Mat mat = new Mat();
            _algorithm.GetLabels(mat);
            return (int[,]) mat.GetData();
        }
    }
}
