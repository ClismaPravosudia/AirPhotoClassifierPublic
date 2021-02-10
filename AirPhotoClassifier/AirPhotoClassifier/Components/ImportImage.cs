using Emgu.CV;
using Emgu.CV.Structure;
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
        private Mat _nullMat;
        private Mat _NullMat
        {
            get
            {
                if (_nullMat == null)
                    _nullMat = new Mat();
                return _nullMat;
            }
        }

        private Mat _image;
        public void OpenWindow()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg|*.jpg| png|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _image = CvInvoke.Imread(ofd.FileName, Emgu.CV.CvEnum.ImreadModes.AnyColor);
            }
            else
            {
                _image = _NullMat;
            }
        }
        public Mat GetImage()
        {
            return _image;
        }
    }
}