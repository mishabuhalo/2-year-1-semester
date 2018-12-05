using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab_2
{
    public partial class MultimediaForm : Form
    {
        DataTable multimedia;
        DataSet SaveLinks;

        public MultimediaForm()
        {
             
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog() { Multiselect = true, ValidateNames=true, Filter= "WMV|*.wmv|WAV|*.wav|MP3|*mp3|MP4|*.mp4|MKV|*.mkv|AVI|*.avi"};
            if(openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                multimedia.Rows.Add(openFile.SafeFileName,openFile.FileName);
            }
        }

        private void MultimediaForm_Load(object sender, EventArgs e)
        {
            multimedia = new DataTable();
            SaveLinks = new DataSet();

            if (!File.Exists("Links.xml"))
            {
                System.IO.File.WriteAllText("Links.xml", "<?xml version=\"1.0\" standalone=\"yes\"?>");

            }
            else
            {
                SaveLinks.ReadXml("Links.xml");
            }
            SaveLinks.Tables.Add(multimedia);
            multimedia = SaveLinks.Tables[0];

            multTable.DataSource = multimedia;
            
            if (multimedia.Columns.Count <= 0)
            {
                multimedia.Columns.Add("Name", typeof(String));
                multimedia.Columns.Add("Link", typeof(String));
  
            }
            multTable.Columns["Name"].Width = 309;
            multTable.Columns["Link"].Visible = false;

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int index = multTable.CurrentCell.RowIndex;
            if (index >-1)
            {
                axWindowsMediaPlayer1.URL = multimedia.Rows[index].ItemArray[1].ToString();
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void MultimediaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLinks.WriteXml("Links.xml");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = multTable.CurrentCell.RowIndex;
                if (index > -1)
                {
                    multimedia.Rows[index].Delete();
                }
            }
            catch { }
        }
    }
}
