using Emgu.CV;
using Emgu.CV.Structure.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using System.Windows.Forms;

namespace AirPhotoClassifier.Components
{
    class Classifier
    {
        private Category[] categorys;
        private static RTrees rTrees2;

        public Classifier(ListView listCategorys)
        {
            int countSuperPixel = 0;
            int countCategorys = listCategorys.Items.Count;
            categorys = new Category[countCategorys];
            for (int i = 0; i < countCategorys;i++)
            {
                categorys[i] = (Category)listCategorys.Items[i];
                countSuperPixel += categorys[i].SuperPixels.Count;
            }

            TestTrain = new Matrix<float>(12, countSuperPixel);
            TrainLabel = new Matrix<int>(1, countSuperPixel);

            int indexMatrix = 0;

            for (int indexCategory = 0; indexCategory < categorys.Length; indexCategory++)
            {
                for (int indexSuperPixel = 0; indexSuperPixel < categorys[indexCategory].SuperPixels.Count; indexSuperPixel++)
                {
                    TrainLabel[0, indexMatrix] = indexCategory;

                    SuperPixel superPixel = categorys[indexCategory].SuperPixels[indexSuperPixel];

                    TestTrain.Data[0, indexMatrix] = (float)superPixel.Parameteres.Minimum.Blue;
                    TestTrain.Data[1, indexMatrix] = (float)superPixel.Parameteres.Minimum.Green;
                    TestTrain.Data[2, indexMatrix] = (float)superPixel.Parameteres.Minimum.Red;

                    TestTrain.Data[3, indexMatrix] = (float)superPixel.Parameteres.Maximum.Blue;
                    TestTrain.Data[4, indexMatrix] = (float)superPixel.Parameteres.Maximum.Green;
                    TestTrain.Data[5, indexMatrix] = (float)superPixel.Parameteres.Maximum.Red;

                    TestTrain.Data[6, indexMatrix] = (float)superPixel.Parameteres.Middle.Blue;
                    TestTrain.Data[7, indexMatrix] = (float)superPixel.Parameteres.Middle.Green;
                    TestTrain.Data[8, indexMatrix] = (float)superPixel.Parameteres.Middle.Red;

                    TestTrain.Data[9, indexMatrix] = (float)superPixel.Parameteres.Dispersion.Blue;
                    TestTrain.Data[10, indexMatrix] = (float)superPixel.Parameteres.Dispersion.Green;
                    TestTrain.Data[11, indexMatrix] = (float)superPixel.Parameteres.Dispersion.Red;
                    indexMatrix++;
                }

            }
            int x = 0;
        }

        static Matrix<float> matrix;
        static Matrix<float> TestTrain;
        static Matrix<int> TrainLabel;
        public static void ToMatrix(SegmenеtedImage image)
        {
            SuperPixel [] superPixels = image.SuperPixels;

             matrix =  new Matrix<float>(3*superPixels[0].Parameteres.Count,
                                                          superPixels.Length);

            for (int height = 0; height < matrix.Cols; height++)
            {
                matrix.Data[0, height] = (float)superPixels[height].Parameteres.Minimum.Blue;
                matrix.Data[1, height] = (float)superPixels[height].Parameteres.Minimum.Green;
                matrix.Data[2, height] = (float)superPixels[height].Parameteres.Minimum.Red;

                matrix.Data[3, height] = (float)superPixels[height].Parameteres.Maximum.Blue;
                matrix.Data[4, height] = (float)superPixels[height].Parameteres.Maximum.Green;
                matrix.Data[5, height] = (float)superPixels[height].Parameteres.Maximum.Red;

                matrix.Data[6, height] = (float)superPixels[height].Parameteres.Middle.Blue;
                matrix.Data[7, height] = (float)superPixels[height].Parameteres.Middle.Green;
                matrix.Data[8, height] = (float)superPixels[height].Parameteres.Middle.Red;

                matrix.Data[9, height] = (float)superPixels[height].Parameteres.Dispersion.Blue;
                matrix.Data[10, height] = (float)superPixels[height].Parameteres.Dispersion.Green;
                matrix.Data[11, height] = (float)superPixels[height].Parameteres.Dispersion.Red;
                
            }

        }
        public static int[] GetTrain()
        {
            RTrees rTrees1;


            rTrees2 = new RTrees();
            rTrees2.ActiveVarCount = 5; //(int)Math.Sqrt((double)TestTrain.Cols); //Размер случайно выбранного подмножества функций в каждом узле дерева, которые используются для поиска наилучшего разделения (я)
            rTrees2.MaxDepth = 25;
            rTrees2.MinSampleCount = 2;
            //rTrees.TermCriteria = new MCvTermCriteria(10000, 1e-6);//Критерии завершения, указывающие, когда алгоритм обучения останавливается
            for (int j = 0; j < 100; j++)
            {
                rTrees1 = new RTrees();
                rTrees1.ActiveVarCount = 5; //(int)Math.Sqrt((double)TestTrain.Cols);
                rTrees1.MaxDepth = 25;//Максимально возможная глубина дерева

                //rTrees.MaxCategories = 100;
                rTrees1.MinSampleCount = 2;//Если количество выборок в узле меньше этого параметра, узел не будет разделен.
               
                if (j==0)
                {
                    rTrees1.Train(TestTrain, Emgu.CV.ML.MlEnum.DataLayoutType.ColSample, TrainLabel); //Тренировка RandomFree
                    rTrees2 = rTrees1;
                    continue;
                }
                rTrees1.Train(TestTrain, Emgu.CV.ML.MlEnum.DataLayoutType.ColSample, TrainLabel); //Тренировка RandomFree
                if (Classifier.GetAccuracy(rTrees1)>Classifier.GetAccuracy(rTrees2))
                {
                    rTrees2 = rTrees1;
                }
                
            }
                int[] categories = new int[matrix.Cols];
                for (int i = 0; i < matrix.Cols; i++)
                {
                    categories[i] = (int)rTrees2.Predict(matrix.GetCol(i));
                }
            int x = 0;
                return categories;
            

        }
        private static double GetAccuracy(RTrees rTrees)
        {
            double accuracy=0;
            double tru = 0;
           
            for (int i = 0; i < TestTrain.Cols; i++)
            {
                float a =rTrees.Predict(TestTrain.GetCol(i));
                if ((int)a== TrainLabel[0,i])
                {
                    tru++;
                }
            }
            accuracy = tru / TestTrain.Cols;
            return accuracy;
        }
        public static double GetAccuracy()
        {
          
            return Classifier.GetAccuracy(rTrees2);
        }
    }

}
