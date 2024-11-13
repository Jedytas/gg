using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace FormUryupin34.NeuroLink
{
    abstract class Layer
    {
        protected string name_Layer;
        string pathDirWeights;
        string pathFileWeights;
        protected int numofneurons;
        protected int numofprevneurons;
        protected const double learningrate = 0.005d;       // скорость обучения
        protected const double momentum = 0.05d;            //param optimizartion
        protected double[,] lastdeltaweights;
        Neuron[] _neurons;
        private static readonly Random rand = new Random(); // Один генератор случайных чисел

        public Neuron[] Neurons { get => _neurons; set => _neurons = value; }

        public double[] Data
        {
            set
            {
                for (int i = 0; i < Neurons.Length; i++)
                {
                    Neurons[i].Inputs = value;
                    Neurons[i].Activator(Neurons[i].Inputs, Neurons[i].Weights);
                }
            }
        }

        // Конструктор
        protected Layer(int non, int nopn, NeuronType nt, string nm_Layer)
        {
            numofneurons = non;
            numofprevneurons = nopn;
            Neurons = new Neuron[non];
            name_Layer = nm_Layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";    // path to catalog
            pathFileWeights = pathDirWeights + name_Layer + "memory.csv";            //path to file with synaptics weights

            double[,] Weights;

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            }

            lastdeltaweights = new double[non, nopn + 1];

            for(int i = 0; i < non; i++)
            {
                double[] tmp_weights = new double[nopn + 1];
                for(int j = 0; j < nopn + 1; j++)
                {
                    tmp_weights[j] = Weights[i, j];
                }
                Neurons[i] = new Neuron(tmp_weights, nt);
            }
        }

        private double[,] WeightInitialize(MemoryMode mm, string path)
        {
            int i, j;
            char[] delim = new char[] { ';', ' ' };
            string[] tmpStrweights;
            double[,] weights = new double[numofneurons, numofprevneurons + 1];

            switch (mm)
            {
                case MemoryMode.GET:
                    tmpStrweights = File.ReadAllLines(path);
                    for (i = 0; i < numofneurons; i++)
                    {
                        string[] memory_element = tmpStrweights[i].Split(delim);
                        for (j = 0; j < numofprevneurons + 1; j++)
                        {
                            weights[i, j] = double.Parse(memory_element[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;

                case MemoryMode.SET:
                    List<string> lines = new List<string>();
                    for (i = 0; i < numofneurons; i++)
                    {
                        string line = "";
                        for (j = 0; j < numofprevneurons + 1; j++)
                        {
                            line += weights[i, j].ToString(System.Globalization.CultureInfo.InvariantCulture) + ";";
                        }
                        lines.Add(line.TrimEnd(';'));
                    }
                    File.WriteAllLines(path, lines);
                    break;

                case MemoryMode.INIT:
                    for (i = 0; i < numofneurons; i++)
                    {
                        double sum = 0;
                        double sumSquares = 0;

                        for (j = 0; j < numofprevneurons + 1; j++)
                        {
                            double randomWeight = rand.NextDouble() * 2 - 1; // значение в диапазоне (-1; 1)
                            weights[i, j] = randomWeight;
                            sum += randomWeight;
                            sumSquares += randomWeight * randomWeight;
                        }

                        double mean = sum / (numofprevneurons + 1);
                        double stdDev = Math.Sqrt(sumSquares / (numofprevneurons + 1) - mean * mean);

                        for (j = 0; j < numofprevneurons + 1; j++)
                        {
                            weights[i, j] = (weights[i, j] - mean) / stdDev; // нормализация весов
                        }
                    }

                    WeightInitialize(MemoryMode.SET, path); // сохранение нормализованных весов в файл
                    break;
            }
            return weights;
        }

        abstract public void Recognize(NetWork net, Layer nextLayer);   //для прямых проходов

        abstract public double[] BackwardPass(double[] stuff);          //и для обратных
        //архитектура 15-72-30-10
    }
}
