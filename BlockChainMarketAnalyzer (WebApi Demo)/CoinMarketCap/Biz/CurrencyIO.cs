using Data;
using Marvellent.CoinMarketCap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCap
{
    public class CurrencyIO
    {
        public void GetAllCurrenciesAndUpdate()
        {

            //For each JSON call there will be transaction ID associated with it
            var restTransactionID = Guid.NewGuid().GetHashCode();
            try
            {
                HttpRequestClient client = new HttpRequestClient();
                var freshCurrencies = client.GetCurrencies();

                tblCurrencyMarketView cur = null;
                List<tblCurrencyMarketView> curFreshList = new List<tblCurrencyMarketView>();
                List<tblCurrencyRankChanged> ranksChanged = new List<tblCurrencyRankChanged>();
                List<tblCurrencyView> newlyAdded = new List<tblCurrencyView>();

                foreach (var item in freshCurrencies)
                {
                    cur = new tblCurrencyMarketView()
                    {
                        ID = Guid.NewGuid(),
                        CoinMarkCapID = item.Id,
                        AvailableSupply = Utlity.ParseDecimal(item.AvailableSupply),
                        LastUpdatedUTC = item.LastUpdated,
                        MarketCapConvert = Utlity.ParseDecimal(item.MarketCapConvert),
                        MarketCapUSD = Utlity.ParseDecimal(item.MarketCapUsd),
                        Name = item.Name,
                        PercentageChange1H = Utlity.ParseDouble(item.PercentChange1h),
                        PercentageChange24H = Utlity.ParseDouble(item.PercentChange24h),
                        PercentageChange7D = Utlity.ParseDouble(item.PercentChange7d),
                        PriceBTC = Utlity.ParseDecimal(item.PriceBtc),
                        PriceConvert = Utlity.ParseDecimal(item.PriceConvert),
                        PriceUSD = Utlity.ParseDecimal(item.PriceUsd),
                        Rank = Utlity.ParseInt(item.Rank),
                        Symbol = item.Symbol,
                        TotalSupply = Utlity.ParseDecimal(item.TotalSupply),
                        Volume24hUSD = Utlity.ParseDecimal(item.Volume24hUsd),
                        Volumne24HConvert = Utlity.ParseDecimal(item.Volume24Convert),
                        TimeStamp = DateTime.Now,
                        TransactionID = restTransactionID
                    };
                    curFreshList.Add(cur);
                }


                //Add Fresh Currencies, which are going to be just 1 or 2 at a time
                var addRemovePairs = FindNewCurrencies(curFreshList, restTransactionID);
                if (addRemovePairs.Added != null && addRemovePairs.Added.Count > 0)
                {
                    newlyAdded = BuildNewCurrencyList(curFreshList, addRemovePairs.Added, restTransactionID);
                    CurrencyDataContext.InsertCurrencyViews(newlyAdded);
                }

                if (addRemovePairs.Removed != null && addRemovePairs.Removed.Count > 0)
                {
                    CurrencyDataContext.UpdateCurrencyViewForDelete(addRemovePairs.Removed, restTransactionID);
                }

                //Get those currency views which need to be updated in DB (New ones)
                var updateCurView = GetCurrencyViewToUpdate(curFreshList, newlyAdded);

                //The update the old currency views and report rank change
                if (updateCurView != null && updateCurView.Count > 0)
                    ranksChanged = CurrencyDataContext.UpdateCurrencyViewAndCurrencyRankChanged(updateCurView, restTransactionID);

                CurrencyDataContext.InsertCurrencyMarketView(curFreshList);

                CurrencyDataContext.InsertTransactionLog(restTransactionID);
            }
            catch (Exception ex)
            {
                CurrencyDataContext.InsertTransactionLog(restTransactionID, false);
                ErrorLogging.LogError(ex);
            }
        }

        private static List<tblCurrencyView> BuildNewCurrencyList(List<tblCurrencyMarketView> curFreshList, List<string> added, int transactionID)
        {
            List<tblCurrencyView> newCurrencies = new List<tblCurrencyView>();

            foreach (var newOne in added)
            {
                foreach (var webItem in curFreshList)
                {
                    if (webItem.CoinMarkCapID.ToLower() == newOne.ToLower())
                    {
                        newCurrencies.Add(new tblCurrencyView
                        {
                            AvailableSupply = webItem.AvailableSupply,
                            CoinMarkCapID = webItem.CoinMarkCapID,
                            MarketCapUSD = webItem.MarketCapUSD,
                            Name = webItem.Name,
                            PriceBTC = webItem.PriceBTC,
                            PriceUSD = webItem.PriceUSD,
                            Rank = webItem.Rank,
                            Symbol = webItem.Symbol,
                            TotalSupply = webItem.TotalSupply,
                            DateAdded = DateTime.Now,
                            TimeStamp = DateTime.Now,
                            TransactionID = transactionID
                        });
                        break;
                    }
                }
            }
            return newCurrencies;
        }

        private List<tblCurrencyView> GetCurrencyViewToUpdate(List<tblCurrencyMarketView> curFreshList, List<tblCurrencyView> newlyAdded)
        {
            List<tblCurrencyView> curView = new List<tblCurrencyView>();

            foreach (var item in curFreshList)
            {
                curView.Add(new tblCurrencyView
                {
                    AvailableSupply = item.AvailableSupply,
                    CoinMarkCapID = item.CoinMarkCapID,
                    MarketCapUSD = item.MarketCapUSD,
                    Name = item.Name,
                    PriceBTC = item.PriceBTC,
                    PriceUSD = item.PriceUSD,
                    Rank = item.Rank,
                    Symbol = item.Symbol,
                    TimeStamp = DateTime.Now,
                    TotalSupply = item.TotalSupply,
                    LastUpdatedUTC = Utlity.ParseLong(item.LastUpdatedUTC),
                    PercentageChange1H = item.PercentageChange1H,
                    PercentageChange24H = item.PercentageChange24H,
                    PercentageChange7D = item.PercentageChange7D,
                    Volume24hUSD = item.Volume24hUSD,

                });
            }

            if (newlyAdded != null && newlyAdded.Count > 0)
            {
                foreach (var item in newlyAdded)
                {
                    foreach (var newItem in curView)
                    {
                        if (item.CoinMarkCapID.ToLower() == newItem.CoinMarkCapID.ToLower())
                        {
                            curView.Remove(newItem);
                            break;
                        }
                    }
                }
            }

            return curView;
        }

        private static CurrencyAddRemove FindNewCurrencies(List<tblCurrencyMarketView> freshCurrencies, int transactionID)
        {
            List<string> newlyAdded = new List<string>();
            List<string> newlyDeleted = new List<string>();

            CurrencyAddRemove pairs = new CurrencyAddRemove();

            var uniqueFromDB = CurrencyDataContext.GetUniqueCurrencyIDs();

            var uniqueFromWeb = ((from a in freshCurrencies
                                  select a.CoinMarkCapID).Distinct()).ToList();

            newlyAdded = GetNewlyAdded(uniqueFromDB, uniqueFromWeb);

            newlyDeleted = GetNewlyDeleted(uniqueFromDB, uniqueFromWeb);

            pairs.Added = newlyAdded;
            pairs.Removed = newlyDeleted;


            return pairs;
        }

        private static List<string> GetNewlyAdded(List<string> uniqueFromDB, List<string> uniqueFromWeb)
        {
            var result = uniqueFromWeb.Where(p => !uniqueFromDB.Any(l => p == l)).ToList();
            return result;
        }

        private static List<string> GetNewlyDeleted(List<string> uniqueFromDB, List<string> uniqueFromWeb)
        {
            var result = uniqueFromDB.Where(p => !uniqueFromWeb.Any(l => p == l)).ToList();
            return result;
        }
    }
}
