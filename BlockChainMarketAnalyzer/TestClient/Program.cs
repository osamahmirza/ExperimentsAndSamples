using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}




//class Program
//{
    //    private const string URL = "https://api.coinmarketcap.com/";
    //    //private const string urlParameters = "v1/global/?convert=EUR";
    //    private const string urlParameters = "v1/ticker/?limit=0";

    //string[] supportedCurrencies = { "AUD", "BRL", "CAD", "CHF", "CLP", "CNY", "CZK", "DKK", "EUR", "GBP", "HKD", "HUF", "IDR", "ILS", "INR", "JPY", "KRW", "MXN", "MYR", "NOK", "NZD", "PHP", "PKR", "PLN", "RUB", "SEK", "SGD", "THB", "TRY", "TWD", "ZAR" };

    //static void Main(string[] args)
    //{
        //HttpRequestClient client = new HttpRequestClient();
        //var obj = client.GetGlobalMarketView("cad");
        //var obj = client.GetGlobalMarketView();
        //var obj = client.GetCurrencies();
        

        //HttpClient client = new HttpClient();
        //client.BaseAddress = new Uri(URL);

        //// Add an Accept header for JSON format.
        //client.DefaultRequestHeaders.Accept.Add(
        //new MediaTypeWithQualityHeaderValue("application/json"));

        //// List data response.
        //HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
        //if (response.IsSuccessStatusCode)
        //{
        //    // Parse the response body. Blocking!
        //    var dataObjects = response.Content.ReadAsStringAsync().Result;
        //    var obj = Currency.GetObjects(dataObjects, "eur");
        //    //var obj = GlobalMarketView.GetObject(dataObjects, "eur");
        //    //foreach (var d in dataObjects)
        //    //{
        //    //    Console.WriteLine("{0}", d.Name);
        //    //}
        //}
        //else
        //{
        //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //}

//    }


//}
