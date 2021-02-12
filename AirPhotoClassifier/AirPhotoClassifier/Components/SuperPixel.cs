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
        private Bgr[]   _colors;
        public int Size
        {
            get { return _points.Length; }
        }
        public SuperPixel(Point[] points)
        {
            _points = points;
        }

        public Point GetPixel(int index)
        {
            return _points[index];
        }
    }
}
