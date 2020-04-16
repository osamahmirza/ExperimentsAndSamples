using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class CurrencyDataContext
    {

        public static CurrenciesDataContext GetCurrencyDC()
        {
            return new CurrenciesDataContext();
        }

        public static void InsertCurrencyMarketView(List<tblCurrencyMarketView> currencies)
        {

            foreach (var item in currencies)
            {
                using (CurrenciesDataContext dc = new CurrenciesDataContext())
                {
                    dc.tblCurrencyMarketViews.InsertOnSubmit(item);
                    dc.SubmitChanges();
                }
            }

        }
        public static void InsertCurrencyViews(List<tblCurrencyView> curViews)
        {
            foreach (var item in curViews)
            {
                using (CurrenciesDataContext dc = new CurrenciesDataContext())
                {
                    dc.tblCurrencyViews.InsertOnSubmit(item);
                    dc.SubmitChanges();
                }
            }
        }

        public static List<tblCurrencyRankChanged> UpdateCurrencyViewAndCurrencyRankChanged(List<tblCurrencyView> currencies, int restTransactionID)
        {
            List<tblCurrencyRankChanged> changedRanks = new List<tblCurrencyRankChanged>();

            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                var curView = dc.tblCurrencyViews.ToList();

                foreach (var item in currencies)
                {
                    foreach (var dbItem in curView)
                    {
                        if (item.CoinMarkCapID.ToLower() == dbItem.CoinMarkCapID.ToLower())
                        {
                            dbItem.AvailableSupply = item.AvailableSupply;
                            dbItem.CoinMarkCapID = item.CoinMarkCapID;
                            dbItem.Name = item.Name;
                            dbItem.PriceBTC = item.PriceBTC;
                            dbItem.PriceUSD = item.PriceUSD;
                            dbItem.Symbol = item.Symbol;
                            dbItem.TimeStamp = DateTime.Now;
                            dbItem.TotalSupply = item.TotalSupply;
                            dbItem.Volume24hUSD = item.Volume24hUSD;
                            dbItem.PercentageChange1H = item.PercentageChange1H;
                            dbItem.PercentageChange24H = item.PercentageChange24H;
                            dbItem.PercentageChange7D = item.PercentageChange7D;

                            if (dbItem.Rank != item.Rank)
                            {
                                tblCurrencyRankChanged crc =  new tblCurrencyRankChanged
                                                                {
                                                                    CoinMarkCapID = item.CoinMarkCapID,
                                                                    NewRank = item.Rank,
                                                                    OldRank = dbItem.Rank,
                                                                    NewCapUSD = item.MarketCapUSD,
                                                                    OldCapUSD = dbItem.MarketCapUSD,
                                                                    IsRankUp = (item.Rank < dbItem.Rank),
                                                                    IsCapUp = (item.MarketCapUSD > dbItem.MarketCapUSD),
                                                                    TimeStamp = DateTime.Now,
                                                                    TransactionID = restTransactionID
                                                                };
                                //Collecting them just for reference to be returned
                                changedRanks.Add(crc);

                                dc.tblCurrencyRankChangeds.InsertOnSubmit(crc);
                            }
                            dbItem.Rank = item.Rank;
                            dbItem.MarketCapUSD = item.MarketCapUSD;

                            dc.SubmitChanges(); 
                        }
                    }
                }

            }
            return changedRanks;
        }

        public static void UpdateCurrencyViewForDelete(List<string> removed, int restTransactionID)
        {
            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                foreach (var item in removed)
                {
                    var curView = dc.tblCurrencyViews.Where(a => a.CoinMarkCapID == item).ToList().First();
                    curView.DateDeleted = DateTime.Now;
                    curView.DeleteTransactionID = restTransactionID;
                    dc.SubmitChanges();
                }
            }
        }

        public static tblCurrencyView GetCurrencyViewByID(string id)
        {
            tblCurrencyView curView = null;
            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                curView = dc.tblCurrencyViews.Where(a => a.CoinMarkCapID == id).ToList().First();
            }
            return curView;
        }

        public static List<tblCurrencyView> GetCurrencyViews()
        {
            List<tblCurrencyView> curView = null;
            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                curView = dc.tblCurrencyViews.ToList();
            }
            return curView;
        }

        public static List<string> GetUniqueCurrencyIDs()
        {
            List<string> unique = null;
            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                unique = ((from a in dc.tblCurrencyViews
                           select a.CoinMarkCapID).Distinct()).ToList();
            }
            return unique;
        }

        public static void InsertCurrencyRankChanged(List<tblCurrencyRankChanged> ranks)
        {
            foreach (var item in ranks)
            {
                using (CurrenciesDataContext dc = new CurrenciesDataContext())
                {
                    dc.tblCurrencyRankChangeds.InsertOnSubmit(item);
                    dc.SubmitChanges();
                }
            }
        }

        public static void InsertGlobalMarketView(tblGlobalMarketView marketView)
        {
            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                dc.tblGlobalMarketViews.InsertOnSubmit(marketView);
                dc.SubmitChanges();
            }
        }

        public static void InsertTransactionLog(int restTransactionID, bool isSuccess = true)
        {
            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                tblCurrencyTransactionLog log = new tblCurrencyTransactionLog()
                {
                    IsSuccessfull = isSuccess,
                    TimeStamp = DateTime.Now,
                    TransactionID = restTransactionID
                };
                dc.tblCurrencyTransactionLogs.InsertOnSubmit(log);
                dc.SubmitChanges();
            }
        }

        public static void InsertError(Exception ex)
        {
            using (CurrenciesDataContext dc = new CurrenciesDataContext())
            {
                tblError error = new tblError()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };

                dc.tblErrors.InsertOnSubmit(error);
                dc.SubmitChanges();
            }
        }
    }
}
