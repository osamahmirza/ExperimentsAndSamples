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
    public class CurrencyMarketView
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name="symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "rank")]
        public string Rank { get; set; }
        [DataMember(Name = "price_usd")]
        public string PriceUsd { get; set; }
        [DataMember(Name = "price_btc")]
        public string PriceBtc { get; set; }
        [DataMember(Name = "24h_volume_usd")]
        public string Volume24hUsd { get; set; }
        [DataMember(Name = "market_cap_usd")]
        public string MarketCapUsd { get; set; }
        [DataMember(Name = "available_supply")]
        public string AvailableSupply { get; set; }
        [DataMember(Name = "total_supply")]
        public string TotalSupply { get; set; }
        [DataMember(Name = "percent_change_1h")]
        public string PercentChange1h { get; set; }
        [DataMember(Name= "percent_change_24h")]
        public string PercentChange24h { get; set; }
        [DataMember(Name = "percent_change_7d")]
        public string PercentChange7d { get; set; }
        [DataMember(Name = "last_updated")]
        public string LastUpdated { get; set; }
        [DataMember(Name = "price_convert_currency")]
        public string PriceConvert { get; set; }
        [DataMember(Name = "volume_24_convert_currency")]
        public string Volume24Convert { get; set; }
        [DataMember(Name = "market_cap_convert_currency")]
        public string MarketCapConvert { get; set; }

        private const string _priceConvert = "price_";
        private const string _volume24Convert = "24h_volume_";
        private const string _marketCapConvert = "market_cap_";

        public static List<CurrencyMarketView> GetObjects(string json, string curSymbol = "")
        {
            List<CurrencyMarketView> currencyList = null;
            
            if(!string.IsNullOrEmpty(curSymbol))
            {
                string[] currencySymbols = new string[] { _priceConvert + curSymbol.ToLower(), _volume24Convert + curSymbol.ToLower(), _marketCapConvert + curSymbol.ToLower() };

                json = json.Replace(currencySymbols[0], "price_convert_currency");
                json = json.Replace(currencySymbols[1], "volume_24_convert_currency");
                json = json.Replace(currencySymbols[2], "market_cap_convert_currency");
            }
            
            try
            {
                currencyList = SerializeDeserialize<List<CurrencyMarketView>>.FromJSONString(json);
                return currencyList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
