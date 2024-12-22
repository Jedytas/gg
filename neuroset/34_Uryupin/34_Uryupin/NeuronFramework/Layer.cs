﻿using System;
using System.IO;

namespace _34_Uryupin.src
{
    abstract class Layer
    {
        // поля
        protected string name_Layer; // наименование слоя
        string pathDirWeights; // путь к директории файла весов
        string pathFileWeights; // путь к файлу весов
        protected int numOfNeurons; // число нейронов
        protected int numOfPrevNeurons; // число нейронов на пред слое
        protected const double learningRate = 0.006; // скорость обучения
        protected const double momentum = 0.1; // настройка метода оптимизации
        protected double[,] lastDeltaWeights; // последнее изменение весов
        private Neuron[] neurons;

        // свойства
        public Neuron[] Neurons
        {
            get { return neurons; }
            set { neurons = value; }
        }

        public double[] Data
        {
            set
            {
                foreach (var neuron in Neurons)
                {
                    neuron.Inputs = value;
                    neuron.Activator();
                }
            }
        }
        protected Layer(int non, int nopn, TypeNeuron nt, string nm_Layer)
        {
            numOfNeurons = non;
            numOfPrevNeurons = nopn;
            Neurons = new Neuron[non];
            name_Layer = nm_Layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            pathFileWeights = pathDirWeights + name_Layer + "_memory.csv";

            double[,] Weights; // временный массив синаптических весов текущего слоя

            if (File.Exists(pathFileWeights))
            {
                Weights = WeightsInitialize(MemoryMode.GET);
            }
            else
            {

                Directory.CreateDirectory(pathDirWeights);
                File.Create(pathFileWeights).Close();
                Weights = WeightsInitialize(MemoryMode.INIT);

            }

            lastDeltaWeights = new double[non, nopn + 1];
            for (int i = 0; i < non; i++)
            {
                double[] tmp_weights = new double[nopn + 1];
                for (int j = 0; j < nopn + 1; j++)
                {
                    tmp_weights[j] = Weights[i, j];
                }
                Neurons[i] = new Neuron(tmp_weights, nt);
            }
        }

        abstract public void Recognize(NeuralNetwork net, Layer nextLayer);
        abstract public double[] BackwardPass(double[] stuff);

        public double[,] WeightsInitialize(MemoryMode mm)
        {
            char[] delim = new char[] { ';', ' ' }; // разделители слов
            string tmpStr; // временная строка для чтения
            string[] tmpStrWeights; // временный массив строк
            double[,] weigths = new double[numOfNeurons, numOfPrevNeurons + 1];

            switch (mm)
            {
                case MemoryMode.GET:
                    tmpStrWeights = File.ReadAllLines(pathFileWeights);
                    string[] memory_element;
                    for (int i = 0; i < numOfNeurons; i++)
                    {

                        memory_element = tmpStrWeights[i].Split(delim[0]);
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            weigths[i, j] = double.Parse(memory_element[j].Replace(',', '.'),
                                System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;
                case MemoryMode.SET:
                    tmpStrWeights = new string[numOfNeurons];

                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        tmpStr = Neurons[i].Weights[0].ToString();
                        for (int j = 1; j < numOfPrevNeurons + 1; j++)
                        {
                            tmpStr += delim[0] + Neurons[i].Weights[j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
                    File.WriteAllLines(pathFileWeights, tmpStrWeights);
                    break;
                case MemoryMode.INIT:
                    Random rand = new Random();
                    tmpStrWeights = new string[numOfNeurons];

                    // инициализация весов:
                    // 1. веса инициализируются случайными величинами
                    // 2. мат ожидание всех весов нейрона должно равняться 0
                    // 3. среднее квадратическое значение должно равняться 1

                    for (int i = 0; i < numOfNeurons; i++)
                    {
                        // вычисляем мат. ожидание
                        double sum = 0;
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                        {
                            weigths[i, j] = rand.NextDouble();
                            sum += weigths[i, j];
                        }
                        double mean = sum / (numOfPrevNeurons + 1);
                        sum = 0;
                        // вычисляем сркв отклонение
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                            sum += Math.Pow(weigths[i, j] - mean, 2);
                        double std = Math.Sqrt(sum / (numOfPrevNeurons + 1));
                        // нормализуем веса
                        for (int j = 0; j < numOfPrevNeurons + 1; j++)
                            weigths[i, j] = (weigths[i, j] - mean) / std;

                        tmpStr = weigths[i, 0].ToString();
                        for (int j = 1; j < numOfPrevNeurons + 1; j++)
                        {
                            tmpStr += delim[0] + weigths[i, j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;

                    }
                    File.WriteAllLines(pathFileWeights, tmpStrWeights);

                    break;
                default:
                    break;
            }
            return weigths;
        }
    }
}

