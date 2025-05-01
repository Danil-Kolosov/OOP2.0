using CollectionProcessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp
{
    public partial class LogViewerForm : Form
    {
        public LogViewerForm(string filePath, List<KeyValuePair<string, string>> collectionKeyValPair = null)
        {
            InitializeComponent(); // Инициализаия компонентов из Designer.cs
            LoadLogFile(filePath, collectionKeyValPair);
        }

        private void LoadLogFile(string outText, List<KeyValuePair<string, string>> collectionKeyValPair)
        {
            if (collectionKeyValPair == null)
                rtbLog.Text = outText;
            else
            {
                
                TreeCollectionView.Visible = true;
                TreeCollectionView.Nodes.Clear();
                TreeNode rootNode;
                if (outText == "Отсортировано:\n")
                { 
                    rootNode = TreeCollectionView.Nodes.Add("Отсортированная Хэш-таблица");
                    this.Text = "Сортировка";
                }
                else
                    if (outText == "Отфильтровано:\n")
                    {
                        this.Text = "Фильтрация";
                        rootNode = TreeCollectionView.Nodes.Add("Отфильтрованная Хэш-таблица");
                    }
                    else
                    {
                        this.Text = "Запрос";
                        rootNode = TreeCollectionView.Nodes.Add(outText); 
                    }
                TreeNode emptyNode;
                if (collectionKeyValPair.Count == 0)
                    emptyNode = rootNode.Nodes.Add("Подходящие элементы не найдены");
                // Группируем элементы по ключу
                var groupedItems = collectionKeyValPair
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
                        keyNode.Nodes.Add(item.Value.ToString());
                    }
                }

                TreeCollectionView.ExpandAll();
            }

            //try
            //{
            //    if (File.Exists(filePath))
            //    {
            //        rtbLog.Text = File.ReadAllText(filePath);
            //        HighlightKeywords();
            //    }
            //    else
            //    {
            //        rtbLog.Text = "Файл журнала не найден!";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    rtbLog.Text = $"Ошибка загрузки журнала:\n{ex.Message}";
            //}
        }

        private void HighlightKeywords()
        {
            // Подсветка ошибок красным
            HighlightText("ОШИБКА", Color.Red, FontStyle.Bold);

            // Подсветка предупреждений оранжевым
            HighlightText("ПРЕДУПРЕЖДЕНИЕ", Color.Orange);
        }

        private void HighlightText(string keyword, Color color, FontStyle style = FontStyle.Regular)
        {
            int start = 0;
            while (start < rtbLog.Text.Length)
            {
                start = rtbLog.Find(keyword, start, RichTextBoxFinds.MatchCase);
                if (start < 0) break;

                rtbLog.SelectionStart = start;
                rtbLog.SelectionLength = keyword.Length;
                rtbLog.SelectionColor = color;
                rtbLog.SelectionFont = new Font(rtbLog.Font, style);

                start += keyword.Length;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}