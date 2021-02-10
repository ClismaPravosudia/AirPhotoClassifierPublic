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
        
        public SuperPixel(Point[] points)
        {
            _points = points;
        }
    }
}
