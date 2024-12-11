using System;

namespace FormUryupin34.NeuroLink
{
    class Neuron
    {
        private NeuronType type;//type of neuron
        private double[] _weights;
        private double[] _inputs;
        private double _output;
        private double _derivative; //производная функции активации
        private double a = 0.01; //const для функции активации

        public double[] Weights { get => _weights; set => _weights = value; }
        public double[] Inputs { get => _inputs; set => _inputs = value; }
        public double Output { get => _output; }
        public double Derivative { get => _derivative; }

        public Neuron(double[] weigths, NeuronType type)
        {
            this.type = type;
            _weights = weigths;
        }

        public void Activator(double[] inputs, double[] weights)
        {
            this._inputs = inputs;
            this._weights = weights;

            double summ = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                summ += this._inputs[i] * this._weights[i + 1];
            }

            this._output = this.LeakyRELU(summ);
            this._derivative = this.LeakyRELUDerivative(summ);
        }

        public double LeakyRELU(double x, double alpha = 0.01d)
        {
            return (x > 0.0d) ? x : alpha * x;
        }

        public double LeakyRELUDerivative(double x, double alpha = 0.01d)
        {
            return (x > 0.0d) ? 1 : alpha;
        }

    }
}

