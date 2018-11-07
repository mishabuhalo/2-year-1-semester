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
    public partial class MainForm : Form
    {
        DataTable currTable;
        DataTable archTable;
        DataSet currSet;
        DataSet archSet;
        List<DataSet> listOfAllTypes = new List<DataSet>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            currSet = new DataSet();
            currTable = new DataTable();
            archTable = new DataTable();
            archSet = new DataSet();

           
            currSet.ReadXml("Current.xml");
            currSet.Tables.Add(currTable);
            
            currTable = currSet.Tables[0];

            archSet.ReadXml("Archive.xml");
            archSet.Tables.Add(archTable);

            archTable = archSet.Tables[0];

            if (currTable.Columns.Count <= 0)
            {
                currTable.Columns.Add("Title", typeof(String));
                currTable.Columns.Add("Message");
            }
            if (archTable.Columns.Count <= 0)
            {
                archTable.Columns.Add("Title", typeof(String));
                archTable.Columns.Add("Message");
            }


            currNotes.DataSource = currTable;

            currNotes.Columns["Message"].Visible = false;
            currNotes.Columns["Title"].Width = 289;
            

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
            currNotes.DataSource = currTable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Any() || txtMessage.Text.Any())
            {
                currTable.Rows.Add(txtTitle.Text, txtMessage.Text);
                txtTitle.Clear();
                txtMessage.Clear();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                txtTitle.Clear();
                txtMessage.Clear();
                int index = currNotes.CurrentCell.RowIndex;
                if (index > -1)
                {
                    if (currNotes.DataSource == currTable)
                    {

                        txtTitle.Text = currTable.Rows[index].ItemArray[0].ToString();
                        txtMessage.Text = currTable.Rows[index].ItemArray[1].ToString();
                    }
                    else
                    {
                        txtTitle.Text = archTable.Rows[index].ItemArray[0].ToString();
                        txtMessage.Text = archTable.Rows[index].ItemArray[1].ToString();
                    }

                }
            }
            catch { }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = currNotes.CurrentCell.RowIndex;
                if (index > -1)
                {
                    if (currNotes.DataSource == currTable)
                    {
                        currTable.Rows[index].Delete();
                    }
                    else
                    {
                        archTable.Rows[index].Delete();
                    }
                    
                }
                txtTitle.Clear();
                txtMessage.Clear();
            }
            catch
            { }
        }

        private void btnAddArchive_Click(object sender, EventArgs e)
        {
            try
            {
                txtTitle.Clear();
                txtMessage.Clear();
                int index = currNotes.CurrentCell.RowIndex;
                if (index > -1)
                {
                    archTable.Rows.Add(currTable.Rows[index].ItemArray[0].ToString(), currTable.Rows[index].ItemArray[1].ToString());
                    currTable.Rows[index].Delete();
                }
            }
            catch { }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
            currNotes.DataSource = archTable;
           
            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
            currNotes.DataSource = currTable;
            currNotes.Columns["Message"].Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            currSet.Tables[0].WriteXml("Current.xml");
            archSet.Tables[0].WriteXml("Archive.xml");
        }
    }
}
