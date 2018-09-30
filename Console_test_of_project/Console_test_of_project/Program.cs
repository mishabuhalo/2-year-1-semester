using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web;
namespace Console_test_of_project
{
    class Program
    {
        static void Main(string[] args)
        {

            string url = "https://api.coinmarketcap.com/v2/ticker/?&sort=id";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

             CurrencyResponse  currencyResponse =  JsonConvert.DeserializeObject<CurrencyResponse>(response);

            foreach (var k in currencyResponse.data.Keys)
            {
                    Console.WriteLine("Price of {0} : {1} usd", currencyResponse.data[k].name, currencyResponse.data[k].quotes.USD.price);

            }


            Console.WriteLine("It is End");
            Console.ReadLine();
        }
    }
}
