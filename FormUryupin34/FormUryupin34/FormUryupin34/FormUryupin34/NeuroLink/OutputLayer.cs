

namespace FormUryupin34.NeuroLink
{
    class OutputLayer : Layer
    {
        public OutputLayer(int non, int nopn, NeuronType nt, string type) : base(non, nopn, nt, type) { }  //конструктор

        public override void Recognize(NetWork net, Layer nextLayer)
        {
            double e_sum  = 0;

            for (int i = 0; i < Neurons.Length; i++)
               e_sum += Neurons[i].Output;

            for (int i = 0; i < Neurons.Length; i++)
                net.fact[i] = Neurons[i].Output / e_sum;
        }

        public override double[] BackwardPass(double[] errors)
        {

            double[] gr_sum = new double[numofprevneurons + 1]; 
            //здесь будет код обучения нейронной сети

            return gr_sum;
        }
    }
}