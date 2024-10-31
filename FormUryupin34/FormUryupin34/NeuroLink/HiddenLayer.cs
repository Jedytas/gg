

namespace FormUryupin34.NeuroLink
{
    class HiddenLayer : Layer
    {
        public HiddenLayer (int non, int nopn, NeuronType nt,string type) : base(non,nopn,nt,type) { }  //конструктор

        public override void Recognize(NetWork net, Layer nextLayer)
        {
            double[] hidden_out = new double[Neurons.Length];

            for (int i = 0; i < Neurons.Length; i++)
                hidden_out[i] = Neurons[i].Output;

            nextLayer.Data = hidden_out;
        }

        public override double[] BackwardPass(double[] gr_sums)
        {

            //здесь будет код обучения нейронной сети

            return gr_sums;
        }
    }
}
