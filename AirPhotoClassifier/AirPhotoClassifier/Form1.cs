using Emgu.CV;
using Emgu.CV.XImgproc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            Mat img = new Mat();
            img = CvInvoke.Imread("D:\\WORKSPACE\\AirPhotoClassifierPublic\\AirPhotoClassifier\\AirPhotoClassifier\\Photo\\D1PGFIFSLX5R1521056003282.png", Emgu.CV.CvEnum.ImreadModes.AnyColor);
            IInputArray image = img;

            int regionSize = 0;

            float ruler = 0;

            SupperpixelSLIC constructor = new SupperpixelSLIC(image, SupperpixelSLIC.Algorithm.SLIC, regionSize, ruler);
        }
    }
}
