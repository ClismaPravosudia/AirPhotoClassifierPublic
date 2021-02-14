using AirPhotoClassifier.Components;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
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
using static Emgu.CV.UI.ImageBox;
using Emgu.CV.ML;//библиотека для машинного обучения

namespace AirPhotoClassifier
{
    public partial class Form1 : Form
    {
        private ImportImage     _import;
        private SegmenеtedImage _image;
        //SVM svm;
        RTrees rTrees;

        public Form1()
        {
            InitializeComponent();
            _import = new ImportImage();

            int count = 1;
            Matrix<double> matrix =  new Matrix<double>(3,3);
            for (int width = 0; width < matrix.Cols; width++)
            {
                
                for (int height = 0; height < matrix.Rows; height++)
                {
                    matrix.Data[width, height] = count;
                    count++;
                }
            }
            int x = 0;
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
            _import.OpenWindow();
            imageBoxOriginal.Image = _import.GetImage();
        }

        private void buttonStartSegmentation_Click(object sender, EventArgs e)
        {
            Mat inputImage = _import.GetImage();
            if (inputImage == null)
            {
                return;
            }

            int   sizeSuperPixel = (int)fieldSizeSuperpixel.Value;
            float ruler          = (float)fieldRuler.Value;
            Segmentation segmentation = new  Segmentation(inputImage, sizeSuperPixel, ruler);
            _image = new  SegmenеtedImage(segmentation);
            Classifier.ToMatrix(_image);
            //----------------------------------------
            imageBoxSegmentation.Image = _image.ImageWithContourMask;
            /*
            Size sizeImage = ((Image<Gray,byte>) imageBoxOriginal.Image).Size;
            Size sizeBox =imageBoxOriginal.Size;
            imageBoxOriginal.SetZoomScale(sizeBox.Height / sizeImage.Height, Point.Empty);
            */
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

        private void imageBoxSegmentation_MouseMove(object sender, MouseEventArgs e)
        {
            if(_image == null)
            {
                return;
            }

            Point mousePosition = new Point();
            
            mousePosition.X = imageBoxSegmentation.HorizontalScrollBar.Value + (int)(e.X / imageBoxSegmentation.ZoomScale);
            mousePosition.Y = imageBoxSegmentation.VerticalScrollBar.Value + (int)(e.Y / imageBoxSegmentation.ZoomScale);

            if (_image.inBorderImage(mousePosition))
            {
                imageBoxSegmentation.Image = _image.PickSuperPixel(new Bgr(0, 0, 255), mousePosition);
            }
        }
        private void buttonOpenColorDialog_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void RandomTreeButton_Click(object sender, EventArgs e)
        {
                //try
               // {
                Classifier.GetTrain();
                MessageBox.Show("SVM is trained.");
               // }
                //catch (Exception ex)
                //{
                 //   MessageBox.Show(ex.Message);
                //}
            }
        }
    }

