using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // Запуск формы из Windows Forms приложения
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Замените Form1 на имя вашей формы
        }
    }
}

//тут не работает на то, только это и работат