namespace WindowsFormsApp
{
    partial class LogViewerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.TreeCollectionView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.ForeColor = System.Drawing.Color.White;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(1121, 349);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(0, 349);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1121, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TreeCollectionView
            // 
            this.TreeCollectionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeCollectionView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeCollectionView.Location = new System.Drawing.Point(0, 0);
            this.TreeCollectionView.Name = "TreeCollectionView";
            this.TreeCollectionView.Size = new System.Drawing.Size(1121, 349);
            this.TreeCollectionView.TabIndex = 2;
            this.TreeCollectionView.Visible = false;
            // 
            // LogViewerForm
            // 
            this.ClientSize = new System.Drawing.Size(1121, 372);
            this.Controls.Add(this.TreeCollectionView);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnClose);
            this.Name = "LogViewerForm";
            this.Text = "Просмотр журнала";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TreeView TreeCollectionView;
    }
}