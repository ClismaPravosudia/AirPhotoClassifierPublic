﻿using Emgu.CV;
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

        }

        private void buttonStartSegmentation_Click(object sender, EventArgs e)
        {
            Mat image = CvInvoke.Imread("D:\\WORKSPACE\\AirPhotoClassifierPublic\\AirPhotoClassifier\\AirPhotoClassifier\\Photo\\D1PGFIFSLX5R1521056003282.png", Emgu.CV.CvEnum.ImreadModes.AnyColor);

            imageBoxOriginal.Image = image;

            SupperpixelSLIC supperpixel = new SupperpixelSLIC(image,
                                                              SupperpixelSLIC.Algorithm.SLIC,
                                                              10,
                                                              10);
            supperpixel.Iterate(10);


            Matrix<byte> mask= new Matrix<byte>(image.Size);


            supperpixel.GetLabelContourMask(mask);

            Matrix<byte> maskss= new Matrix<byte>(image.Size);

            CvInvoke.BitwiseNot(mask, mask);

            Matrix<byte> masks= new Matrix<byte>(image.Size);
            image.CopyTo(mask, mask);


            //ПРИМЕР РАБОТЫ С СУПЕРПИКСЕЛЯМИ
            Mat mat = new Mat();
            supperpixel.GetLabels(mat);


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
