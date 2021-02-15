using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Components
{
    public struct Pixel
    {
        public Point Coordinates { get; set; }

        private Bgr _color;
        public Bgr Color { get { return _color; } set { _color = value; } }

        public double Brightness
        {
            get
            {
                return 0.299*Color.Red+ 0.597*Color.Green+ 0.114*Color.Blue;
            }
        }

        public Bgr UpBrightness(double value)
        {
            _color.Red += 0.299 * value;
            _color.Green += 0.597 * value;
            _color.Blue += 0.114 * value;
            return _color;
        }
    }
}
