
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Components
{
    class SuperPixel
    {
        private Pixel[] _pixels;
        private int     _indexEmptyPixel;


        private Parameteres signs;

        public Pixel[] Pixels => _pixels;
        public int Size => _pixels.Length;

        public SuperPixel(int size)
        {
            _pixels = new Pixel[size];
        }

        public Pixel GetPixel(int index)
        {
            return _pixels[index];
        }

        public void AddPixel( Pixel pixel)
        {
            if(_indexEmptyPixel < Size)
            {
                _pixels[_indexEmptyPixel] = pixel;
                _indexEmptyPixel++;
            }
            else
            {
                throw new ArgumentOutOfRangeException("SuperPixel переполнен");
            }
        }

        public class Parameteres
        {
            private Bgr maxColor;
            private Bgr minColor;
            private Bgr midColor;
            private Bgr dispersionColor;

            public void Calculate(SuperPixel superPixel)
            {
                Bgr[] colors = new Bgr[superPixel.Pixels.Length];
                double[] allcolors = new double[3];
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i] = superPixel.Pixels[i].Color;
                    allcolors[0] += colors[i].Blue;
                    allcolors[1] += colors[i].Green;
                    allcolors[2] += colors[i].Red;
                }

                allcolors[0] /= colors.Length;
                allcolors[1] /= colors.Length;
                allcolors[2] /= colors.Length;
                midColor = new Bgr(allcolors[0], allcolors[1], allcolors[2]);

                maxColor = colors[0];
                minColor = colors[0];
                for (int i = 0; i < colors.Length; i++)
                {
                   
                }
            }


        }
    }


}
