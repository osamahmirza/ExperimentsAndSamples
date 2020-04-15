using Data;
using Marvellent.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCap
{
    public class GlobalMarketViewIO
    {
        public void GetGlobalMarketView()
        {
            HttpRequestClient client = new HttpRequestClient();
            var obj = client.GetGlobalMarketView();

            tblGlobalMarketView gmv = new tblGlobalMarketView();

            Guid guid = Guid.NewGuid();

            gmv = new tblGlobalMarketView()
            {
                ID = guid,
                ActiveAssets = Utlity.ParseInt(obj.ActiveAssets),
                ActiveCurrencies = Utlity.ParseInt(obj.ActiveCurrencies),
                ActiveMarkets = Utlity.ParseInt(obj.ActiveMarkets),
                BTCPercentageofMarketCap = Utlity.ParseDouble(obj.BTCPercentageOfMarketCap),
                LastUpdated = obj.LastUpdated,
                TimeStamp = DateTime.Now,
                Total24HVolumeConvertCurrency = Utlity.ParseDecimal(obj.Total24hVolumeConvertCurrency),
                Total24HVolumeUSD = Utlity.ParseDecimal(obj.Total24hVolumeUSD),
                TotalMarketCapConvertCurrency = Utlity.ParseDecimal(obj.TotalMarketCapConvertCurrency),
                TotalMarketCapUSD = Utlity.ParseDecimal(obj.TotalMarketCapUSD),
                TransactionID = guid.ToString().GetHashCode()
            };

            CurrencyDataContext.InsertGlobalMarketView(gmv);
        }
    }
}
