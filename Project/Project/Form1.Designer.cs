namespace Project
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcetCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CirculatingSupply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UpdateButtton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GraphButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.MarcetCap,
            this.Price,
            this.Volume,
            this.CirculatingSupply,
            this.Change});
            this.dataGridView1.Location = new System.Drawing.Point(1, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(983, 424);
            this.dataGridView1.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Name.Width = 200;
            // 
            // MarcetCap
            // 
            this.MarcetCap.HeaderText = "MarcetCap";
            this.MarcetCap.Name = "MarcetCap";
            this.MarcetCap.ReadOnly = true;
            this.MarcetCap.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MarcetCap.Width = 142;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Price.Width = 142;
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume (24h)";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            this.Volume.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Volume.Width = 142;
            // 
            // CirculatingSupply
            // 
            this.CirculatingSupply.HeaderText = "Circulating Supply";
            this.CirculatingSupply.Name = "CirculatingSupply";
            this.CirculatingSupply.ReadOnly = true;
            this.CirculatingSupply.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CirculatingSupply.Width = 172;
            // 
            // Change
            // 
            this.Change.HeaderText = "Change (24h)";
            this.Change.Name = "Change";
            this.Change.ReadOnly = true;
            this.Change.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Change.Width = 142;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateButtton,
            this.toolStripSeparator1,
            this.GraphButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UpdateButtton
            // 
            this.UpdateButtton.Image = global::Project.Properties.Resources.UpdateButton;
            this.UpdateButtton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateButtton.Name = "UpdateButtton";
            this.UpdateButtton.Size = new System.Drawing.Size(91, 22);
            this.UpdateButtton.Text = "Update data";
            //this.UpdateButtton.Click += new System.EventHandler(this.UpdateButtton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // GraphButton
            // 
            this.GraphButton.Image = global::Project.Properties.Resources.GraphButton;
            this.GraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(180, 22);
            this.GraphButton.Text = "Show graph for selected coin";
            this.GraphButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 390);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
           // this.Name = "Form1";
            this.Text = "Coin Market Cap";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcetCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn CirculatingSupply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Change;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton UpdateButtton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton GraphButton;
    }
}

