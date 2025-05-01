namespace WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OperationsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoFill = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveByKey = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateByKey = new System.Windows.Forms.ToolStripMenuItem();
            this.AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchByKey = new System.Windows.Forms.ToolStripMenuItem();
            this.Sort = new System.Windows.Forms.ToolStripMenuItem();
            this.SortByWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.ростToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.возраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.имяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местоОбитанияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средаОбитанияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.образЖизниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерКопытToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.размерРоговToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.размахКрыльевToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.дальностьПолетаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Filter = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByAge = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByName = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterBySpecie = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByLivingEnvironment = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByLifestyle = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByHoofSize = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByHornsSize = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByWingspan = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterByFlightRange = new System.Windows.Forms.ToolStripMenuItem();
            this.Querry = new System.Windows.Forms.ToolStripMenuItem();
            this.AverageWeightQuerry = new System.Windows.Forms.ToolStripMenuItem();
            this.MaxAgeQuerry = new System.Windows.Forms.ToolStripMenuItem();
            this.AverageFoodSupplyQuerry = new System.Windows.Forms.ToolStripMenuItem();
            this.Journal = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeCollectionView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateCollection,
            this.OpenCollection,
            this.SaveCollection,
            this.SaveAsCollection});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(167, 28);
            this.FileMenu.Text = "Файл коллекции";
            // 
            // CreateCollection
            // 
            this.CreateCollection.Name = "CreateCollection";
            this.CreateCollection.Size = new System.Drawing.Size(211, 28);
            this.CreateCollection.Text = "Создать";
            this.CreateCollection.Click += new System.EventHandler(this.CreateCollection_Click);
            // 
            // OpenCollection
            // 
            this.OpenCollection.Name = "OpenCollection";
            this.OpenCollection.Size = new System.Drawing.Size(211, 28);
            this.OpenCollection.Text = "Открыть";
            this.OpenCollection.Click += new System.EventHandler(this.OpenCollection_Click);
            // 
            // SaveCollection
            // 
            this.SaveCollection.Enabled = false;
            this.SaveCollection.Name = "SaveCollection";
            this.SaveCollection.Size = new System.Drawing.Size(211, 28);
            this.SaveCollection.Text = "Сохранить";
            this.SaveCollection.Click += new System.EventHandler(this.SaveCollection_Click_1);
            // 
            // SaveAsCollection
            // 
            this.SaveAsCollection.Enabled = false;
            this.SaveAsCollection.Name = "SaveAsCollection";
            this.SaveAsCollection.Size = new System.Drawing.Size(211, 28);
            this.SaveAsCollection.Text = "Сохранить как";
            this.SaveAsCollection.Click += new System.EventHandler(this.SaveAsCollection_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OperationsMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1332, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OperationsMenu
            // 
            this.OperationsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoFill,
            this.RemoveByKey,
            this.UpdateByKey,
            this.AddItem,
            this.SearchByKey,
            this.Sort,
            this.Filter,
            this.Querry,
            this.Journal});
            this.OperationsMenu.Enabled = false;
            this.OperationsMenu.Name = "OperationsMenu";
            this.OperationsMenu.Size = new System.Drawing.Size(113, 28);
            this.OperationsMenu.Text = "Операции";
            // 
            // AutoFill
            // 
            this.AutoFill.Name = "AutoFill";
            this.AutoFill.Size = new System.Drawing.Size(456, 28);
            this.AutoFill.Text = "Заполнить автоматически";
            this.AutoFill.Click += new System.EventHandler(this.AutoFill_Click);
            // 
            // RemoveByKey
            // 
            this.RemoveByKey.Name = "RemoveByKey";
            this.RemoveByKey.Size = new System.Drawing.Size(456, 28);
            this.RemoveByKey.Text = "Удалить элемент (по ключу)";
            this.RemoveByKey.Click += new System.EventHandler(this.RemoveByKey_Click);
            // 
            // UpdateByKey
            // 
            this.UpdateByKey.Name = "UpdateByKey";
            this.UpdateByKey.Size = new System.Drawing.Size(456, 28);
            this.UpdateByKey.Text = "Обновить элемент (по ключу)";
            this.UpdateByKey.Click += new System.EventHandler(this.UpdateByKey_Click);
            // 
            // AddItem
            // 
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(456, 28);
            this.AddItem.Text = "Добавить элемент";
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // SearchByKey
            // 
            this.SearchByKey.Name = "SearchByKey";
            this.SearchByKey.Size = new System.Drawing.Size(456, 28);
            this.SearchByKey.Text = "Поиск (по ключу)";
            this.SearchByKey.Click += new System.EventHandler(this.SearchByKey_Click);
            // 
            // Sort
            // 
            this.Sort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortByWeight,
            this.ростToolStripMenuItem,
            this.возраToolStripMenuItem,
            this.имяToolStripMenuItem,
            this.видToolStripMenuItem,
            this.местоОбитанияToolStripMenuItem,
            this.средаОбитанияToolStripMenuItem,
            this.образЖизниToolStripMenuItem,
            this.размерКопытToolStripMenuItem1,
            this.размерРоговToolStripMenuItem1,
            this.размахКрыльевToolStripMenuItem1,
            this.дальностьПолетаToolStripMenuItem1});
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(473, 28);
            this.Sort.Text = "Сортировка";
            // 
            // SortByWeight
            // 
            this.SortByWeight.Name = "SortByWeight";
            this.SortByWeight.Size = new System.Drawing.Size(246, 28);
            this.SortByWeight.Text = "Вес";
            this.SortByWeight.Click += new System.EventHandler(this.SortByWeight_Click);
            // 
            // ростToolStripMenuItem
            // 
            this.ростToolStripMenuItem.Name = "ростToolStripMenuItem";
            this.ростToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.ростToolStripMenuItem.Text = "Рост";
            this.ростToolStripMenuItem.Click += new System.EventHandler(this.ростToolStripMenuItem_Click);
            // 
            // возраToolStripMenuItem
            // 
            this.возраToolStripMenuItem.Name = "возраToolStripMenuItem";
            this.возраToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.возраToolStripMenuItem.Text = "Возраст";
            this.возраToolStripMenuItem.Click += new System.EventHandler(this.возраToolStripMenuItem_Click);
            // 
            // имяToolStripMenuItem
            // 
            this.имяToolStripMenuItem.Name = "имяToolStripMenuItem";
            this.имяToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.имяToolStripMenuItem.Text = "Имя";
            this.имяToolStripMenuItem.Click += new System.EventHandler(this.имяToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.видToolStripMenuItem.Text = "Вид";
            this.видToolStripMenuItem.Click += new System.EventHandler(this.видToolStripMenuItem_Click);
            // 
            // местоОбитанияToolStripMenuItem
            // 
            this.местоОбитанияToolStripMenuItem.Name = "местоОбитанияToolStripMenuItem";
            this.местоОбитанияToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.местоОбитанияToolStripMenuItem.Text = "Место обитания";
            this.местоОбитанияToolStripMenuItem.Click += new System.EventHandler(this.местоОбитанияToolStripMenuItem_Click);
            // 
            // средаОбитанияToolStripMenuItem
            // 
            this.средаОбитанияToolStripMenuItem.Name = "средаОбитанияToolStripMenuItem";
            this.средаОбитанияToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.средаОбитанияToolStripMenuItem.Text = "Среда обитания";
            this.средаОбитанияToolStripMenuItem.Click += new System.EventHandler(this.средаОбитанияToolStripMenuItem_Click);
            // 
            // образЖизниToolStripMenuItem
            // 
            this.образЖизниToolStripMenuItem.Name = "образЖизниToolStripMenuItem";
            this.образЖизниToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.образЖизниToolStripMenuItem.Text = "Образ жизни";
            this.образЖизниToolStripMenuItem.Click += new System.EventHandler(this.образЖизниToolStripMenuItem_Click);
            // 
            // размерКопытToolStripMenuItem1
            // 
            this.размерКопытToolStripMenuItem1.Name = "размерКопытToolStripMenuItem1";
            this.размерКопытToolStripMenuItem1.Size = new System.Drawing.Size(246, 28);
            this.размерКопытToolStripMenuItem1.Text = "Размер копыт";
            this.размерКопытToolStripMenuItem1.Click += new System.EventHandler(this.размерКопытToolStripMenuItem1_Click);
            // 
            // размерРоговToolStripMenuItem1
            // 
            this.размерРоговToolStripMenuItem1.Name = "размерРоговToolStripMenuItem1";
            this.размерРоговToolStripMenuItem1.Size = new System.Drawing.Size(246, 28);
            this.размерРоговToolStripMenuItem1.Text = "Размер рогов";
            this.размерРоговToolStripMenuItem1.Click += new System.EventHandler(this.размерРоговToolStripMenuItem1_Click);
            // 
            // размахКрыльевToolStripMenuItem1
            // 
            this.размахКрыльевToolStripMenuItem1.Name = "размахКрыльевToolStripMenuItem1";
            this.размахКрыльевToolStripMenuItem1.Size = new System.Drawing.Size(246, 28);
            this.размахКрыльевToolStripMenuItem1.Text = "Размах крыльев";
            this.размахКрыльевToolStripMenuItem1.Click += new System.EventHandler(this.размахКрыльевToolStripMenuItem1_Click);
            // 
            // дальностьПолетаToolStripMenuItem1
            // 
            this.дальностьПолетаToolStripMenuItem1.Name = "дальностьПолетаToolStripMenuItem1";
            this.дальностьПолетаToolStripMenuItem1.Size = new System.Drawing.Size(246, 28);
            this.дальностьПолетаToolStripMenuItem1.Text = "Дальность полета";
            this.дальностьПолетаToolStripMenuItem1.Click += new System.EventHandler(this.дальностьПолетаToolStripMenuItem1_Click);
            // 
            // Filter
            // 
            this.Filter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterByWeight,
            this.FilterByHeight,
            this.FilterByAge,
            this.FilterByName,
            this.FilterBySpecie,
            this.FilterByLocation,
            this.FilterByLivingEnvironment,
            this.FilterByLifestyle,
            this.FilterByHoofSize,
            this.FilterByHornsSize,
            this.FilterByWingspan,
            this.FilterByFlightRange});
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(456, 28);
            this.Filter.Text = "Фильтрация элементов";
            // 
            // FilterByWeight
            // 
            this.FilterByWeight.Name = "FilterByWeight";
            this.FilterByWeight.Size = new System.Drawing.Size(246, 28);
            this.FilterByWeight.Text = "Вес";
            this.FilterByWeight.Click += new System.EventHandler(this.FilterByWeight_Click);
            // 
            // FilterByHeight
            // 
            this.FilterByHeight.Name = "FilterByHeight";
            this.FilterByHeight.Size = new System.Drawing.Size(246, 28);
            this.FilterByHeight.Text = "Рост";
            this.FilterByHeight.Click += new System.EventHandler(this.FilterByHeight_Click);
            // 
            // FilterByAge
            // 
            this.FilterByAge.Name = "FilterByAge";
            this.FilterByAge.Size = new System.Drawing.Size(246, 28);
            this.FilterByAge.Text = "Возраст";
            this.FilterByAge.Click += new System.EventHandler(this.FilterByAge_Click);
            // 
            // FilterByName
            // 
            this.FilterByName.Name = "FilterByName";
            this.FilterByName.Size = new System.Drawing.Size(246, 28);
            this.FilterByName.Text = "Имя";
            this.FilterByName.Click += new System.EventHandler(this.FilterByName_Click);
            // 
            // FilterBySpecie
            // 
            this.FilterBySpecie.Name = "FilterBySpecie";
            this.FilterBySpecie.Size = new System.Drawing.Size(246, 28);
            this.FilterBySpecie.Text = "Вид";
            this.FilterBySpecie.Click += new System.EventHandler(this.FilterBySpecie_Click);
            // 
            // FilterByLocation
            // 
            this.FilterByLocation.Name = "FilterByLocation";
            this.FilterByLocation.Size = new System.Drawing.Size(246, 28);
            this.FilterByLocation.Text = "Место обитания";
            this.FilterByLocation.Click += new System.EventHandler(this.FilterByLocation_Click);
            // 
            // FilterByLivingEnvironment
            // 
            this.FilterByLivingEnvironment.Name = "FilterByLivingEnvironment";
            this.FilterByLivingEnvironment.Size = new System.Drawing.Size(246, 28);
            this.FilterByLivingEnvironment.Text = "Среда обитания";
            this.FilterByLivingEnvironment.Click += new System.EventHandler(this.FilterByLivingEnvironment_Click);
            // 
            // FilterByLifestyle
            // 
            this.FilterByLifestyle.Name = "FilterByLifestyle";
            this.FilterByLifestyle.Size = new System.Drawing.Size(246, 28);
            this.FilterByLifestyle.Text = "Образ жизни";
            this.FilterByLifestyle.Click += new System.EventHandler(this.FilterByLifestyle_Click);
            // 
            // FilterByHoofSize
            // 
            this.FilterByHoofSize.Name = "FilterByHoofSize";
            this.FilterByHoofSize.Size = new System.Drawing.Size(246, 28);
            this.FilterByHoofSize.Text = "Размер копыт";
            this.FilterByHoofSize.Click += new System.EventHandler(this.FilterByHoofSize_Click);
            // 
            // FilterByHornsSize
            // 
            this.FilterByHornsSize.Name = "FilterByHornsSize";
            this.FilterByHornsSize.Size = new System.Drawing.Size(246, 28);
            this.FilterByHornsSize.Text = "Размер рогов";
            this.FilterByHornsSize.Click += new System.EventHandler(this.FilterByHornsSize_Click);
            // 
            // FilterByWingspan
            // 
            this.FilterByWingspan.Name = "FilterByWingspan";
            this.FilterByWingspan.Size = new System.Drawing.Size(246, 28);
            this.FilterByWingspan.Text = "Размах крыльев";
            this.FilterByWingspan.Click += new System.EventHandler(this.FilterByWingspan_Click);
            // 
            // FilterByFlightRange
            // 
            this.FilterByFlightRange.Name = "FilterByFlightRange";
            this.FilterByFlightRange.Size = new System.Drawing.Size(246, 28);
            this.FilterByFlightRange.Text = "Дальность полета";
            this.FilterByFlightRange.Click += new System.EventHandler(this.FilterByFlightRange_Click);
            // 
            // Querry
            // 
            this.Querry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AverageWeightQuerry,
            this.MaxAgeQuerry,
            this.AverageFoodSupplyQuerry});
            this.Querry.Name = "Querry";
            this.Querry.Size = new System.Drawing.Size(456, 28);
            this.Querry.Text = "Запросы";
            // 
            // AverageWeightQuerry
            // 
            this.AverageWeightQuerry.Name = "AverageWeightQuerry";
            this.AverageWeightQuerry.Size = new System.Drawing.Size(540, 28);
            this.AverageWeightQuerry.Text = "1. Средний вес всех животных";
            this.AverageWeightQuerry.Click += new System.EventHandler(this.AverageWeightQuerry_Click);
            // 
            // MaxAgeQuerry
            // 
            this.MaxAgeQuerry.Name = "MaxAgeQuerry";
            this.MaxAgeQuerry.Size = new System.Drawing.Size(540, 28);
            this.MaxAgeQuerry.Text = "2. Максимальный возраст";
            this.MaxAgeQuerry.Click += new System.EventHandler(this.MaxAgeQuerry_Click);
            // 
            // AverageFoodSupplyQuerry
            // 
            this.AverageFoodSupplyQuerry.Name = "AverageFoodSupplyQuerry";
            this.AverageFoodSupplyQuerry.Size = new System.Drawing.Size(540, 28);
            this.AverageFoodSupplyQuerry.Text = "3. Сколько в среднем необходимо пищи (по массе)";
            this.AverageFoodSupplyQuerry.Click += new System.EventHandler(this.AverageFoodSupplyQuerry_Click);
            // 
            // Journal
            // 
            this.Journal.Name = "Journal";
            this.Journal.Size = new System.Drawing.Size(473, 28);
            this.Journal.Text = "Показать журнал действий над коллекцией";
            this.Journal.Click += new System.EventHandler(this.Journal_Click);
            // 
            // TreeCollectionView
            // 
            this.TreeCollectionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeCollectionView.Location = new System.Drawing.Point(0, 36);
            this.TreeCollectionView.Margin = new System.Windows.Forms.Padding(6);
            this.TreeCollectionView.Name = "TreeCollectionView";
            this.TreeCollectionView.Size = new System.Drawing.Size(1332, 430);
            this.TreeCollectionView.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 466);
            this.Controls.Add(this.TreeCollectionView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Управление зоопарками";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem CreateCollection;
        private System.Windows.Forms.ToolStripMenuItem OpenCollection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SaveCollection;
        private System.Windows.Forms.ToolStripMenuItem OperationsMenu;
        private System.Windows.Forms.ToolStripMenuItem AutoFill;
        private System.Windows.Forms.ToolStripMenuItem RemoveByKey;
        private System.Windows.Forms.ToolStripMenuItem UpdateByKey;
        private System.Windows.Forms.ToolStripMenuItem AddItem;
        private System.Windows.Forms.ToolStripMenuItem SearchByKey;
        private System.Windows.Forms.ToolStripMenuItem Sort;
        private System.Windows.Forms.ToolStripMenuItem Filter;
        private System.Windows.Forms.ToolStripMenuItem Querry;
        private System.Windows.Forms.ToolStripMenuItem AverageWeightQuerry;
        private System.Windows.Forms.ToolStripMenuItem MaxAgeQuerry;
        private System.Windows.Forms.ToolStripMenuItem AverageFoodSupplyQuerry;
        private System.Windows.Forms.ToolStripMenuItem SortByWeight;
        private System.Windows.Forms.ToolStripMenuItem FilterByWeight;
        private System.Windows.Forms.ToolStripMenuItem FilterByHeight;
        private System.Windows.Forms.ToolStripMenuItem FilterByAge;
        private System.Windows.Forms.ToolStripMenuItem Journal;
        private System.Windows.Forms.TreeView TreeCollectionView;
        private System.Windows.Forms.ToolStripMenuItem FilterByName;
        private System.Windows.Forms.ToolStripMenuItem FilterBySpecie;
        private System.Windows.Forms.ToolStripMenuItem FilterByLocation;
        private System.Windows.Forms.ToolStripMenuItem FilterByLivingEnvironment;
        private System.Windows.Forms.ToolStripMenuItem FilterByLifestyle;
        private System.Windows.Forms.ToolStripMenuItem FilterByHoofSize;
        private System.Windows.Forms.ToolStripMenuItem FilterByHornsSize;
        private System.Windows.Forms.ToolStripMenuItem FilterByWingspan;
        private System.Windows.Forms.ToolStripMenuItem FilterByFlightRange;
        private System.Windows.Forms.ToolStripMenuItem SaveAsCollection;
        private System.Windows.Forms.ToolStripMenuItem ростToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem возраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem имяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem местоОбитанияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem средаОбитанияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem образЖизниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерКопытToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem размерРоговToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem размахКрыльевToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem дальностьПолетаToolStripMenuItem1;
    }
}

