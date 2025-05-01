using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class AddItemDialog : Form
    {
        private string keyToAdd;
        public string SelectedType { get; private set; }
        public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

        public AddItemDialog(string key = null)
        {
            if (key != null)
                keyToAdd = key;
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Заполняем ComboBox
            comboBoxType.Items.AddRange(new[] { "Животное", "Млекопитающее", "Парнокопытное", "Птица"});
            comboBoxType.SelectedIndex = 0;
            comboBoxType.SelectedIndexChanged += (s, e) => UpdateParametersFields();

            // Инициализация при открытии
            UpdateParametersFields();
        }

        private void UpdateParametersFields()
        {
            SelectedType = comboBoxType.SelectedItem.ToString();
            panelParameters.Controls.Clear();
            if(keyToAdd != null)
                AddParameterField("Ключ", keyToAdd, true);
            else
                AddParameterField("Ключ", "Зоопарк1");
            switch (SelectedType)
            {
                case "Животное":
                    AddParameterField("Вес", "0");
                    AddParameterField("Рост", "0");
                    AddParameterField("Возраст", "0");
                    AddParameterField("Имя", "none");
                    AddParameterField("Заметки", "none");
                    break;

                case "Млекопитающее":
                    AddParameterField("Вес", "0");
                    AddParameterField("Рост", "0");
                    AddParameterField("Возраст", "0");
                    AddParameterField("Имя", "none");
                    AddParameterField("Вид", "none");
                    AddParameterField("Место обитания", "none");
                    AddParameterField("Среда обитания", "none");
                    AddParameterField("Образ жизни", "none");
                    AddParameterField("Заметки", "none");
                    //AddParameterField("Среда обитания", "Целое");
                    break;

                case "Парнокопытное":
                    AddParameterField("Вес", "0");
                    AddParameterField("Рост", "0");
                    AddParameterField("Возраст", "0");
                    AddParameterField("Имя", "none");
                    AddParameterField("Вид", "none");
                    AddParameterField("Место обитания", "none");
                    AddParameterField("Среда обитания", "none");
                    AddParameterField("Образ жизни", "none");
                    AddParameterField("Размер копыт", "0");
                    AddParameterField("Размер рогов", "0");
                    AddParameterField("Заметки", "none");
                    break;
                case "Птица":
                    AddParameterField("Вес", "0");
                    AddParameterField("Рост", "0");
                    AddParameterField("Возраст", "0");
                    AddParameterField("Имя", "none");
                    AddParameterField("Размах крыльев", "0");
                    AddParameterField("Дальность полета", "0");
                    AddParameterField("Вид", "none");
                    AddParameterField("Заметки", "none");
                    break;
            }
        }

        private void AddParameterField(string labelText, string defaultValue, bool readOnly = false)
        {
            int yPos = panelParameters.Controls.Count * 15;

            var label = new Label
            {
                Text = labelText,
                Location = new Point(10, yPos),
                Width = 180,
                //Font = new Font("Segoe UI", 9)
            };

            var textBox = new TextBox
            {
                Text = defaultValue,
                Location = new Point(200, yPos),
                Width = 100,
                Tag = labelText,
                ReadOnly = readOnly, // Запрещаем редактирование
                //BackColor = SystemColors.Window // Сохраняем стандартный фон
            };

            panelParameters.Controls.Add(label);
            panelParameters.Controls.Add(textBox);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Parameters.Clear();
            foreach (Control control in panelParameters.Controls)
            {
                if (control is TextBox textBox)
                {
                    Parameters[textBox.Tag.ToString()] = textBox.Text;
                }
            }
            DialogResult = DialogResult.OK;
        }
    }
}