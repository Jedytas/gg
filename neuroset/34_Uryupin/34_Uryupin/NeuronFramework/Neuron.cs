using static System.Math;

namespace _34_Uryupin.src
{
    class Neuron
    {
        // поля
        private TypeNeuron type;
        private double[] inputs;
        private double[] weights;
        private double derivative;

        private double output;

        // свойства 
        public double[] Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }

        public double[] Weights
        {
            get { return weights; }
            set { weights = value; }
        }

        public double Derivative
        {
            get { return derivative; }
        }

        public double Output
        {
            get { return output; }
        }

        // конструктор
        public Neuron(double[] ws, TypeNeuron t)
        {
            type = t;
            weights = ws;
        }

        public void Activator()
        {
            // первый элемент weights - b (порог)
            double sum = weights[0];
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i] * weights[i + 1];
            }

            switch (type)
            {
                case TypeNeuron.Output:
                    output = Exp(sum);
                    break;
                case TypeNeuron.Hidden:
                    output = LeakyRELU(sum);
                    derivative = Derivator(sum);
                    break;
                default:
                    break;
            }
        }

        // функция активации (Leaky RELU)
        private double LeakyRELU(double x)
        {
            const double alpha = 0.01; // константа alpha
            return x > 0 ? x : alpha * x;
        }

        // вычисление производной
        private double Derivator(double x)
        {
            const double alpha = 0.01; // константа alpha
            return x > 0 ? 1 : alpha;
        }
    }
}
