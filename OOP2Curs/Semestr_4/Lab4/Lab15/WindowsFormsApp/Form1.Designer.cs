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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ThreadStart = new System.Windows.Forms.Button();
            this.ThreadStop = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            "None",
            "Lowest",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "Highest"});
            this.ComboBoxThreadPriority2.Location = new System.Drawing.Point(6, 28);
            this.ComboBoxThreadPriority2.Name = "ComboBoxThreadPriority2";
            this.ComboBoxThreadPriority2.Size = new System.Drawing.Size(121, 32);
            this.ComboBoxThreadPriority2.TabIndex = 1;
            this.ComboBoxThreadPriority2.SelectedIndexChanged += new System.EventHandler(this.ComboBoxThreadPriority2_SelectedIndexChanged);
            // 
            // ComboBoxThreadPriority3
            // 
            this.ComboBoxThreadPriority3.FormattingEnabled = true;
            this.ComboBoxThreadPriority3.Items.AddRange(new object[] {
            "None",
            "Lowest",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "Highest"});
            this.ComboBoxThreadPriority3.Location = new System.Drawing.Point(6, 28);
            this.ComboBoxThreadPriority3.Name = "ComboBoxThreadPriority3";
            this.ComboBoxThreadPriority3.Size = new System.Drawing.Size(121, 32);
            this.ComboBoxThreadPriority3.TabIndex = 2;
            this.ComboBoxThreadPriority3.SelectedIndexChanged += new System.EventHandler(this.ComboBoxThreadPriority3_SelectedIndexChanged);
            // 
            // ComboBoxThreadPriority1
            // 
            this.ComboBoxThreadPriority1.FormattingEnabled = true;
            this.ComboBoxThreadPriority1.Items.AddRange(new object[] {
            "None",
            "Lowest",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "Highest"});
            this.ComboBoxThreadPriority1.Location = new System.Drawing.Point(6, 28);
            this.ComboBoxThreadPriority1.Name = "ComboBoxThreadPriority1";
            this.ComboBoxThreadPriority1.Size = new System.Drawing.Size(121, 32);
            this.ComboBoxThreadPriority1.TabIndex = 3;
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
            this.groupBox1.Size = new System.Drawing.Size(440, 102);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Приоритеты потоков";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ComboBoxThreadPriority3);
            this.groupBox4.Location = new System.Drawing.Point(291, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(133, 69);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поток 3";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComboBoxThreadPriority2);
            this.groupBox3.Location = new System.Drawing.Point(151, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 68);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поток 2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboBoxThreadPriority1);
            this.groupBox2.Location = new System.Drawing.Point(11, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 68);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поток 1";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(518, 86);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 115);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            // 
            // ThreadStart
            // 
            this.ThreadStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadStart.Location = new System.Drawing.Point(3, 3);
            this.ThreadStart.Name = "ThreadStart";
            this.ThreadStart.Size = new System.Drawing.Size(208, 106);
            this.ThreadStart.TabIndex = 6;
            this.ThreadStart.Text = "Запуск\r\nпотоков\r\n";
            this.ThreadStart.UseVisualStyleBackColor = true;
            this.ThreadStart.Click += new System.EventHandler(this.ThreadStart_Click);
            // 
            // ThreadStop
            // 
            this.ThreadStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadStop.Location = new System.Drawing.Point(217, 3);
            this.ThreadStop.Name = "ThreadStop";
            this.ThreadStop.Size = new System.Drawing.Size(220, 106);
            this.ThreadStop.TabIndex = 7;
            this.ThreadStop.Text = "Остановка\r\nпотоков\r\n";
            this.ThreadStop.UseVisualStyleBackColor = true;
            this.ThreadStop.Click += new System.EventHandler(this.ThreadStop_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(2, 219);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(439, 147);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Результат";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 35);
            this.label4.TabIndex = 12;
            this.label4.Text = "смешное поздравление";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(382, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 35);
            this.label3.TabIndex = 11;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 35);
            this.label2.TabIndex = 10;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "*";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ThreadStop);
            this.panel1.Controls.Add(this.ThreadStart);
            this.panel1.Location = new System.Drawing.Point(1, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 112);
            this.panel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox6);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}

