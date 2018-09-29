using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace Console_test_of_project
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 224; i++)
            {
                string url = "https://api.coinmarketcap.com/v2/ticker/" + i + "//";

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                try
                {
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    string response;

                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        response = streamReader.ReadToEnd();
                    }
                    CurrencyResponse currencyResponse = JsonConvert.DeserializeObject<CurrencyResponse>(response);
                    Console.WriteLine("Price of {0} : {1} usd", currencyResponse.data.name, currencyResponse.data.quotes.USD.price);
                }
                catch
                {
                    continue;
                }

            }

            Console.WriteLine("It is End");
            Console.ReadLine();
        }
    }
}
