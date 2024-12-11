using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using FormUryupin34.NeuroLink;

namespace FormUryupin34
{

   
    public partial class Form1 : Form
    { 
        private bool[] _bStates;                                        //массив входных данных
        private Network net;                              //обьявление нейросети
        private double[] _inputPixels = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //конструктор
        public Form1()
        {
            InitializeComponent();
            net = new Network();

        }


        private void buttonSaveTrainSample_Click(object sender, EventArgs e)
        {
            SaveTrain(numericUpDownTRUE.Value, _inputPixels);
        }

        private void buttonSaveTestSample_Click(object sender, EventArgs e)
        {
            SaveTest(numericUpDownTRUE.Value, _inputPixels);
        }

        private void SaveTest(decimal vale, double[] input)
        {
            string pathDir;
            string nameFileTrain;
            pathDir = AppDomain.CurrentDomain.BaseDirectory;
            nameFileTrain = pathDir + "test.txt";
            string[] temp = new string[1];
            temp[0] = vale.ToString();

            for (int i = 0; i < 15; i++)
            {
                temp[0] += input[i].ToString();
            }


            File.AppendAllLines(nameFileTrain, temp);


        }

        private void SaveTrain(decimal vale, double[] input)
        {
            string pathDir;
            string nameFileTrain;
            pathDir = AppDomain.CurrentDomain.BaseDirectory;
            nameFileTrain = pathDir + "train.txt";
            string[] temp = new string[1];
            temp[0] = vale.ToString();

            for (int i = 0; i < 15; i++)
            {
                temp[0] += input[i].ToString();
            }


            File.AppendAllLines(nameFileTrain, temp);


        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            net.Train(net);
/*            for (int i = 0; i < net.E_error_avr.Length; i++)
            {
                chart_Eavr.Series[0].Points.AddY(net.E_error_avr[i]);
            }*/
            MessageBox.Show("Обучение успешно завершено.", "Информация");                                                                      //кнопка обучить
        }

        private void recognizebutton_Click(object sender, EventArgs e)
        {
            net.ForwardPass(net, _inputPixels);
            Answer.Text = net.fact.ToList().IndexOf(net.fact.Max()).ToString();
            label_probably.Text = (100 * net.fact.Max()).ToString("0.00") + "%";
        }


        private void Change_State(Button b, int index)
        {
            if (b.BackColor == Color.Black)
            {
                b.BackColor = Color.White;
                _inputPixels[index] = 0;
            }
            else
            if (b.BackColor == Color.White)
            {
                b.BackColor = Color.Black;
                _inputPixels[index] = 1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change_State(button1, 0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Change_State(button2, 1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Change_State(button3, 2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Change_State(button4, 3);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Change_State(button5, 4);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            Change_State(button6, 5);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Change_State(button7, 6);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Change_State(button8, 7);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Change_State(button9, 8);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Change_State(button10, 9);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Change_State(button11, 10);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Change_State(button12, 11);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Change_State(button13, 12);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Change_State(button14, 13);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Change_State(button15, 14);
        }

        //тестировать
        private void button16_Click(object sender, EventArgs e)
        {

        }
    }
}
