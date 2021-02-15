﻿using AirPhotoClassifier.Extension;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private List<List<SuperPixel>> categorySuperPixel;

        public SuperPixel[] SuperPixels => _superPixels;
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

        public bool inBorderImage(Point pixel)
        {
            if(pixel.X < _image.Size.Width && pixel.Y < _image.Size.Height)
            {
                return true;
            }
            return false;
        }

        public Image<Bgr, byte> PickSuperPixel(Bgr colorSuperPixel, int x, int y)
        {
            GC.Collect();//Освобождение памяти от предыдущих Image

            Image<Gray, byte> mask = new Image<Gray, byte>( _imageWithMask.Size);
            Image<Bgr, byte> imagePickSuperpixel = new Image<Bgr, byte>( _imageWithMask.Size);
            _imageWithMask.CopyTo(imagePickSuperpixel);

            int indexSuperPixel = _superPixelsToImage[y,x];
            SuperPixel superPixel = _superPixels[indexSuperPixel];
            for(int i=0; i< superPixel.Size;i++)
            {
                Point pixel = superPixel.GetPixel(i).Coordinates;
                mask.Data[pixel.X, pixel.Y, 0] = 255;
            }
            imagePickSuperpixel.FillMask(colorSuperPixel, mask);
            return imagePickSuperpixel;
        }

        public Image<Bgr, byte> PickSuperPixel(Bgr colorSuperPixel, Point pixel)
        {
            return PickSuperPixel(colorSuperPixel, pixel.X, pixel.Y);
        }

        public Image<Bgr, byte> FillSuperPixel(Category category, Point pixel)
        {
            int indexSuperPixel = _superPixelsToImage[pixel.Y,pixel.X];
            SuperPixel superPixel = _superPixels[indexSuperPixel];
            category.SuperPixels.Add(superPixel);
            Color color = category.BackColor;
            Bgr   newColor = new Bgr( color.B, color.G, color.R);
            Image<Bgr,byte> image = PickSuperPixel(newColor, pixel.X, pixel.Y);
            _imageWithMask = image.Mat;
            return image;
        }
        public Image<Bgr, byte> FillSuperPixel(Category category, int indexSuperPixel)
        {
            GC.Collect();//Освобождение памяти от предыдущих Image

            Image<Gray, byte> mask = new Image<Gray, byte>( _imageWithMask.Size);
            Image<Bgr, byte> imagePickSuperpixel = new Image<Bgr, byte>( _imageWithMask.Size);
            _imageWithMask.CopyTo(imagePickSuperpixel);

            SuperPixel superPixel = _superPixels[indexSuperPixel];
            for (int i = 0; i < superPixel.Size; i++)
            {
                Point pixel = superPixel.GetPixel(i).Coordinates;
                mask.Data[pixel.X, pixel.Y, 0] = 255;
            }
            Color color = category.BackColor;
            imagePickSuperpixel.FillMask(new Bgr(color.B, color.G, color.R), mask);
            _imageWithMask = imagePickSuperpixel.Mat;
            return imagePickSuperpixel;
        }
        private void _CreateSuperPixelArray(int countSuperPixel)
        {
            //Считаем размеры каждого суперпикселя
            int[] sizeSuperPixels = new int[countSuperPixel];
            for (int x = 0; x < _superPixelsToImage.GetLength(0); x++)
            {
                for (int y = 0; y < _superPixelsToImage.GetLength(1); y++)
                {
                    sizeSuperPixels[_superPixelsToImage[x, y]]++;
                }
            }
            //Создаем массив суперпикселей
            _superPixels = new SuperPixel[countSuperPixel];
            for (int i = 0; i < _superPixels.Length; i++)
            {
                _superPixels[i] = new SuperPixel(sizeSuperPixels[i]);
            }

            byte[,,] colors =(byte[,,]) _image.GetData();

            //Заполняем массив суперпикселей
            for (int x = 0; x < _superPixelsToImage.GetLength(0); x++)
            {
                for (int y = 0; y < _superPixelsToImage.GetLength(1); y++)
                {
                    Pixel pixel       = new Pixel();
                    pixel.Color       = new Bgr(colors[x, y, 0], colors[x, y, 1], colors[x, y, 2]);
                    pixel.Coordinates = new Point(x, y);
 
                    _superPixels[_superPixelsToImage[x, y]].AddPixel(pixel);
                }
            }
            

        }


    }
}
