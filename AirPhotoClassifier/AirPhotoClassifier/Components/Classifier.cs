using Emgu.CV;
using Emgu.CV.Structure.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.ML;
using Emgu.CV.Structure;

namespace AirPhotoClassifier.Components
{
    class Classifier
    {
        static Matrix<float> matrix;
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
        public static void GetTrain()
        {
            RTrees rTrees;
            Matrix<float> TestTrain= new Matrix<float>(12,10);
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                TestTrain.Data[i, j] = matrix.Data[i, j];
                    
                }
            }
            Matrix<float> TrainLabel= new Matrix<float>(1, 10);
            TrainLabel.Data[0, 0] = 1;
            TrainLabel.Data[0, 1] = 1;
            TrainLabel.Data[0, 2] = 1;
            TrainLabel.Data[0, 3] = 1;
            TrainLabel.Data[0, 4] = 1;
            TrainLabel.Data[0, 5] = 2;
            TrainLabel.Data[0, 6] = 2;
            TrainLabel.Data[0, 7] = 2;
            TrainLabel.Data[0, 8] = 2;
            TrainLabel.Data[0, 9] = 2;


            rTrees = new RTrees();
            rTrees.ActiveVarCount = 500;//Размер случайно выбранного подмножества функций в каждом узле дерева, которые используются для поиска наилучшего разделения (я)(предположу что это колличество деревьев)
            rTrees.CalculateVarImportance = true;//Если true, то будет рассчитана важность переменной.(хз на что влияет)
            rTrees.MaxDepth = 25;//Максимально возможная глубина дерева
            rTrees.MinSampleCount = 2;//Если количество выборок в узле меньше этого параметра, узел не будет разделен.
            rTrees.TermCriteria = new MCvTermCriteria(1000, 1e-6);//Критерии завершения, указывающие, когда алгоритм обучения останавливается
            rTrees.Train(matrix, Emgu.CV.ML.MlEnum.DataLayoutType.ColSample, TrainLabel); //Тренировка RandomFree
            int p =0;
            float a = rTrees.Predict(matrix.GetCol(p));
            int x = 0;                                                                                                   // svm = new SVM();
                                                                                                                    //svm.C = 100;//Параметр C задачи оптимизации SVM
                                                                                                                    //svm.Type = SVM.SvmType.CSvc;//Тип формулировки SVM
                                                                                                                    //svm.Gamma = 0.005;//Параметр гамма функции ядра (Скорость обучения?)
                                                                                                                    //svm.SetKernel(SVM.SvmKernelType.Linear);//Тип ядра SVM
                                                                                                                    //svm.TermCriteria = new MCvTermCriteria(1000, 1e-6);//Критерии завершения итеративной процедуры обучения SVM, которая решает частный случай задачи квадратичной оптимизации с ограничениями
                                                                                                                    //svm.Train(TrainData, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, TrainLabel); Тренировка SVM

            //svm.Save("svm.txt");//Сохранение CVM в файл



        }

    }
}
