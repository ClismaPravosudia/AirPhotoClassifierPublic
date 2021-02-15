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
            if (_image == null)
            {
                return;
            }

            Point mousePosition = new Point();

            mousePosition.X = imageBoxSegmentation.HorizontalScrollBar.Value + (int)(e.X / imageBoxSegmentation.ZoomScale);
            mousePosition.Y = imageBoxSegmentation.VerticalScrollBar.Value + (int)(e.Y / imageBoxSegmentation.ZoomScale);

            if (_image.inBorderImage(mousePosition))
            {
               // imageBoxSegmentation.Image = _image.PickSuperPixel(new Bgr(0, 0, 255), mousePosition);
            }
        }
        private void buttonAddСategory_Click(object sender, EventArgs e)
        {
            FormCreateCategory createCategory = new FormCreateCategory();
            if(createCategory.ShowDialog() == DialogResult.OK)
            {
                Category category = new Category(createCategory.NameCategory, createCategory.ColorCategory);
                listСategory.Items.Add(category);
              
            }
        }

        private void RandomTreeButton_Click(object sender, EventArgs e)
        {
            Classifier classifier =  new Classifier(listСategory);

                //try
               // {
            int[] result = Classifier.GetTrain();
            for(int i = 0; i<result.Length; i++)
            {
                imageBoxSegmentation.Image = _image.FillSuperPixel((Category)listСategory.Items[result[i]], i);
            }
               // MessageBox.Show("SVM is trained.");
               // }
                //catch (Exception ex)
                //{
                 //   MessageBox.Show(ex.Message);
                //}
        }

        private void imageBoxSegmentation_MouseClick(object sender, MouseEventArgs e)
        {
            if (_image == null|| listСategory.SelectedItems.Count<=0)
            {
                return;
            }

            Point mousePosition = new Point();

            mousePosition.X = imageBoxSegmentation.HorizontalScrollBar.Value + (int)(e.X / imageBoxSegmentation.ZoomScale);
            mousePosition.Y = imageBoxSegmentation.VerticalScrollBar.Value + (int)(e.Y / imageBoxSegmentation.ZoomScale);
            if (_image.inBorderImage(mousePosition))
            {
                Category selectItem = (Category)listСategory.SelectedItems[0];
                Color color = selectItem.BackColor;
                imageBoxSegmentation.Image = _image.FillSuperPixel(selectItem, mousePosition);
            }
        }
    }
}

