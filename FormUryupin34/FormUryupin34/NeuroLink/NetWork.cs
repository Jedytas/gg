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
            net.hidden_layer2.Recognize(null, net.hidden_layer1); //доделать
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
        }
    }
}
