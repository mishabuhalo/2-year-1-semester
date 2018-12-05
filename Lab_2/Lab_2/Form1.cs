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
using Microsoft.VisualBasic;

namespace Lab_2
{
    public partial class MainForm : Form
    {
        DataTable defaultTable = new DataTable();
        DataSet defaultSet = new DataSet();
        DataSet tmpSet;
        DataSet SetsforSave;
        DataTable tmpTable;
        DataTable archTable;
        DataSet archSet;
        List<DataSet> listOfAllContext = new List<DataSet>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetsforSave = new DataSet();
            defaultSet.Tables.Add(defaultTable);
            listOfAllContext.Add(defaultSet);

            defaultTable = listOfAllContext[0].Tables[0];
            contexBox.Items.Add("General");
            contexBox.SelectedItem = "General";
            


            archTable = new DataTable();
            archSet = new DataSet();


            if (!File.Exists("Archive.xml"))
            {
                System.IO.File.WriteAllText("Archive.xml", "<?xml version=\"1.0\" standalone=\"yes\"?>");

            }
            else
            {
                archSet.ReadXml("Archive.xml");
            }
            archSet.Tables.Add(archTable);
            archTable = archSet.Tables[0];

            if (defaultTable.Columns.Count <= 0)
            {
                defaultTable.Columns.Add("Title", typeof(String));
                defaultTable.Columns.Add("Message");
            }
            if (archTable.Columns.Count <= 0)
            {
                archTable.Columns.Add("Title", typeof(String));
                archTable.Columns.Add("Message");
            }


            currNotes.DataSource = defaultTable;

            currNotes.Columns["Message"].Visible = false;
            currNotes.Columns["Title"].Width = 309;
            

        }
        private void AddStandartColumns(DataTable table)
        {
            if (table.Columns.Count <= 0)
            {
                table.Columns.Add("Title", typeof(String));
                table.Columns.Add("Message");
            }


            currNotes.DataSource = table;

            currNotes.Columns["Message"].Visible = false;
            currNotes.Columns["Title"].Width = 309;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
            currNotes.DataSource = listOfAllContext[GetIndexOfContext()].Tables[0];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Any() || txtMessage.Text.Any())
            {
                listOfAllContext[GetIndexOfContext()].Tables[0].Rows.Add(txtTitle.Text, txtMessage.Text);
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
                    if (currNotes.DataSource == listOfAllContext[GetIndexOfContext()].Tables[0])
                    {

                        txtTitle.Text = listOfAllContext[GetIndexOfContext()].Tables[0].Rows[index].ItemArray[0].ToString();
                        txtMessage.Text = listOfAllContext[GetIndexOfContext()].Tables[0].Rows[index].ItemArray[1].ToString();
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
                    if (currNotes.DataSource == listOfAllContext[GetIndexOfContext()].Tables[0])
                    {
                        listOfAllContext[GetIndexOfContext()].Tables[0].Rows[index].Delete();
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
                    archTable.Rows.Add(listOfAllContext[GetIndexOfContext()].Tables[0].Rows[index].ItemArray[0].ToString(), listOfAllContext[GetIndexOfContext()].Tables[0].Rows[index].ItemArray[1].ToString());
                    listOfAllContext[GetIndexOfContext()].Tables[0].Rows[index].Delete();
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

    

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            archSet.WriteXml("Archive.xml");
          /*  for (int i = 0; i < listOfAllContext.Count(); i++)
            {
                SetsforSave.Tables.Add(listOfAllContext[i].Tables[0]);
            }
            SetsforSave.WriteXml("Current.xml");*/
        }

        private void btnAddContext_Click(object sender, EventArgs e)
        {
            string contex;
            tmpSet = new DataSet();
            tmpTable = new DataTable();
            tmpSet.Tables.Add(tmpTable);
            contex = Interaction.InputBox("Enter name of nev context group: ", "New context");
            contexBox.Items.Add(contex);
            listOfAllContext.Add(tmpSet);
            AddStandartColumns(tmpTable);
        }

        private int GetIndexOfContext()
        {
            return contexBox.SelectedIndex;
        }

        private void contexBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currNotes.DataSource = listOfAllContext[GetIndexOfContext()].Tables[0];
        }

        private void btnDeleteContex_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetIndexOfContext() != 0)
                {
                    contexBox.Items.RemoveAt(GetIndexOfContext());
                    listOfAllContext.RemoveAt(GetIndexOfContext());
                }
            }
            catch
            { }
        }

        MultimediaForm NewForm;
        private void showMulti_Click(object sender, EventArgs e)
        {
            if (NewForm == null || NewForm.IsDisposed)
            {
                NewForm = new MultimediaForm();
                NewForm.Show();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                btnNew_Click(new object(), new EventArgs());
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave_Click(new object(), new EventArgs());
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                txtMessage.Text = Clipboard.GetText();
            }
        }
    }
}
