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
        public Bgr Color { get; set; }

        public double Brightness
        {
            get
            {
                return 0.299*Color.Red+ 0.597*Color.Green+ 0.114*Color.Blue;
            }
        }

    }
}
