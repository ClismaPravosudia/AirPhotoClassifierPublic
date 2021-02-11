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
        private ImportImage import = new ImportImage();
        SupperpixelSLIC supperpixel;
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
            if (image == null)
            {
                return;
            }
            supperpixel = new SupperpixelSLIC(image,
                                            SupperpixelSLIC.Algorithm.SLIC,
                                            (int)fieldSizeSuperpixel.Value,
                                            (float)fieldRuler.Value);
            supperpixel.Iterate();


            Image<Gray, byte> mask= new Image<Gray, byte>(image.Size);


            supperpixel.GetLabelContourMask(mask);

            CvInvoke.BitwiseNot(mask, mask);

            image.CopyTo(mask, mask);
            imageBoxOriginal.Image = mask;

            Size sizeImage = ((Image<Gray,byte>) imageBoxOriginal.Image).Size;
            Size sizeBox =imageBoxOriginal.Size;
            imageBoxOriginal.SetZoomScale(sizeBox.Height / sizeImage.Height, Point.Empty);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Mat mat = new Mat();
            supperpixel.GetLabels(mat);
            int[,] array = (int[,]) mat.GetData();

            Image<Gray,byte> mask = new Image<Gray,byte>(mat.Size);

            for (int width = 0; width < array.GetLength(0); width++)
            {
                for (int height = 0; height < array.GetLength(1); height++)
                {
                    if (array[width, height] != ((int)numericUpDown1.Value) - 1)
                    {
                        mask.Data[width, height, 0] = 255;
                    }

                }
            }

            import.GetImage().CopyTo(mask, mask);

            imageBoxSegmentation.Image = mask;

            Size sizeImage = ((Image<Gray,byte>) imageBoxSegmentation.Image).Size;
            Size sizeBox = imageBoxSegmentation.Size;
            imageBoxSegmentation.SetZoomScale(sizeBox.Height / sizeImage.Height, Point.Empty);
        }

        private void imageBoxSegmentation_MouseMove(object sender, MouseEventArgs e)
        {

            Point mousePostotion =  new Point();
            mousePostotion.X = imageBoxSegmentation.HorizontalScrollBar.Value + (int)(e.X / imageBoxSegmentation.ZoomScale);
            mousePostotion.Y = imageBoxSegmentation.VerticalScrollBar.Value + (int)(e.Y / imageBoxSegmentation.ZoomScale);
        }
    }
}
