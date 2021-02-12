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
        private Point[] _points;
        private int     _indexEmptyPoint;
        private Bgr[]   _colors;
  
        public int Size
        {
            get { return _points.Length; }
        }
        public SuperPixel(int size)
        {
            _points = new Point[size];
        }
        public SuperPixel(Point[] points)
        {
            _points = points;
        }

        public Point GetPixel(int index)
        {
            return _points[index];
        }

        public void AddPixel(Point coordinates)
        {
            if(_indexEmptyPoint < _points.Length)
            {
                _points[_indexEmptyPoint] = coordinates;
                _indexEmptyPoint++;
            }
            else
            {
                throw new ArgumentOutOfRangeException("SuperPixel переполнен");
            }
        }
    }
}
