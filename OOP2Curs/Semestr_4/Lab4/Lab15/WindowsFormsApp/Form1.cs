using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using One_armedBandit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormsApp
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboBoxThreadPriority1.SelectedIndex = 2;
            ComboBoxThreadPriority2.SelectedIndex = 2;
            ComboBoxThreadPriority3.SelectedIndex = 2;

            Bandit.OnUpdateUI += UpdateResults; //Подписка на обновление интерфейса
        }

        private void UpdateResults(int index, int value) 
        {
            //
            if (InvokeRequired) //InvokeRequired - не в основном потоке вызвали Ivoke
            {
                Invoke(new Action<int, int>(UpdateResults), index, value);
            }
            else
            {
                switch (index) 
                {
                    case 0:
                        result1.Text = value.ToString();
                        break;
                    case 1:
                        result2.Text = value.ToString();
                        break;
                    case 2:
                        result3.Text = value.ToString();
                        break;
                }
            }
        }

        private void ComboBoxThreadPriority1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void ComboBoxThreadPriority2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxThreadPriority3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ThreadStart_Click(object sender, EventArgs e)
        {
            string[] threadPriority = new string[3];
            threadPriority[0] = ComboBoxThreadPriority1.Text;
            threadPriority[1] = ComboBoxThreadPriority2.Text;
            threadPriority[2] = ComboBoxThreadPriority3.Text;
            Bandit.BanditStatrt(threadPriority);
            int[] result = Bandit.Shots;
        }

        private void ThreadStop_Click(object sender, EventArgs e)
        {
            Bandit.BanditStop();
            congratulation.Text = Bandit.CongratulationGeneration();
        }
    }
}
