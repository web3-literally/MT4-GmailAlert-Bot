using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtApi;
using MtApi.Monitors;

namespace GmailRead
{
    class CandleStick
    {
        public double Low { get; set; }
        public double High { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }
    class MT4Controller
    {
        public event apiClient_ConnectionEvent evtApiClientState;
        private readonly MtApiClient _apiClient = new MtApiClient();
        private bool m_bConnected = false;
        public MT4Controller()
        {
            _apiClient.ConnectionStateChanged += apiClient_ConnectionStateChanged;
        }

        private void apiClient_ConnectionStateChanged(object sender, MtConnectionEventArgs e)
        {
            switch (e.Status)
            {
                case MtConnectionState.Connected:
                    m_bConnected = true;
                    evtApiClientState(true);
                    break;
                case MtConnectionState.Disconnected:
                    m_bConnected = false;
                    evtApiClientState(false);
                    break;
                case MtConnectionState.Failed:
                    m_bConnected = false;
                    evtApiClientState(false);
                    break;
            }
        }

        public void Connect(int nPort)
        {
            _apiClient.BeginConnect(nPort);
        }

        public void Disconnect()
        {
            _apiClient.BeginDisconnect();
        }

        public bool IsConnected()
        {
            return m_bConnected;
        }
        public CandleStick GetLastCandleStick(string strSymbol, string strPeriod)
        {
            ChartPeriod TimeFrame = ChartPeriod.PERIOD_D1;
            switch (strPeriod)
            {
                case "1M":
                    TimeFrame = ChartPeriod.PERIOD_M1;
                    break;
                case "5M":
                    TimeFrame = ChartPeriod.PERIOD_M5;
                    break;
                case "15M":
                    TimeFrame = ChartPeriod.PERIOD_M15;
                    break;
                case "30M":
                    TimeFrame = ChartPeriod.PERIOD_M30;
                    break;
                case "1H":
                    TimeFrame = ChartPeriod.PERIOD_H1;
                    break;
                case "4H":
                    TimeFrame = ChartPeriod.PERIOD_H4;
                    break;
                case "1D":
                    TimeFrame = ChartPeriod.PERIOD_D1;
                    break;
                case "1W":
                    TimeFrame = ChartPeriod.PERIOD_W1;
                    break;
                case "MN":
                    TimeFrame = ChartPeriod.PERIOD_MN1;
                    break;
            }
            
            CandleStick stick = new CandleStick();
            stick.Low = _apiClient.iLow(strSymbol, TimeFrame, 1);
            stick.High = _apiClient.iHigh(strSymbol, TimeFrame, 1);
            stick.Open = _apiClient.iOpen(strSymbol, TimeFrame, 1);
            stick.Close = _apiClient.iClose(strSymbol, TimeFrame, 1);
            return stick;
        }

        public void SendOrder(string strSymbol, string strOpertion, double dVolumn, double dPrice, DateTime expireTime, double dTakeProfit = 0, double dStopLoss = 0, int nSlippage = 20, int Magic = 0)
        {
            if (strOpertion == "BUY")
            {
                double current_price = _apiClient.SymbolInfoDouble(strSymbol, EnumSymbolInfoDouble.SYMBOL_BID);
                if (current_price > dPrice) current_price = dPrice;

                _apiClient.OrderSend(strSymbol, TradeOperation.OP_BUYLIMIT, dVolumn, current_price, nSlippage, dStopLoss, dTakeProfit, null, Magic, expireTime);
            }
            else if (strOpertion == "SELL")
            {
                double current_price = _apiClient.SymbolInfoDouble(strSymbol, EnumSymbolInfoDouble.SYMBOL_ASK);
                if (current_price < dPrice) current_price = dPrice;

                _apiClient.OrderSend(strSymbol, TradeOperation.OP_SELLLIMIT, dVolumn, current_price, nSlippage, dStopLoss, dTakeProfit, null, Magic, expireTime);
            }
        }

        public DateTime GetCurrentMT4Time()
        {
            return _apiClient.TimeCurrent();
        }

        public double GetAskPrice(string strSymbol)
        {
            return _apiClient.SymbolInfoDouble(strSymbol, EnumSymbolInfoDouble.SYMBOL_ASK);
        }
        public double GetBidPrice(string strSymbol)
        {
            return _apiClient.SymbolInfoDouble(strSymbol, EnumSymbolInfoDouble.SYMBOL_BID);
        }
    }
}
