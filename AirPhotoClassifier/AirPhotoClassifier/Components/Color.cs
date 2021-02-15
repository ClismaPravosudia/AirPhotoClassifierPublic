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
            Color result = new Color();
            result.Blue = o.Blue + color.Blue;
            result.Green = o.Green + color.Green;
            result.Red = o.Red + color.Red;
            return result;
        }
        public static Color operator -(Color o, Color color)
        {
            Color result = new Color();
            result.Blue = o.Blue - color.Blue;
            result.Green = o.Green - color.Green;
            result.Red = o.Red - color.Red;
            return result;
        }

        public static Color operator / (Color o, int value)
        {
            Color result = new Color();
            result.Blue = o.Blue / value;
            result.Green = o.Green / value;
            result.Red = o.Red / value;
            return result;
        }

        public static Color operator *(Color o, Color color)
        {
            Color result = new Color();
            result.Blue = o.Blue * color.Blue;
            result.Green = o.Green * color.Green;
            result.Red = o.Red * color.Red;
            return result;
        }

        public static Color operator *(Color o, double value)
        {
            Color result = new Color();
            result.Blue = o.Blue*value;
            result.Green = o.Green*value;
            result.Red = o.Red*value;
            return result;
        }
        public static Color operator < (Color o, Color color)
        {
            Color result = new Color();
            result.Blue = o.Blue < color.Blue ? o.Blue : color.Blue;
            result.Green = o.Green < color.Green ? o.Green : color.Green;
            result.Red = o.Red < color.Red ? o.Red : color.Red;
            return result;
        }
        public static Color operator > (Color o, Color color)
        {
            Color result = new Color();
            result.Blue = o.Blue > color.Blue ? o.Blue : color.Blue;
            result.Green = o.Green > color.Green ? o.Green : color.Green;
            result.Red = o.Red > color.Red ? o.Red : color.Red;
            return result;
        }
    }
}
