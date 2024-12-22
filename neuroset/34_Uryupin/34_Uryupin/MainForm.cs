using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using _34_Uryupin.src;

namespace _34_Uryupin
{
    public partial class MainForm : Form {

        double[] inputData;
        int numericValue = 0;
        NeuralNetwork net = new NeuralNetwork(NetworkMode.Recognize);

        public double[] InputData
        {
            get { return inputData; }
            set { inputData = value; }
        }

        public MainForm()
        {
            InputData = new double[15];
            InitializeComponent();
        }

        void ChangeStatusData(Button b, int index)
        {
            if(b.BackColor == Color.Black)
            {
                b.BackColor = Color.White;
                InputData[index] = 0;
            }
            else 
            {
                b.BackColor = Color.Black;
                InputData[index] = 1;
            }

        }    
         
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button1, 0);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button3, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button4, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button5, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button6, 5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button7, 6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button8, 7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button9, 8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button10, 9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button11, 10);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button12, 11);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button13, 12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ChangeStatusData(button14, 13);
        }

        private void button15_Click(object sender, EventArgs e)
        {

            ChangeStatusData(button15, 14);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericValue = Decimal.ToInt32(numericUpDown1.Value);
        }

        private void saveTrainDataBtn_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "trainData.txt";
            string data = numericValue.ToString();
            foreach (int i in InputData)
            {
                data += " " + i.ToString();
            }
            data += "\n";
            File.AppendAllText(path, data);
        }

        private void saveTestDataBtn_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "testData.txt";
            string data = numericValue.ToString();
            foreach (int i in InputData)
            {
                data += " " + i.ToString();
            }
            data += "\n";
            File.AppendAllText(path, data);
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            net.ForwardPass(net, InputData);
            labelOutput.Text = net.Fact.ToList().IndexOf(net.Fact.Max()).ToString();
            label_probability.Text = (100 * net.Fact.Max()).ToString("0.00") + "%";
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            net.Train(net);
            for (int i = 0; i < net.E_error_avr.Length; i++)
            {
                chart_Eavr.Series[0].Points.AddY(net.E_error_avr[i]);
            }
            MessageBox.Show("Обучение успешно завершено.", "Информация");
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            net.Test(net);
            for (int i = 0; i < net.E_error_avr.Length; i++)
            {
                chart_Eavr.Series[0].Points.AddY(net.E_error_avr[i]);
            }
            MessageBox.Show("Тестирование успешно завершено.", "Информация");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
