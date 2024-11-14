using System;
using System.IO;

namespace FormUryupin34.NeuroLink
{
    class InputLayer
    {
        private Random random = new Random();

        private double[,] trainset = new double[100, 16];       //100 изображений 
        private double[,] testset  = new double[10, 16];         //10 изображений
                                                                 
        //Свойства 
        public double[,] Trainset { get => trainset; }
        public double[,] Testset { get => testset; }

        //Конструктор
        public InputLayer(NetworkMode nm)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;    //путь к ехе
            string[] tmpStr;
            string[] tmpArrStr;
            double[] tmpArr;

            switch (nm)
            {
                case NetworkMode.Train:
                    tmpArrStr = File.ReadAllLines(path + "train.txt");
                    for( int i = 0; i < tmpArrStr.Length; i++)
                    {
                        tmpStr = tmpArrStr[i].Split();
                        tmpArr = new double[tmpStr.Length];
                        for(int j = 0; j < tmpArrStr.Length; j++)
                        {
                            tmpArr[j] = double.Parse(tmpStr[j], System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }

                    // метод фишера
                    for( int n=trainset.GetLength(0) - 1;n>=1; n--)
                    {
                        int j = random.Next(n + 1);
                        double[] temp = new double[trainset.GetLength(1)];

                        for(int i = 0; i < trainset.GetLength(1); i++)
                        {
                            temp[i] = trainset[n, i];
                        }

                        for(int i = 0; i < trainset.GetLength(1); i++)
                        {
                            trainset[n, i] = trainset[j, i];
                            trainset[j, i] = temp[i];
                        }
                    }
                    break;
            }
        }
    }
}
