using System;

namespace FormUryupin34.NeuroLink
{
    class NetWork
    {

        //все слои сети
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(70, 15, NeuronType.Hidden, nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(30, 70, NeuronType.Hidden, nameof(hidden_layer2));
        private OutputLayer output_layer  = new OutputLayer(10, 30, NeuronType.Hidden, nameof(output_layer));


        //массив для хранения выхода сети
        public double[] fact = new double[10];

        //среднее значение энергии ошибки эпохи обучения
        public double e_error_avr;
        public double E_error_avr { get => e_error_avr; set => e_error_avr = value; } //среднее значение энергии ошибки

        //конструктор
        public NetWork() { }

        //прямой проход нейросети

        public void ForwardPass(NetWork net, double[] netInput)
        {
            net.hidden_layer1.Data = netInput;
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
            net.hidden_layer2.Recognize(null, net.output_layer);
            net.output_layer.Recognize(net, null);
        }

        //обучение
        public void Train (NetWork net) //backpropagation method
        {
            int epoches = 70;   //количество эрох обучения
            net.input_layer = new InputLayer(NetworkMode.Train);    //инициализация входного слоя
            double tmpSumError;     //временная переменная суммы ошибок
            double[] errors;        //вектор(массив) сигнала ошибки выхожного слоя
            double[] temp_gsums1;   //вектор градиента 1го скрытого слоя
            double[] temp_gsums2;   //вектор градиента 2го скрытого слоя
        }
    }
}
