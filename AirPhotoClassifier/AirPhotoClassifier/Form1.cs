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

namespace AirPhotoClassifier
{
    public partial class Form1 : Form
    {
        private ImportImage     _import;
        private SegmenеtedImage _image;
        public Form1()
        {
            InitializeComponent();
            _import = new ImportImage();
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

            progressBar1.Maximum = segmentation.SuperPixelCount;
            SegmenеtedImage.ActionCreateSuperPixel += progressBar1_AddValue;
            progressBar1.Visible = true;

            _image = new  SegmenеtedImage(segmentation);

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            imageBoxOriginal.Image = _image.OriginalImage;
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

        private void progressBar1_AddValue()
        {
            progressBar1.Value++;
        }
    }
}
