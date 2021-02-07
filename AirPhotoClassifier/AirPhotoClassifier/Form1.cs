using Emgu.CV;

using Emgu.CV.Structure;
using Emgu.CV.XImgproc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirPhotoClassifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Mat image = CvInvoke.Imread("D:\\WORKSPACE\\AirPhotoClassifierPublic\\AirPhotoClassifier\\AirPhotoClassifier\\Photo\\D1PGFIFSLX5R1521056003282.png", Emgu.CV.CvEnum.ImreadModes.AnyColor);

            imageBox1.Image = image;
            
            SupperpixelSLIC supperpixel = new SupperpixelSLIC(image, 
                                                              SupperpixelSLIC.Algorithm.SLIC, 
                                                              30, 
                                                              1);

            Mat imageSLIC = new Mat(new Size(image.Width,image.Height), image.Depth,image.NumberOfChannels, supperpixel.Ptr, image.Step);

            imageBox2.Image = imageSLIC.ToImage<Rgb,byte>();
        }
    }
}
