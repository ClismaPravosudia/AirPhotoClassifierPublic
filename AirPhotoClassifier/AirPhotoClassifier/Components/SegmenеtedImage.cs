using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Components
{
    class SegmenеtedImage
    {
        private Mat _mask;
        private Mat _image;
        private Mat _imageWithMask;

        private SuperPixel[] _superPixels;
        private int[,]       _superPixelsToImage;

        public SegmenеtedImage(Segmentation algorithm)
        {
            _image              = algorithm.GetInputImage();
            _mask               = algorithm.GetSuperPixelContourMask();
            _superPixelsToImage = algorithm.GetSuperPixelsToImage();
            //Инвентирование маски
            CvInvoke.BitwiseNot(_mask, _mask);
            //Наложение маски на изображение
            _imageWithMask = new Mat();
            _image.CopyTo(_imageWithMask, _mask);
            _CreateSuperPixelArray(algorithm.SuperPixelCount);
        }
        public Mat OriginalImage
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

        public Mat ImageWithContourMask
        {
            get
            {
                return _imageWithMask;
            }
        }

        private void _CreateSuperPixelArray(int size)
        {
            //Считаем размеры каждого суперпикселя
            int[] sizeSuperPixels = new int[size];
            for (int x = 0; x < _superPixelsToImage.GetLength(0); x++)
            {
                for (int y = 0; y < _superPixelsToImage.GetLength(1); y++)
                {
                    sizeSuperPixels[_superPixelsToImage[x, y]]++;
                }
            }
            //Заполняем массив суперпикселей
            _superPixels = new SuperPixel[size];
            for(int i = 0; i < _superPixels.Length; i++)
            {
                Point[] points = new Point[sizeSuperPixels[i]];
                int indexPoints = 0;
                for (int x = 0; x < _superPixelsToImage.GetLength(0); x++)
                {
                    for (int y = 0; y < _superPixelsToImage.GetLength(1); y++)
                    {
                        if(_superPixelsToImage[x,y] == i)
                        {
                            points[indexPoints].X = x;
                            points[indexPoints].Y = y;
                            indexPoints++;
                        }
                    }
                }
                _superPixels[i] = new SuperPixel(points);
            }
        }


    }
}
