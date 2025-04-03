using System;
using System.Windows.Forms;
using One_armedBandit;

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

            this.FormClosing += new FormClosingEventHandler(MyForm_FormClosing); //Для управления закрытием формы
            Bandit.OnUpdateUI += UpdateResults; //Подписка на обновление интерфейса
        }

        private void UpdateResults(int index, int value) 
        {
            // Обновление элементов управления в основном потоке
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
            Bandit.BanditStart(threadPriority);
            int[] result = Bandit.Shots;
        }

        private void ThreadStop_Click(object sender, EventArgs e)
        {
            if(Bandit.IsThreadsAllive)
            {
                Bandit.BanditStop();
                congratulation.Text = Bandit.CongratulationGeneration();
            }
        }

        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Bandit.IsThreadsAllive) 
            {
                // Если хотя бы один поток работает, отменяем закрытие
                MessageBox.Show("Невозможно закрыть форму, пока работают потоки.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Отменяем закрытие формы
            }
            else
            {
                // Запросить подтверждение закрытия
                var result = MessageBox.Show("Вы уверены, что хотите закрыть форму?", "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
