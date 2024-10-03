using System.Math;

namespace FormUryupin34.NeuroLink
{
    class Neuron
    {

        private NeuronType _type;       //тип нейрона
        private double[] _weights;      //вес
        private double[] _inputs;       //вход
        private double   _outputs;      //выход
        private double   _derivative;   //производная функции активации
        //константы для функции активации
        private double a = 0.01;


        //свойства
        public double[] Weights { get => _weights; set => _weights = value; }

        public double[] Inputs
        {
            get { return _inputs; }
            set { _inputs = value; }
        }

        public double Output { get => _outputs; }
        public double Derivative { get => _derivative; }

        //конструктор

        public Neuron(double[] inputs, double[] weights,NeuronType type)
        {
            _type = type;
            _weights = weights;
        }
    }
}
