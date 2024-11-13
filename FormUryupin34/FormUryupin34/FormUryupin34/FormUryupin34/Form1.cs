using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormUryupin34
{

   
    public partial class Form1 : Form
    { private bool[] _bStates;
        private NeuroLink.Network net = new NeuroLink.Network();
        public Form1()
        {
            InitializeComponent();
            this._bStates = new bool[15];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._bStates[0] = !this._bStates[0];
            ((Button)sender).BackColor = this._bStates[0] ? Color.Black:Color.White;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this._bStates[1] = !this._bStates[1];
            ((Button)sender).BackColor = this._bStates[1] ? Color.Black : Color.White;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this._bStates[2] = !this._bStates[2];
            ((Button)sender).BackColor = this._bStates[2] ? Color.Black : Color.White;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this._bStates[3] = !this._bStates[3];
            ((Button)sender).BackColor = this._bStates[3] ? Color.Black : Color.White;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this._bStates[4] = !this._bStates[4];
            ((Button)sender).BackColor = this._bStates[4] ? Color.Black : Color.White;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            this._bStates[5] = !this._bStates[5];
            ((Button)sender).BackColor = this._bStates[5] ? Color.Black : Color.White;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this._bStates[6] = !this._bStates[6];
            ((Button)sender).BackColor = this._bStates[6] ? Color.Black : Color.White;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this._bStates[7] = !this._bStates[7];
            ((Button)sender).BackColor = this._bStates[7] ? Color.Black : Color.White;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            this._bStates[8] = !this._bStates[8];
            ((Button)sender).BackColor = this._bStates[8] ? Color.Black : Color.White;

        }
        private void button10_Click(object sender, EventArgs e)
        {
            this._bStates[9] = !this._bStates[9];
            ((Button)sender).BackColor = this._bStates[9] ? Color.Black : Color.White;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            this._bStates[10] = !this._bStates[10];
            ((Button)sender).BackColor = this._bStates[10] ? Color.Black : Color.White;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            this._bStates[11] = !this._bStates[11];
            ((Button)sender).BackColor = this._bStates[11] ? Color.Black : Color.White;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            this._bStates[12] = !this._bStates[12];
            ((Button)sender).BackColor = this._bStates[12] ? Color.Black : Color.White;

        }
        private void button14_Click(object sender, EventArgs e)
        {
            this._bStates[13] = !this._bStates[13];
            ((Button)sender).BackColor = this._bStates[13] ? Color.Black : Color.White;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            this._bStates[14] = !this._bStates[14];
            ((Button)sender).BackColor = this._bStates[14] ? Color.Black : Color.White;
        }

        private void buttonSaveTestSample_Click(object sender, EventArgs e)
        {
            this.SaveTrain(this.numericUpDownTRUE.Value,this._bStates);
        }

        private void buttonSaveTrainSample_Click(object sender, EventArgs e)
        {

        }

        private void SaveTrain(decimal vale, bool[] input)
        {
            string pathDir;             //каталог с файлом обучающей выборки
            string nameFileTrain;       //имя файла обучающей выборки
            pathDir = AppDomain.CurrentDomain.BaseDirectory;
            nameFileTrain = pathDir + "testInfo.txt";
            string[] tmpStr = new string[1];                     //временная строка
            tmpStr[0] = vale.ToString();
            for (int i = 0; i < 15; i++)
            {
                tmpStr[0] += input[i] ? "1" : "0" ;
            }

                File.AppendAllLines(nameFileTrain, tmpStr);

        }

        private void SaveTest(decimal vale, double[] input)
        {
            string pathDir;
            string nameFileTrain;
            pathDir = AppDomain.CurrentDomain.BaseDirectory;
            nameFileTrain = pathDir + "test.txt";
            string[] temp = new string[1];
            temp[0] = vale.ToString();
            temp[0] += " ";

            for (int i = 0; i < 15; i++)
            {
                temp[0] += input[i].ToString();
            }


            File.AppendAllLines(nameFileTrain, temp);


        }

       /* private void buttonSaveTrainSample_Click(object sender, EventArgs e)
        {
            SaveTrain(numericUpDownAnswer.Value, _inputPixels);
        }

        private void buttonSaveTestSample_Click(object sender, EventArgs e)
        {
            SaveTest(numericUpDownAnswer.Value, _inputPixels);
        }

        //вроде сюда эту функцию нужно было дописать, но не уверен тк на паре не успели

        private void OnGotResult(object sender, EventArgs e)
        {
            net.ForwardPass(net, _inputPixels);
            label_answer.Text = net.fact.ToList().IndexOf(net.fact.Max()).ToString();
        }*/
    }
}
