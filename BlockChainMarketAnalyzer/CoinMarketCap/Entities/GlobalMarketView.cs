using Marvellent.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Marvellent.CoinMarketCap
{
    [DataContract]
    public class GlobalMarketView
    {
        private const string _totalMarketCapConvert = "total_market_cap_";
        private const string _Total24hVolumeConvert = "total_24h_volume_";

        [DataMember(Name = "total_market_cap_usd")]
        public string TotalMarketCapUSD { get; set; }
        [DataMember(Name = "total_24h_volume_usd")]
        public string Total24hVolumeUSD { get; set; }
        [DataMember(Name = "bitcoin_percentage_of_market_cap")]
        public string BTCPercentageOfMarketCap { get; set; }
        [DataMember(Name = "active_currencies")]
        public string ActiveCurrencies { get; set; }
        [DataMember(Name = "active_assets")]
        public string ActiveAssets { get; set; }
        [DataMember(Name = "active_markets")]
        public string ActiveMarkets { get; set; }
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }
        [DataMember(Name = "total_market_cap_convert_currency")]
        public string TotalMarketCapConvertCurrency { get; set; }
        [DataMember(Name = "total_24h_volume_convert_currency")]
        public string Total24hVolumeConvertCurrency { get; set; }

        public static GlobalMarketView GetObject(string json, string curSymbol = "")
        {
            GlobalMarketView gmv = null;

            if (!string.IsNullOrEmpty(curSymbol))
            {
                string[] currencySymbols = new string[] { _totalMarketCapConvert + curSymbol.ToLower(), _Total24hVolumeConvert + curSymbol.ToLower() };

                json = json.Replace(currencySymbols[0], "total_market_cap_convert_currency");
                json = json.Replace(currencySymbols[1], "total_24h_volume_convert_currency");
            }
            try
            {
                gmv = SerializeDeserialize<GlobalMarketView>.FromJSONString(json);
                return gmv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
