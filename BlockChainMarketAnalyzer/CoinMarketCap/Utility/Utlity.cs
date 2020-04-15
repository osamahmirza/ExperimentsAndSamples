using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketCap
{
    public static class Utlity
    {
        public static int? ParseInt(string value)
        {
            int? integer = null;

            if (!string.IsNullOrEmpty(value))
                integer = Int32.Parse(value);

            return integer;
        }

        public static DateTime? ParseUTCWithoutDate(string value)
        {
            DateTime? d = null;

            if (!string.IsNullOrEmpty(value))
            {
                long rawDate = long.Parse(value);
                DateTime? converted = DateTime.FromBinary(rawDate).ToUniversalTime();
                d = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, converted.Value.Hour, converted.Value.Minute, converted.Value.Second);
            }
            return d;
        }

        public static Decimal? ParseDecimal(string value)
        {
            Decimal? dec = null;

            if (!string.IsNullOrEmpty(value))
                dec = Decimal.Parse(value);

            return dec;
        }

        public static  Double? ParseDouble(string value)
        {
            Double? doub = null;

            if (!string.IsNullOrEmpty(value))
                doub = Double.Parse(value);

            return doub;
        }

        public static long? ParseLong(string value)
        {
            long? doub = null;

            if (!string.IsNullOrEmpty(value))
                doub = long.Parse(value);

            return doub;
        }
    }
}
