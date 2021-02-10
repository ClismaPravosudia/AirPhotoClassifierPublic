using AirPhotoClassifier.Components;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.XImgproc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private ImportImage import = new ImportImage();
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBarSizeSuperpixel_Scroll(object sender, EventArgs e)
        {
            fieldSizeSuperpixel.Value = trackBarSizeSuperpixel.Value;
        }

        private void trackBarRuler_Scroll(object sender, EventArgs e)
        {
            fieldRuler.Value = trackBarRuler.Value;
        }

        private void buttonImportImage_Click(object sender, EventArgs e)
        {
            import.OpenWindow();
            imageBoxOriginal.Image = import.GetImage();
        }

        private void buttonStartSegmentation_Click(object sender, EventArgs e)
        {
            Mat image = import.GetImage();
            SupperpixelSLIC supperpixel = new SupperpixelSLIC(image,
                                                              SupperpixelSLIC.Algorithm.SLIC,
                                                              (int)  fieldSizeSuperpixel.Value,
                                                              (float)fieldRuler.Value);
            supperpixel.Iterate();


            Matrix<byte> mask= new Matrix<byte>(image.Size);


            supperpixel.GetLabelContourMask(mask);

            Matrix<byte> maskss= new Matrix<byte>(image.Size);

            CvInvoke.BitwiseNot(mask, mask);

            Matrix<byte> masks= new Matrix<byte>(image.Size);
            image.CopyTo(mask, mask);


            //ПРИМЕР РАБОТЫ С СУПЕРПИКСЕЛЯМИ
            Mat mat = new Mat();
            supperpixel.GetLabels(mat);
            int[,] array = (int[,]) mat.GetData();

            imageBoxSegmentation.Image = mask;

        }

        private void fieldRuler_ValueChanged(object sender, EventArgs e)
        {
            int ruler = (int)fieldRuler.Value;
            if (ruler <= trackBarRuler.Maximum && ruler >= trackBarRuler.Minimum)
            {
                trackBarRuler.Value = ruler;
            }
        }

        private void fieldSizeSuperpixel_ValueChanged(object sender, EventArgs e)
        {
            
            int sizeSuperpixel = (int)fieldSizeSuperpixel.Value;
            if (sizeSuperpixel <= trackBarSizeSuperpixel.Maximum && sizeSuperpixel >= trackBarSizeSuperpixel.Minimum)
            {
                trackBarSizeSuperpixel.Value = sizeSuperpixel;
            }
        }
    }
}
