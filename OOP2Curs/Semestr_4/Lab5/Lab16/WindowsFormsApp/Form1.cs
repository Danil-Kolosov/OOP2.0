using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using CollectionProcessing;
using System.IO;
using CollectionEvent;
using AnimalLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;


namespace WindowsFormsApp
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateCollection_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox(
            "Введите размер коллекции (от 0 до 1000):",
            "Создание коллекции",
            "10" // Значение по умолчанию
            );

            // Проверяем, что введено число
            if (int.TryParse(input, out int size) && size > 0 && size < 1000)
            {
                string name = Interaction.InputBox(
                "Название коллекции:",
                "Создание коллекции",
                "Зоопарк - ваше будующее!" // Значение по умолчанию
                );
                // Создаём коллекцию
                FileSaveCollection.Create(size);
                FileSaveCollection.HashTable.Name = name;
                MessageBox.Show($"Коллекция создана! Размер: {size}\nИмя: {name}");
                DisplayHashTableInTreeView();
                EnableOperations();
            }
            else
            {
                MessageBox.Show("Некорректный размер! Введите положительное число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DisplayHashTableInTreeView()
        {
            TreeCollectionView.Nodes.Clear();

            TreeNode rootNode = TreeCollectionView.Nodes.Add("Хэш-таблица");

            // Группируем элементы по ключу
            var groupedItems = FileSaveCollection.HashTable.GetPrintString()
                //.OrderBy(group => group.Key)
                .GroupBy(item => item.Key)
                .ToList();

            foreach (var group in groupedItems)
            {
                // Создаем родительский узел для ключа
                TreeNode keyNode = rootNode.Nodes.Add(group.Key);

                // Добавляем все значения для этого ключа
                foreach (var item in group)
                {
                    //keyNode.Nodes.Add(item.Value.ToString());
                    string value = item.Value.ToString();
                    keyNode.Nodes.Add(value); // Добавляем текст с переносами
                }
            }

            TreeCollectionView.ExpandAll();
        }
        
        private void EnableOperations() 
        {
            OperationsMenu.Enabled = true;
            SaveAsCollection.Enabled = true;
        }

        private async void OpenCollection_Click(object sender, EventArgs e)
        {          
            OpenFileDialog dialog = new OpenFileDialog(); //Тут окно создается
            dialog.Filter = "Binary files(*.bin)|*.bin|XML files(*.xml)|*.xml|Json files(*.js)|*.js"; //Это фильтры выбора файлов
            if (dialog.ShowDialog() == DialogResult.Cancel) //Тут окно открывается
            {
                return; //Если ничего не выбрал и закрыл его
            }
            string collectionPath = dialog.FileName; //Полный путь
            string directory = Path.GetDirectoryName(collectionPath); //Путь до директории
            string filenameCollection = Path.GetFileNameWithoutExtension(collectionPath); //Имя файла без расширения
            string extension = Path.GetExtension(collectionPath); //Расширение файла без всего
            string journalPath = Path.Combine(directory, $"{filenameCollection}{extension.ToUpper()}Journal.txt");

            List<string> pathList = new List<string>
            {
                collectionPath,
                journalPath,
                filenameCollection,
                extension
            };
            switch (extension)
            {
                case ".bin":
                    await FileSaveCollection.DeserializeFromBinary(pathList);
                    break;
                case ".xml":
                    await FileSaveCollection.DeserializeFromXml(pathList);
                    break;
                case ".js":
                    await FileSaveCollection.DeserializeFromJs(pathList);
                    break;
            }
            if(FileSaveCollection.HashTable != null)
            {
                EnableOperations();
                SaveCollection.Enabled = true;
                DisplayHashTableInTreeView();
            }            
        }

        private void SaveAsCollection_Click(object sender, EventArgs e)
        {
            if(FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
              {
                SaveCollection.Enabled = true;
                Save();
            }
        }

        private void Save() 
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Binary files(*.bin)|*.bin|XML files(*.xml)|*.xml|Json files(*.js)|*.js";
            if (dialog.ShowDialog() == DialogResult.Cancel) //Тут окно открывается
            {
                return; //Если ничего не выбрал и закрыл его
            }
            List<string> pathList = new List<string>();
            string collectionPath = dialog.FileName;
            string directory = Path.GetDirectoryName(collectionPath);
            string filenameCollection = Path.GetFileNameWithoutExtension(collectionPath);
            string extension = Path.GetExtension(collectionPath);
            string journalPath = Path.Combine(directory, $"{filenameCollection}{extension.ToUpper()}Journal.txt");

            pathList.Add(collectionPath);
            pathList.Add(journalPath);
            pathList.Add(filenameCollection);
            pathList.Add(extension);
            FileSaveCollection.FileSave(pathList);
        }

        private void AutoFill_Click(object sender, EventArgs e)
        {
            if (FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (FileSaveCollection.RandomInit())
                {
                    DisplayHashTableInTreeView();
                }
                else
                {
                    MessageBox.Show("Хэш таблица уже имеет элементы или не выбрана", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }         
        }

        private void RemoveByKey_Click(object sender, EventArgs e)
        {
            if (FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string input = Interaction.InputBox(
                "Введите ключ элемента:",
                "Удаление элемента",
                "" // Значение по умолчанию
                );
                if (input == "")
                    return;
                if (!FileSaveCollection.RemoveByKey(input))
                    MessageBox.Show("Такого ключа в коллекции нет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DisplayHashTableInTreeView();
                    MessageBox.Show("Элемент успешно удален", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }            
        }

        private void UpdateByKey_Click(object sender, EventArgs e)
        {
            if (FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                {
                    string input = Interaction.InputBox(
                    "Введите ключ элемента:",
                    "Изменение элемента",
                    "" // Значение по умолчанию
                    );
                    if (input == "")
                        return;
                    if (FileSaveCollection.ContainsKey(input))
                    {
                        using (var dialog = new AddItemDialog(input))
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                string selectedType = dialog.SelectedType;
                                var parameters = dialog.Parameters;
                                if (FileSaveCollection.UpdayeByKey(selectedType, parameters)) 
                                {
                                    //параметрс - это словарь Вес - 0 такого типа
                                    // Используем полученные параметры
                                    StringBuilder message = new StringBuilder();
                                    message.AppendLine($"Выбран тип: {selectedType}");
                                    foreach (var param in parameters)
                                    {
                                        message.AppendLine($"{param.Key}: {param.Value}");
                                    }

                                    MessageBox.Show(message.ToString(), "Параметры созданы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DisplayHashTableInTreeView();
                                    MessageBox.Show("Элемент изменен", "Изменение элемента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else 
                                {
                                    MessageBox.Show("Введены недопустимые значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }                                    
                            }
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Такого ключа в коллекции нет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            if(FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                using (var dialog = new AddItemDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedType = dialog.SelectedType;
                        var parameters = dialog.Parameters;
                        if(FileSaveCollection.AddItem(selectedType, parameters))
                        {
                            //параметрс - это словарь Вес - 0 такого типа
                            // Используем полученные параметры
                            StringBuilder message = new StringBuilder();
                            message.AppendLine($"Выбран тип: {selectedType}");
                            foreach (var param in parameters)
                            {
                                message.AppendLine($"{param.Key}: {param.Value}");
                            }

                            MessageBox.Show(message.ToString(), "Параметры созданы");
                            DisplayHashTableInTreeView();
                        }
                        else
                        {
                            MessageBox.Show("Введены недопустимые значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }                
            }
        }

        private void Journal_Click(object sender, EventArgs e)
        {
            string outText = FileSaveCollection.GetJournal(); 
            //Если журнал уже был сохранен в файл, то при иналичии новыъ записей дозаписываем их
            //и выводим файл
            //Иначе выводим журнал ту стринг
            var logViewer = new LogViewerForm(outText);
            logViewer.ShowDialog(); // Показываем как модальное окно
        }

        private void SearchByKey_Click(object sender, EventArgs e)
        {
            if (FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string input = Interaction.InputBox(
                "Введите ключ элемента:",
                "Поиск элемента",
                "" // Значение по умолчанию
                );
                if (input == "")
                    return;
                if (FileSaveCollection.SearchByKey(input) == null)
                    MessageBox.Show("Такого ключа в коллекции нет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var logViewer = new LogViewerForm("Элемент найден:\n" + FileSaveCollection.SearchByKey(input));
                    logViewer.ShowDialog(); // Показываем окно                
                }
            }
        }

        private void FilterByWeight_Click(object sender, EventArgs e)
        {
            FilterProcessor("Weight", true);                      
        }

        private void FilterByHeight_Click(object sender, EventArgs e)
        {
            FilterProcessor("Height", true);           
        }

        private void FilterByAge_Click(object sender, EventArgs e)
        {
            FilterProcessor("Age", true);            
        }

        private void FilterByName_Click(object sender, EventArgs e)
        {
            FilterProcessor("Name");
            //string input = Interaction.InputBox(
            //"Введите значение для фильтрации:",
            //"Фильтрация",
            //"" // Значение по умолчанию
            //);
            //if (input.ToString()=="")
            //    MessageBox.Show("Введено не корректное значение,\nлибо коллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else
            //{
                
            //        var logViewer = new LogViewerForm("Отфильтровано:\n", FileSaveCollection.FilterBy("Name", input));
            //        logViewer.ShowDialog();
                
            //}
        }

        private void FilterBySpecie_Click(object sender, EventArgs e)
        {
            FilterProcessor("Specie");           
        }

        private void FilterByLocation_Click(object sender, EventArgs e)
        {
            FilterProcessor("Location");            
        }

        private void FilterByLivingEnvironment_Click(object sender, EventArgs e)
        {
            FilterProcessor("Living environment");            
        }

        private void FilterByLifestyle_Click(object sender, EventArgs e)
        {
            FilterProcessor("Life style");            
        }

        private void FilterByHoofSize_Click(object sender, EventArgs e)
        {
            FilterProcessor("hoofSize", true);            
        }

        private void FilterByHornsSize_Click(object sender, EventArgs e)
        {
            FilterProcessor("hornsSize", true); 
        }

        private void FilterByWingspan_Click(object sender, EventArgs e)
        {
            FilterProcessor("wingspan", true);            
        }

        private void FilterByFlightRange_Click(object sender, EventArgs e)
        {
            FilterProcessor("flightRange", true);
            /*string input = Interaction.InputBox(
            "Введите значение для фильтрации:",
            "Фильтрация",
            "" // Значение по умолчанию
            );
            if (!(int.TryParse(input, out int val) && val > 0))
                MessageBox.Show("Введено не корректное значение,\nлибо коллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
               
                    var logViewer = new LogViewerForm("Отфильтровано:\n", FileSaveCollection.FilterBy("flightRange", input));
                    logViewer.ShowDialog();
                
            }*/
        }

        private void FilterProcessor(string field, bool isInt = false) 
        {
            if (FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string input = Interaction.InputBox(
                                    "Введите значение для сортировки:",
                                    "Сортировка",
                                    "" // Значение по умолчанию
                                    );
                if (isInt)
                {
                    if (!(int.TryParse(input, out int val) && val >= 0))
                        MessageBox.Show("Введено не корректное значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var logViewer = new LogViewerForm("Отфильтровано:\n", FileSaveCollection.FilterBy(field/*"flightRange"*/, input));
                        logViewer.ShowDialog();
                    }
                }
                else
                {
                    if (input.ToString() == "")
                        MessageBox.Show("Введено не корректное значение!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        var logViewer = new LogViewerForm("Отфильтровано:\n", FileSaveCollection.FilterBy(field/*"Life style"*/, input));
                        logViewer.ShowDialog();
                    }
                }
            }
        }

        private void SortProceccor(string field, Func<string, List<KeyValuePair<string, string>>> processor, bool isInt = false)
        {
            if (FileSaveCollection.HashTable == null)
                MessageBox.Show("Kоллекция не выбрана!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                var logViewer = new LogViewerForm("Отсортировано:\n", processor(field));
                logViewer.ShowDialog();
                                
            }
        }

        private void SortByWeight_Click(object sender, EventArgs e)
        {
            SortProceccor("Weight", FileSaveCollection.SortBy, true);
        }

        private void ростToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortProceccor("Height", FileSaveCollection.SortBy, true);
        }

        private void возраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortProceccor("Age", FileSaveCollection.SortBy, true);
        }

        private void имяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortProceccor("Name", FileSaveCollection.SortBy);
        }

        private void видToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortProceccor("Specie", FileSaveCollection.SortBy);
        }

        private void местоОбитанияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortProceccor("Location", FileSaveCollection.SortBy);
        }

        private void средаОбитанияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortProceccor("Living environment", FileSaveCollection.SortBy);
        }

        private void образЖизниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortProceccor("Life style", FileSaveCollection.SortBy);
        }

        private void размерКопытToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortProceccor("hoofSize", FileSaveCollection.SortBy, true);
        }

        private void размерРоговToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortProceccor("hornsSize", FileSaveCollection.SortBy, true);
        }

        private void размахКрыльевToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortProceccor("wingspan", FileSaveCollection.SortBy, true);
        }

        private void дальностьПолетаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortProceccor("flightRange", FileSaveCollection.SortBy, true);
        }

        private void AverageWeightQuerry_Click(object sender, EventArgs e)
        {
            var logViewer = new LogViewerForm("Запрос:\n", FileSaveCollection.Query("AverageWeight"));
            logViewer.ShowDialog();
        }

        private void MaxAgeQuerry_Click(object sender, EventArgs e)
        {
            var logViewer = new LogViewerForm("Запрос:\n", FileSaveCollection.Query("MaxAge"));
            logViewer.ShowDialog();
        }

        private void AverageFoodSupplyQuerry_Click(object sender, EventArgs e)
        {
            var logViewer = new LogViewerForm("Запрос:\n", FileSaveCollection.Query("FoodSupply"));
            logViewer.ShowDialog();
        }

        private void SaveCollection_Click_1(object sender, EventArgs e)
        {
            if (FileSaveCollection.QuikSave()) 
            {
                MessageBox.Show("Колекция успешно сохранена", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Сначала необходимо сохранить коллекцию в файл\n(Кнопка Сохранить как)", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
