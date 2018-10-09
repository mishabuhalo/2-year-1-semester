using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }

        public void LoadData()
        {
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
                dataGridView1.Rows.Add(currencyResponse.data[k].name, "$" + currencyResponse.data[k].quotes.USD.market_cap, "$"+ currencyResponse.data[k].quotes.USD.price, "$" +currencyResponse.data[k].quotes.USD.volume_24h, currencyResponse.data[k].circulating_supply, currencyResponse.data[k].quotes.USD.percent_change_24h +'%');
            }
        }


    }
}
