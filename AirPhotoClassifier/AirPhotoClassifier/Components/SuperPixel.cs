using Emgu.CV.Structure.Extension;
using System;

namespace AirPhotoClassifier.Components
{
    class SuperPixel
    {
        private Pixel[] _pixels;
        private int     _indexEmptyPixel;
        private Signs   _signs;

        public Pixel[] Pixels => _pixels;
        public int Size => _pixels.Length;
        public Signs Parameteres => _signs;
        public SuperPixel(int size)
        {
            _pixels = new Pixel[size];
            _signs  = new Signs();
        }

        public Pixel GetPixel(int index)
        {
            return _pixels[index];
        }

        public void AddPixel( Pixel pixel)
        {
            if(_indexEmptyPixel >= Size)
            {
                throw new ArgumentOutOfRangeException("SuperPixel переполнен");
            }
            _pixels[_indexEmptyPixel] = pixel;
            _indexEmptyPixel++;

            if(_indexEmptyPixel == Size)
            {
                _signs.Calculate(this);
            }
        }

        public struct Signs
        {
            public int Count { get => 4; }
            private Color _maxColor;
            private Color _minColor;
            private Color _midColor;
            private Color _dispersionColor;

            public Color Maximum => _maxColor ?? Color.Empty;
            public Color Minimum => _minColor ?? Color.Empty;
            public Color Middle => _midColor ?? Color.Empty;
            public Color Dispersion => _dispersionColor ?? Color.Empty;

            public void Calculate(SuperPixel superPixel)
            {
                Color[] colors = new Color[superPixel.Pixels.Length];
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i] = new Color(superPixel.Pixels[i].Color);
                }
                //Находим  minColor, maxColor, midColor
                _minColor = colors[0];
                _maxColor = colors[0];
                {
                    Color sumColors = Color.Empty;
                    foreach (Color color in colors)
                    {
                        _minColor = (_minColor < color);
                        _maxColor = (_maxColor > color);
                        sumColors += color;
                    }
                    _midColor = sumColors / colors.Length;
                }

                {
                    Color sumColors = Color.Empty;
                    foreach (Color color in colors)
                    {
                        Color dif = color - _midColor;
                        sumColors += dif*dif;
                    }
                    _dispersionColor = sumColors / superPixel.Size;
                }
            }
        }
    }


}
