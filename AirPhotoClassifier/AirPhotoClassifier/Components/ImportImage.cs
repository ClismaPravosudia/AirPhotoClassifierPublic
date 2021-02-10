using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirPhotoClassifier.Components
{
    class ImportImage
    {
        private Mat image;
        private string filename;
        public void OpenWindow()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg|*.jpg| png|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
        }
        public Mat GetImage()
        {
            return CvInvoke.Imread(filename, Emgu.CV.CvEnum.ImreadModes.AnyColor);
        }
    }
}