using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Marvellent.CoinMarketCap
{
    public class HttpRequestClient
    {
        private const string Url = "http://api.coinmarketcap.com";

        private const string Path_BaseTicker = "/v1/ticker/";
        private const string Path_BaseGlobal = "/v1/global/";
        private const string Path_Ticker_ID = "/v1/ticker/{0}/";

        private const string OPR_Limit = "?limit={0}";
        private const string OPR_Start_Limit = "?start={0}&limit={1}";
        private const string OPR_Symbol_Limit = "?convert={0}&limit={1}";
        private const string OPR_Symbol = "?convert={0}";
        private const string CONST_NEGONE = "-1";

        public GlobalMarketView GetGlobalMarketView(string symbol = "")
        {
            string url = GetUrl(Path_BaseGlobal);
            string convert = string.Empty;

            if (!string.IsNullOrEmpty(symbol))
                convert = string.Format(OPR_Symbol, symbol);

            var dataObj = CallService(url, convert);
            
            if (dataObj != null)
            {
                var obj = GlobalMarketView.GetObject(dataObj, symbol);
                return obj;
            }
            else
            {
                return null;
            }
        }
       
        /// <summary>
        /// To get all the currencies or some currencies
        /// </summary>
        /// <param name="count">Number of currencies to return, use -1 to get all currencies</param>
        /// <returns></returns>
        
        public List<CurrencyMarketView> GetCurrencies(int count = -1)
        {
            string url = GetUrl(Path_BaseTicker);

            var dataObj = CallService(url, string.Format(OPR_Limit, count.ToString()));

            return DeserializeJason(dataObj);
        }
        
        public List<CurrencyMarketView> GetCurrenciesFromRank(int startRank, int count = -1)
        {
            string url = GetUrl(Path_BaseTicker);

            var dataObj = CallService(url, string.Format(OPR_Start_Limit, startRank.ToString(), count.ToString()));

            return DeserializeJason(dataObj);
        }

        public List<CurrencyMarketView> GetCurrenciesForFiat(FiatEnum fiat , int count = -1)
        {
            string url = GetUrl(Path_BaseTicker);

            var dataObj = CallService(url, string.Format(OPR_Symbol_Limit, fiat.ToString(), count.ToString()));

            return DeserializeJason(dataObj);
        }

        public List<CurrencyMarketView> GetCurrenciesForCryptoID(string cryptoID)
        {
            string url = GetUrl(Path_BaseTicker);

            var dataObj = CallService(url, string.Format(Path_Ticker_ID, cryptoID));

            return DeserializeJason(dataObj);
        }

        public List<CurrencyMarketView> GetCurrenciesForCryptoIDAndFiat(FiatEnum fiat, string cryptoID)
        {
            string url = GetUrl(Path_BaseTicker);

            var dataObj = CallService(url, (string.Format(Path_Ticker_ID, cryptoID) + string.Format(OPR_Symbol, fiat.ToString())));

            return DeserializeJason(dataObj);
        }
        
        #region Service Call

        private string CallService(string url, string urlParameters = "")
        {
            HttpClient client = new HttpClient();
            //accepts url in form of http://api.coinmarketcap.com/v1/ticker/
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response. urlParameters in form of ?start=15&limit=100
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                return dataObjects;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Utility Methods

        private static string GetUrl(string path)
        {
            return Url + path;
        }


        private static List<CurrencyMarketView> DeserializeJason(string json)
        {
            if (json != null)
            {
                var obj = CurrencyMarketView.GetObjects(json);
                return obj;
            }
            else
            {
                return null;
            }
        } 

        #endregion

    }
}
