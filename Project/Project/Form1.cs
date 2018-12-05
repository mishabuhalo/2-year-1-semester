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
using System.Timers;
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
            int num = 0;
            TimerCallback tm = new TimerCallback(upd);
            System.Threading.Timer timer = new System.Threading.Timer(tm, num, 60000, 60000);
            List<double> ListOfPrices = new List<double>();
            string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?CMC_PRO_API_KEY=72704fa6-f50b-43f7-8164-98ccc03040cd";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            CurrencyResponse currencyResponse = JsonConvert.DeserializeObject<CurrencyResponse>(response);

            for (int k = 0; k < currencyResponse.data.Count(); k++)
            {
                dataGridView1.Rows.Add(currencyResponse.data[k].name, "$" + currencyResponse.data[k].quote.USD.market_cap, "$" + currencyResponse.data[k].quote.USD.price, "$" + currencyResponse.data[k].quote.USD.volume_24h, currencyResponse.data[k].circulating_supply + " " + currencyResponse.data[k].symbol, currencyResponse.data[k].quote.USD.percent_change_24h + '%');
            }
            

            if (tmp == 0)   
            {
                for (int k = 0; k < currencyResponse.data.Count(); k++)
                {
                    ListOfNames.Add(currencyResponse.data[k].name);
                }
                tmp++;
            }


            for (int k = 0; k < currencyResponse.data.Count(); k++)
            {
                ListOfPrices.Add(currencyResponse.data[k].quote.USD.price);
            }
            ListOfAllCurrencies.Add(ListOfPrices);

            ListOfPrices = null;
        }

            
        public void upd (object obj)
        {
            UpdateButtton_Click(new object(), new EventArgs());
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
