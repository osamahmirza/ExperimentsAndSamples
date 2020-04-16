using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCap
{
    public class ErrorLogging
    {
        
        public static void LogError(Exception ex)
        {

            // Logging error in seperate thread
            Task err = Task.Run(() => CurrencyDataContext.InsertError(ex));

        }
    }
}
