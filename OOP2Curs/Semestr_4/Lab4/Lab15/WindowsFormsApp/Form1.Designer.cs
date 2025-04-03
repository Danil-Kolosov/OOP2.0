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
            this.ComboBoxThreadPriority2 = new System.Windows.Forms.ComboBox();
            this.ComboBoxThreadPriority3 = new System.Windows.Forms.ComboBox();
            this.ComboBoxThreadPriority1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ThreadStart = new System.Windows.Forms.Button();
            this.ThreadStop = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.congratulation = new System.Windows.Forms.Label();
            this.result3 = new System.Windows.Forms.Label();
            this.result2 = new System.Windows.Forms.Label();
            this.result1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBoxThreadPriority2
            // 
            this.ComboBoxThreadPriority2.FormattingEnabled = true;
            this.ComboBoxThreadPriority2.Items.AddRange(new object[] {
            "Lowest",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "Highest"});
            this.ComboBoxThreadPriority2.Location = new System.Drawing.Point(6, 28);
            this.ComboBoxThreadPriority2.Name = "ComboBoxThreadPriority2";
            this.ComboBoxThreadPriority2.Size = new System.Drawing.Size(157, 32);
            this.ComboBoxThreadPriority2.TabIndex = 1;
            this.ComboBoxThreadPriority2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxThreadPriority2_SelectedIndexChanged);
            // 
            // ComboBoxThreadPriority3
            // 
            this.ComboBoxThreadPriority3.FormattingEnabled = true;
            this.ComboBoxThreadPriority3.Items.AddRange(new object[] {
            "Lowest",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "Highest"});
            this.ComboBoxThreadPriority3.Location = new System.Drawing.Point(6, 28);
            this.ComboBoxThreadPriority3.Name = "ComboBoxThreadPriority3";
            this.ComboBoxThreadPriority3.Size = new System.Drawing.Size(157, 32);
            this.ComboBoxThreadPriority3.TabIndex = 2;
            this.ComboBoxThreadPriority3.SelectedIndexChanged += new System.EventHandler(this.ComboBoxThreadPriority3_SelectedIndexChanged);
            // 
            // ComboBoxThreadPriority1
            // 
            this.ComboBoxThreadPriority1.DisplayMember = "1";
            this.ComboBoxThreadPriority1.FormattingEnabled = true;
            this.ComboBoxThreadPriority1.Items.AddRange(new object[] {
            "Lowest",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "Highest"});
            this.ComboBoxThreadPriority1.Location = new System.Drawing.Point(6, 28);
            this.ComboBoxThreadPriority1.Name = "ComboBoxThreadPriority1";
            this.ComboBoxThreadPriority1.Size = new System.Drawing.Size(157, 32);
            this.ComboBoxThreadPriority1.TabIndex = 3;
            this.ComboBoxThreadPriority1.ValueMember = "1";
            this.ComboBoxThreadPriority1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxThreadPriority1_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 102);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Приоритеты потоков";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ComboBoxThreadPriority3);
            this.groupBox4.Location = new System.Drawing.Point(361, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 68);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поток 3";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComboBoxThreadPriority2);
            this.groupBox3.Location = new System.Drawing.Point(186, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 68);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поток 2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboBoxThreadPriority1);
            this.groupBox2.Location = new System.Drawing.Point(11, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 68);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поток 1";
            // 
            // ThreadStart
            // 
            this.ThreadStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThreadStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadStart.Location = new System.Drawing.Point(3, 3);
            this.ThreadStart.Name = "ThreadStart";
            this.ThreadStart.Size = new System.Drawing.Size(278, 119);
            this.ThreadStart.TabIndex = 6;
            this.ThreadStart.Text = "Запуск\r\nпотоков\r\n";
            this.ThreadStart.UseVisualStyleBackColor = true;
            this.ThreadStart.Click += new System.EventHandler(this.ThreadStart_Click);
            // 
            // ThreadStop
            // 
            this.ThreadStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThreadStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadStop.Location = new System.Drawing.Point(287, 3);
            this.ThreadStop.Name = "ThreadStop";
            this.ThreadStop.Size = new System.Drawing.Size(265, 119);
            this.ThreadStop.TabIndex = 7;
            this.ThreadStop.Text = "Остановка\r\nпотоков\r\n";
            this.ThreadStop.UseVisualStyleBackColor = true;
            this.ThreadStop.Click += new System.EventHandler(this.ThreadStop_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.congratulation);
            this.groupBox5.Controls.Add(this.result3);
            this.groupBox5.Controls.Add(this.result2);
            this.groupBox5.Controls.Add(this.result1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(4, 232);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(554, 222);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Результат";
            // 
            // congratulation
            // 
            this.congratulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.congratulation.Location = new System.Drawing.Point(1, 109);
            this.congratulation.Name = "congratulation";
            this.congratulation.Size = new System.Drawing.Size(369, 101);
            this.congratulation.TabIndex = 12;
            this.congratulation.Text = "\r\n";
            // 
            // result3
            // 
            this.result3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result3.Location = new System.Drawing.Point(459, 38);
            this.result3.Name = "result3";
            this.result3.Size = new System.Drawing.Size(62, 62);
            this.result3.TabIndex = 11;
            this.result3.Text = "*";
            this.result3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // result2
            // 
            this.result2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result2.Location = new System.Drawing.Point(243, 38);
            this.result2.Name = "result2";
            this.result2.Size = new System.Drawing.Size(62, 62);
            this.result2.TabIndex = 10;
            this.result2.Text = "*";
            this.result2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // result1
            // 
            this.result1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result1.Location = new System.Drawing.Point(41, 38);
            this.result1.Name = "result1";
            this.result1.Size = new System.Drawing.Size(62, 62);
            this.result1.TabIndex = 9;
            this.result1.Text = "*";
            this.result1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ThreadStop);
            this.panel1.Controls.Add(this.ThreadStart);
            this.panel1.Location = new System.Drawing.Point(1, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 125);
            this.panel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(568, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = " ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox ComboBoxThreadPriority2;
        private System.Windows.Forms.ComboBox ComboBoxThreadPriority3;
        private System.Windows.Forms.ComboBox ComboBoxThreadPriority1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ThreadStart;
        private System.Windows.Forms.Button ThreadStop;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label result1;
        private System.Windows.Forms.Label congratulation;
        private System.Windows.Forms.Label result3;
        private System.Windows.Forms.Label result2;
        private System.Windows.Forms.Panel panel1;
    }
}

