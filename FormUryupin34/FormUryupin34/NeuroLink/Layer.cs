using System;
using System.Windows.Forms;
using System.IO;


namespace FormUryupin34.NeuroLink
{
    abstract class Layer
    {
        protected string name_Layer;
        string pathDirWeights;
        string pathFileWeights;
        protected int numofneurons;
        protected int numofprevneurons;
        protected const double learningrate = 0.005d;
        protected const double momentum = 0.05d;
        protected double[,] lastdeltaweights;
        Neuron[] _neurons;

        public Neuron[] Neurons { get => _neurons; set => _neurons = value; }

        public double[] Data
        {
            set
            {
                for(int i=0;i<Neurons.Length; i++)
                {
                    Neurons[i].Inputs = value;
                    Neurons[i].Activator(Neurons[i].Inputs);
                }
            }
        }

        //конструктор
        protected Layer(int non, int nopn, NeuronType nt, string nm_Layer)
        {
            numofneurons = non;
            numofprevneurons = nopn;
            Neurons = new Neuron[non];
            name_Layer = nm_Layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "memory\\";
            pathFileWeights = pathDirWeights + name_Layer + "memory.csv";

            double[,] Weights;

            if (File.Exists(pathFileWeights))
                Weights = WeightInitialize(MemoryMode.GET, pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitialize(MemoryMode.INIT, pathFileWeights);
            }
        }

        private double[,] WeightInitialize(MemoryMode mm, string path) //метод работы с массивом синаптических весов
        {
            int i, j;
            char[] delim = new char[] { ';', ' ' };
            string tmpStr;
            string[] tmpStrweights;
            double[,] weights = new double[numofneurons, numofprevneurons + 1];

            switch (mm)
            {
                case MemoryMode.GET:
                    tmpStrweights = File.ReadAllLines(path);
                    string[] memory_element;
                    for(i=0;i<numofneurons; i++)
                    {
                        memory_element = tmpStrweights[i].Split(delim);
                        for (j = 0; j < numofprevneurons + 1; j++)
                        {
                            weights[i, j] = double.Parse(memory_element[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;
            }
            return weights;
        }
    }


}
