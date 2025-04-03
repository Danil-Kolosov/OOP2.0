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
        static bool working = true;

        public Form1()
        {
            InitializeComponent();
            ComboBoxThreadPriority1.SelectedIndex = 2;
            ComboBoxThreadPriority2.SelectedIndex = 2;
            ComboBoxThreadPriority3.SelectedIndex = 2;
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
            working = true;
            string[] threadPriority = new string[3];
            threadPriority[0] = ComboBoxThreadPriority1.Text;
            threadPriority[1] = ComboBoxThreadPriority2.Text;
            threadPriority[2] = ComboBoxThreadPriority3.Text;
            Bandit.BanditStatrt(threadPriority);
            int[] result = Bandit.Shots;
            while (working) 
            {
                result1.Text = result[0].ToString();
                result2.Text = result[1].ToString();
                result3.Text = result[2].ToString();
            }
        }

        private void ThreadStop_Click(object sender, EventArgs e)
        {
            working = false;
            Bandit.BanditStop();
            congratulation.Text = Bandit.CongratulationGeneration();
        }
    }
}
