﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace FormUryupin34
{

   
    public partial class Form1 : Form
    { 
        private bool[] _bStates;                                        //массив входных данных
        private NeuroLink.NetWork network;                              //обьявление нейросети

        //конструктор
        public Form1()
        {
            InitializeComponent();
            this._bStates = new bool[15];
            network = new NeuroLink.NetWork();

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

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            this.network.Train(this.network);                                                                      //кнопка обучить
        }

        private void recognizebutton_Click(object sender, EventArgs e)
        {
            double[]d = new double[15];
            for(int i = 0; i < 15; i++)
            {
                d[i] = this._bStates[i] ? 1.0d : 0.0d;
            }
            network.ForwardPass(network,d);

            Answer.Text = network.fact.ToList().IndexOf(network.fact.Max()).ToString();
        }
    }
}
