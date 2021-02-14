using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emgu.CV.Structure.Extension
{
    public class Color
    {
        public static readonly Color Empty = new Color(new Bgr(0,0,0));
        public double Blue { get { return Bgr.Blue; } set { _bgr.Blue = value; } }
        public double Green { get { return Bgr.Green; } set { _bgr.Green = value; } }
        public double Red { get { return Bgr.Red; } set { _bgr.Red = value; } }

        private Bgr _bgr;
        public Bgr Bgr => _bgr;

        
        public Color() { }

        public Color(Bgr color)
        {
            _bgr = color;
        }

        public static Color operator + (Color o, Color color)
        {
            o.Blue += color.Blue;
            o.Green += color.Green;
            o.Red += color.Red;
            return o;
        }

        public static Color operator / (Color o, int value)
        {
            o.Blue /= value;
            o.Green /= value;
            o.Red /= value;
            return o;
        }
        public static Color operator < (Color o, Color color)
        {
            o.Blue = o.Blue < color.Blue ? o.Blue : color.Blue;
            o.Green = o.Green < color.Green ? o.Green : color.Green;
            o.Red = o.Red < color.Red ? o.Red : color.Red;
            return o;
        }
        public static Color operator > (Color o, Color color)
        {
            o.Blue = o.Blue > color.Blue ? o.Blue : color.Blue;
            o.Green = o.Green > color.Green ? o.Green : color.Green;
            o.Red = o.Red > color.Red ? o.Red : color.Red;
            return o;
        }
    }
}
