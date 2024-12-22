using System.Threading.Tasks;
using System.Windows.Forms;

namespace _34_Uryupin.src
{
    class NeuralNetwork
    {
        Form form;
        //Массив для хранения вектора выходного сигнала нейросети
        public double[] Fact = new double[10];
        //Все слои нейросети
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(72, 15, TypeNeuron.Hidden, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(30, 72, TypeNeuron.Hidden, nameof(hidden_layer2));
        private OutputLayer output_layer = new OutputLayer(10, 30, TypeNeuron.Output, nameof(output_layer));

        // Среднее значение энергии ошибки эпохи обучения
        private double[] e_error_avr;

        //Свойства
        public double[] E_error_avr { get => e_error_avr; set => e_error_avr = value; } //срденне значение энергии эпохи обучения


        //Конструктор
        public NeuralNetwork(NetworkMode nm)
        {
            input_layer = new InputLayer(nm);
        }


        // Обучение
        public void Train(NeuralNetwork net)
        {

            int epochs = 20 ;
            net.input_layer = new InputLayer(NetworkMode.Train);

            double tmpSumError; // Временная переменная суммы ошибок
            double[] errors; //Вектор сигнала ошибки выходного слоя
            double[] tmpGradSums1; //Вектор градиента первого скрытого слоя
            double[] tmpGradSums2; //Вектор градиента второго скрытого слоя
            e_error_avr = new double[epochs];

            for (int k = 0; k < epochs; k++)
            {
                e_error_avr[k] = 0;// Обнуляем значение в начале эпохи
                for (int i = 0; i < net.input_layer.TrainSet.Length; i++)
                {
                    //Прямой проход
                    ForwardPass(net, net.input_layer.TrainSet[i].Item1);

                    //Вычисление ошибки по итерации
                    tmpSumError = 0;

                    errors = new double[net.Fact.Length];
                    for (int x = 0; x < errors.Length; x++)
                    {
                        if (x == net.input_layer.TrainSet[i].Item2)
                        {
                            errors[x] = 1.0 - net.Fact[x];
                        }
                        else
                        {
                            errors[x] = -net.Fact[x];
                        }

                        //Собираем энергию ошибки
                        tmpSumError += errors[x] * errors[x] / 2.0;
                    }

                    e_error_avr[k] += tmpSumError / errors.Length;//Суммарное значение энергии оишбки эпох
                    //Обратный проход и коррекция весов
                    tmpGradSums2 = net.output_layer.BackwardPass(errors);
                    tmpGradSums1 = net.hidden_layer2.BackwardPass(tmpGradSums2);
                    net.hidden_layer1.BackwardPass(tmpGradSums1);
                }


                e_error_avr[k] /= net.input_layer.TrainSet.GetLength(0);//Среднее значение энергии ошибки одной эпохи

            }

            net.input_layer = null; //Обнуление входного слоя

            //Сохранение скорректированных весов
            net.hidden_layer1.WeightsInitialize(MemoryMode.SET);
            net.hidden_layer2.WeightsInitialize(MemoryMode.SET);
            net.output_layer.WeightsInitialize(MemoryMode.SET);

        }


        // Тестирование
        public void Test(NeuralNetwork net)
        {

            int epochs = 2;
            net.input_layer = new InputLayer(NetworkMode.Test);

            double tmpSumError; // Временная переменная суммы ошибок
            double[] errors; //Вектор сигнала ошибки выходного слоя
            double[] tmpGradSums1; //Вектор градиента первого скрытого слоя
            double[] tmpGradSums2; //Вектор градиента второго скрытого слоя
            e_error_avr = new double[epochs];

            for (int k = 0; k < epochs; k++)
            {
                e_error_avr[k] = 0; // Обнуляем значение в начале эпохи
                for (int i = 0; i < net.input_layer.TestSet.Length; i++)
                {
                    //Прямой проход
                    ForwardPass(net, net.input_layer.TestSet[i].Item1);

                    //Вычисление ошибки по итерации
                    tmpSumError = 0;

                    errors = new double[net.Fact.Length];
                    for (int x = 0; x < errors.Length; x++)
                    {
                        if (x == net.input_layer.TestSet[i].Item2)
                        {
                            errors[x] = 1.0 - net.Fact[x];
                        }
                        else
                        {
                            errors[x] = -net.Fact[x];
                        }

                        //Собираем энергию ошибки
                        tmpSumError += errors[x] * errors[x] / 2.0;
                    }

                    e_error_avr[k] += tmpSumError / errors.Length; //Суммарное значение энергии оишбки эпох
                }

                e_error_avr[k] /= net.input_layer.TestSet.GetLength(0); //Среднее значение энергии ошибки одной эпохи

            }

            net.input_layer = null; //Обнуление входного слоя
        }
        //Прямой проход сигнала по нейросети
        public void ForwardPass(NeuralNetwork net, double[] net_input)
        {
            net.hidden_layer1.Data = net_input;
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
            net.hidden_layer2.Recognize(null, net.output_layer);
            net.output_layer.Recognize(net, null);
        }
    }
}
