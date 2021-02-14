using Emgu.CV;
using Emgu.CV.Structure.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Components
{
    class Classifier
    {
        public static void ToMatrix(SegmenеtedImage image)
        {
            SuperPixel [] superPixels = image.SuperPixels;

            Matrix<double> matrix =  new Matrix<double>(3*superPixels[0].Parameteres.Count,
                                                          superPixels.Length);


            for (int height = 0; height < matrix.Cols; height++)
            {
                matrix.Data[0, height] = superPixels[height].Parameteres.Minimum.Blue;
                matrix.Data[1, height] = superPixels[height].Parameteres.Minimum.Green;
                matrix.Data[2, height] = superPixels[height].Parameteres.Minimum.Red;

                matrix.Data[3, height] = superPixels[height].Parameteres.Maximum.Blue;
                matrix.Data[4, height] = superPixels[height].Parameteres.Maximum.Green;
                matrix.Data[5, height] = superPixels[height].Parameteres.Maximum.Red;

                matrix.Data[6, height] = superPixels[height].Parameteres.Middle.Blue;
                matrix.Data[7, height] = superPixels[height].Parameteres.Middle.Green;
                matrix.Data[8, height] = superPixels[height].Parameteres.Middle.Red;

                matrix.Data[9, height] = superPixels[height].Parameteres.Dispersion.Blue;
                matrix.Data[10, height] = superPixels[height].Parameteres.Dispersion.Green;
                matrix.Data[11, height] = superPixels[height].Parameteres.Dispersion.Red;
            }
        }
    }
}
