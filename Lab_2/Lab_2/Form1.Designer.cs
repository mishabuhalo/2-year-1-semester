namespace Lab_2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.currNotes = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddArchive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddContext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteContex = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.showMulti = new System.Windows.Forms.ToolStripButton();
            this.contexBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.currNotes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(59, 33);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(222, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(59, 84);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(222, 207);
            this.txtMessage.TabIndex = 2;
            // 
            // currNotes
            // 
            this.currNotes.AllowUserToAddRows = false;
            this.currNotes.AllowUserToDeleteRows = false;
            this.currNotes.AllowUserToResizeColumns = false;
            this.currNotes.AllowUserToResizeRows = false;
            this.currNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currNotes.Location = new System.Drawing.Point(366, 84);
            this.currNotes.Name = "currNotes";
            this.currNotes.ReadOnly = true;
            this.currNotes.RowHeadersVisible = false;
            this.currNotes.Size = new System.Drawing.Size(312, 207);
            this.currNotes.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.toolStripSeparator1,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnOpen,
            this.toolStripSeparator3,
            this.btnDelete,
            this.toolStripSeparator4,
            this.btnAddArchive,
            this.toolStripSeparator5,
            this.btnShow,
            this.toolStripSeparator6,
            this.btnAddContext,
            this.toolStripSeparator8,
            this.btnDeleteContex,
            this.toolStripSeparator7,
            this.showMulti});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(737, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(35, 22);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(40, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddArchive
            // 
            this.btnAddArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddArchive.Image = ((System.Drawing.Image)(resources.GetObject("btnAddArchive.Image")));
            this.btnAddArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddArchive.Name = "btnAddArchive";
            this.btnAddArchive.Size = new System.Drawing.Size(88, 22);
            this.btnAddArchive.Text = "Add to archive";
            this.btnAddArchive.Click += new System.EventHandler(this.btnAddArchive_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnShow
            // 
            this.btnShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(83, 22);
            this.btnShow.Text = "Show Archive";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddContext
            // 
            this.btnAddContext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddContext.Image = ((System.Drawing.Image)(resources.GetObject("btnAddContext.Image")));
            this.btnAddContext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddContext.Name = "btnAddContext";
            this.btnAddContext.Size = new System.Drawing.Size(104, 22);
            this.btnAddContext.Text = "Add New Context";
            this.btnAddContext.Click += new System.EventHandler(this.btnAddContext_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteContex
            // 
            this.btnDeleteContex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeleteContex.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteContex.Image")));
            this.btnDeleteContex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteContex.Name = "btnDeleteContex";
            this.btnDeleteContex.Size = new System.Drawing.Size(88, 22);
            this.btnDeleteContex.Text = "Delete Context";
            this.btnDeleteContex.Click += new System.EventHandler(this.btnDeleteContex_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // showMulti
            // 
            this.showMulti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showMulti.Image = ((System.Drawing.Image)(resources.GetObject("showMulti.Image")));
            this.showMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showMulti.Name = "showMulti";
            this.showMulti.Size = new System.Drawing.Size(135, 22);
            this.showMulti.Text = "Show multimedia Form";
            this.showMulti.ToolTipText = "Show multimedia Form";
            this.showMulti.Click += new System.EventHandler(this.showMulti_Click);
            // 
            // contexBox
            // 
            this.contexBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contexBox.FormattingEnabled = true;
            this.contexBox.Location = new System.Drawing.Point(388, 33);
            this.contexBox.Name = "contexBox";
            this.contexBox.Size = new System.Drawing.Size(222, 21);
            this.contexBox.TabIndex = 5;
            this.contexBox.SelectedIndexChanged += new System.EventHandler(this.contexBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 312);
            this.Controls.Add(this.contexBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.currNotes);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Notes Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.currNotes)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.DataGridView currNotes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnAddArchive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ComboBox contexBox;
        private System.Windows.Forms.ToolStripButton btnAddContext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnDeleteContex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton showMulti;
    }
}

