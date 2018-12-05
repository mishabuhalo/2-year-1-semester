namespace Lab_3
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.textBoxGainDBValue = new System.Windows.Forms.TextBox();
            this.btnSetGainDB = new System.Windows.Forms.Button();
            this.pictureBoxSpectrum = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarPeakLeft = new System.Windows.Forms.ProgressBar();
            this.progressBarPeakRight = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVisible = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxAlbum = new System.Windows.Forms.TextBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxTrack = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpectrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(297, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select a file to play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(13, 44);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(94, 44);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // textBoxGainDBValue
            // 
            this.textBoxGainDBValue.Location = new System.Drawing.Point(176, 46);
            this.textBoxGainDBValue.Name = "textBoxGainDBValue";
            this.textBoxGainDBValue.Size = new System.Drawing.Size(35, 20);
            this.textBoxGainDBValue.TabIndex = 3;
            this.textBoxGainDBValue.Text = "0";
            this.textBoxGainDBValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSetGainDB
            // 
            this.btnSetGainDB.Location = new System.Drawing.Point(218, 46);
            this.btnSetGainDB.Name = "btnSetGainDB";
            this.btnSetGainDB.Size = new System.Drawing.Size(91, 23);
            this.btnSetGainDB.TabIndex = 4;
            this.btnSetGainDB.Text = "Set Gain (db)";
            this.btnSetGainDB.UseVisualStyleBackColor = true;
            this.btnSetGainDB.Click += new System.EventHandler(this.btnSetGainDB_Click);
            // 
            // pictureBoxSpectrum
            // 
            this.pictureBoxSpectrum.BackColor = System.Drawing.Color.Black;
            this.pictureBoxSpectrum.Location = new System.Drawing.Point(315, 15);
            this.pictureBoxSpectrum.Name = "pictureBoxSpectrum";
            this.pictureBoxSpectrum.Size = new System.Drawing.Size(351, 109);
            this.pictureBoxSpectrum.TabIndex = 5;
            this.pictureBoxSpectrum.TabStop = false;
            this.pictureBoxSpectrum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSpectrum_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "-90db";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "0db";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "+6db";
            // 
            // progressBarPeakLeft
            // 
            this.progressBarPeakLeft.Location = new System.Drawing.Point(24, 91);
            this.progressBarPeakLeft.Maximum = 65535;
            this.progressBarPeakLeft.Name = "progressBarPeakLeft";
            this.progressBarPeakLeft.Size = new System.Drawing.Size(285, 13);
            this.progressBarPeakLeft.TabIndex = 9;
            // 
            // progressBarPeakRight
            // 
            this.progressBarPeakRight.Location = new System.Drawing.Point(24, 111);
            this.progressBarPeakRight.Maximum = 65535;
            this.progressBarPeakRight.Name = "progressBarPeakRight";
            this.progressBarPeakRight.Size = new System.Drawing.Size(285, 13);
            this.progressBarPeakRight.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "L";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "R";
            // 
            // lblVisible
            // 
            this.lblVisible.AutoSize = true;
            this.lblVisible.Location = new System.Drawing.Point(315, 131);
            this.lblVisible.Name = "lblVisible";
            this.lblVisible.Size = new System.Drawing.Size(184, 13);
            this.lblVisible.TabIndex = 13;
            this.lblVisible.Text = "16 of 16 (click L/R mouse to change)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(658, 109);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxArtist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxArtist.Location = new System.Drawing.Point(8, 282);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.Size = new System.Drawing.Size(324, 13);
            this.textBoxArtist.TabIndex = 15;
            this.textBoxArtist.Text = "Artist";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Location = new System.Drawing.Point(8, 301);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(324, 13);
            this.textBoxTitle.TabIndex = 15;
            this.textBoxTitle.Text = "Title";
            // 
            // textBoxAlbum
            // 
            this.textBoxAlbum.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxAlbum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAlbum.Location = new System.Drawing.Point(8, 320);
            this.textBoxAlbum.Name = "textBoxAlbum";
            this.textBoxAlbum.Size = new System.Drawing.Size(324, 13);
            this.textBoxAlbum.TabIndex = 15;
            this.textBoxAlbum.Text = "Album";
            // 
            // textBoxComment
            // 
            this.textBoxComment.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxComment.Location = new System.Drawing.Point(8, 339);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(634, 13);
            this.textBoxComment.TabIndex = 15;
            this.textBoxComment.Text = "Comment";
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxGenre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxGenre.Location = new System.Drawing.Point(343, 281);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(324, 13);
            this.textBoxGenre.TabIndex = 15;
            this.textBoxGenre.Text = "Genre";
            // 
            // textBoxYear
            // 
            this.textBoxYear.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxYear.Location = new System.Drawing.Point(343, 300);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(324, 13);
            this.textBoxYear.TabIndex = 15;
            this.textBoxYear.Text = "Year";
            // 
            // textBoxTrack
            // 
            this.textBoxTrack.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTrack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTrack.Location = new System.Drawing.Point(343, 319);
            this.textBoxTrack.Name = "textBoxTrack";
            this.textBoxTrack.Size = new System.Drawing.Size(324, 13);
            this.textBoxTrack.TabIndex = 15;
            this.textBoxTrack.Text = "Track";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(8, 371);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(658, 72);
            this.textBox1.TabIndex = 16;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(21, 131);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(278, 22);
            this.lblTime.TabIndex = 17;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Audio Files (*.mp3;*.ogg;*.wav)|*.mp3;*.ogg;*.wav";
            this.openFileDialog1.Title = "Select an audio file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 455);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.textBoxAlbum);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxTrack);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.textBoxArtist);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblVisible);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBarPeakRight);
            this.Controls.Add(this.progressBarPeakLeft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxSpectrum);
            this.Controls.Add(this.btnSetGainDB);
            this.Controls.Add(this.textBoxGainDBValue);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simple Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpectrum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox textBoxGainDBValue;
        private System.Windows.Forms.Button btnSetGainDB;
        private System.Windows.Forms.PictureBox pictureBoxSpectrum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBarPeakLeft;
        private System.Windows.Forms.ProgressBar progressBarPeakRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVisible;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxArtist;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxAlbum;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxTrack;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

