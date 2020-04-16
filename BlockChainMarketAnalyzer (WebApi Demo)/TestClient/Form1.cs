using CoinMarketCap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Data;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private System.Timers.Timer timer = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Timer_Elapsed(null, null);
            SetTimer();

           

        }

        private void SetTimer()
        {
            timer = new System.Timers.Timer(60000);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrencyIO currencyIO = new CurrencyIO();
            currencyIO.GetAllCurrenciesAndUpdate();

            GlobalMarketViewIO globalMarketViewIO = new GlobalMarketViewIO();
            globalMarketViewIO.GetGlobalMarketView();
        }
    }
}
