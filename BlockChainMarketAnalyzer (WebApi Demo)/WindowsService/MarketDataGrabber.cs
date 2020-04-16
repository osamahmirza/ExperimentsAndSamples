using CoinMarketCap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace WindowsService1
{
    // use following command to install
    // C:\Windows\Microsoft.NET\Framework\v4.0.30319>installutil.exe "F:\Research Projects\Blockchain\Market Analyzer\MarketAnalyzer\WindowsService1\bin\Release\MarketAnalyzer.exe"

    public partial class MarketDataGrabber : ServiceBase
    {
        private Timer _Timer = null;

        public MarketDataGrabber()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            TimeSpan tsInterval = new TimeSpan(0, 0, 60);
            _Timer = new System.Threading.Timer(new System.Threading.TimerCallback(IntervalTimer_Elapsed), null, tsInterval, tsInterval);
        }

        private void DoWork()
        {
            CurrencyIO currencyIO = new CurrencyIO();
            currencyIO.GetAllCurrenciesAndUpdate();

            GlobalMarketViewIO marketViewIO = new GlobalMarketViewIO();
            marketViewIO.GetGlobalMarketView();
        }

        private void IntervalTimer_Elapsed(object state)
        {
            DoWork();
        }

        protected override void OnStop()
        {
            _Timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            _Timer.Dispose();
            _Timer = null;
        }
    }
}
