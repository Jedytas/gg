using System.Linq;
using System;


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

        // активация ReLU
        public void Activator(double[] inputs)
        {
            _inputs = inputs;
            double sum = _weights[0]; // начальное значение с первым весом (смещение)
            for (int m = 0; m < _inputs.Length; m++)
            {
                sum += _inputs[m] * _weights[m + 1]; // взвешенная сумма
            }

            // Применяем функцию активации ReLU
            _outputs = ReLU(sum);

            // Производная функции активации ReLU
            _derivative = ReLUDerivative(sum);
        }

        // функция активации ReLU
        private double ReLU(double x)
        {
            return Math.Max(0, x); // возвращает x, если x > 0, иначе 0
        }


        // производная функции активации ReLU
        private double ReLUDerivative(double x)
        {
            return x > 0 ? 1 : 0; // производная: 1 для положительных значений, 0 для отрицательных
        }
    }
}

