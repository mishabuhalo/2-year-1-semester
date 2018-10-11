using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using ZedGraph;

namespace Project
{
    public partial class Form1 : Form
    {
        List<List<double>> ListOfAllCurrencies = new List<List<double>>();

        List<string> ListOfNames = new List<string>();
        int tmp = 0;
        public Form1()
        {
            InitializeComponent();
            LoadData();

        }


        public void LoadData()
        {
            List<double> ListOfPrices = new List<double>();
            string url = "https://api.coinmarketcap.com/v2/ticker/?&sort=id";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            CurrencyResponse currencyResponse = JsonConvert.DeserializeObject<CurrencyResponse>(response);

            foreach (string k in currencyResponse.data.Keys)
            {
                dataGridView1.Rows.Add(currencyResponse.data[k].name, "$" + currencyResponse.data[k].quotes.USD.market_cap, "$" + currencyResponse.data[k].quotes.USD.price, "$" + currencyResponse.data[k].quotes.USD.volume_24h, currencyResponse.data[k].circulating_supply + " " + currencyResponse.data[k].symbol, currencyResponse.data[k].quotes.USD.percent_change_24h + '%');
            }

            if (tmp == 0)
            {
                foreach (var k in currencyResponse.data.Keys)
                {
                    ListOfNames.Add(currencyResponse.data[k].name);
                }
                tmp++;
            }


            foreach (var k in currencyResponse.data.Keys)
            {
                ListOfPrices.Add(currencyResponse.data[k].quotes.USD.price);
            }
            ListOfAllCurrencies.Add(ListOfPrices);

            ListOfPrices = null;
        }

 
            

        private void UpdateButtton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
           
            for (int i = 0; i < ListOfNames.Count()-1; i++)
            {
                if (dataGridView1.CurrentCell.Value.ToString() == ListOfNames[i])

                {
                    GraphForm NewForm = new GraphForm(ListOfAllCurrencies, i);
                    NewForm.Show();
                }
                    
            }

        }
    }
}
