using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GmailRead
{
    delegate void apiClient_ConnectionEvent(bool bConnection);
    public partial class MainWnd : Form
    {
        Dictionary<string, int> m_Dic = new Dictionary<string, int>();
        private XLSReader m_XLSReader = new XLSReader();
        private MT4Controller m_MT4Controller = new MT4Controller();
        private GmailReader m_GmailReader = new GmailReader();
        public MainWnd()
        {
            InitializeComponent();
            m_MT4Controller.evtApiClientState += OnChangeMT4Connection;
        }

        private void m_btnStart_Click(object sender, EventArgs e)
        {
            int nPort = (int)m_numEAPort.Value;
            if (nPort == 0)
            {
                MessageBox.Show("Please Input Port Again!");
                return;
            }
            m_GmailReader.m_strGmail = m_txtGmail.Text;
            m_GmailReader.m_strPassword = m_txtPassword.Text;
            m_MT4Controller.Connect(nPort);
            m_Timer.Enabled = true;
            m_btnStart.Enabled = false;
            m_btnXlsOpen.Enabled = false;
        }
        private void RunOnUiThread(Action action)
        {
            if (!IsDisposed)
            {
                BeginInvoke(action);
            }
        }

        private void Log(string strLog)
        {
            RunOnUiThread(() => {
                m_txtlogs.AppendText("\n" + strLog + "\n");
            });
        }

        private void m_btnClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void m_btnXlsOpen_Click(object sender, EventArgs e)
        {
            if(m_OpenXLSDialog.ShowDialog() == DialogResult.OK)
            {
                string strXlsPath = m_OpenXLSDialog.FileName;
                m_txtXlsFilePath.Text = strXlsPath;
                if ( m_XLSReader.OpenXLSFile(strXlsPath) )
                {
                    m_btnStart.Enabled = true;
                    Log("========= XLS File Opened Successfully! ==========");
                }
                else
                {
                    MessageBox.Show("Error Happend When XLS Open!", "File Open Error!");
                    m_btnStart.Enabled = false;
                }
            }
        }
        
        private void m_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                TitleCommand Command = m_GmailReader.ReadGmail();
                if (Command == null) return;
                if (!m_Dic.ContainsKey(Command.OriginTitle))
                {
                    m_Dic.Add(Command.OriginTitle, 1);
                }
                else
                {
                    m_Dic[Command.OriginTitle]++;
                }

                string strLog = "================= EMAIL RECEIVED! =================\n";
                strLog += "Title : " + Command.OriginTitle + 
                    "\nCount: " + m_Dic[Command.OriginTitle].ToString();
                Log(strLog);

                ShowEmailTitleCount();

                for (int i = 0; i < 3; i++)
                {
                    OrderParameter Param = m_XLSReader.ReadOrderParameters(Command.OriginTitle, m_Dic[Command.OriginTitle], i);
                    if (Param == null)
                    {
                        Log("################## Can't Search Information in Xls File! #####################");
                        return;
                    }

                    strLog = "====================== INFORMATION FROM XLS FILE! ==========================\n";
                    strLog += "Price: " + Param.strPrice +
                        "\nLot: " + Param.dLot.ToString() +
                        "\nStopLoss: " + Param.dStopLoss.ToString() +
                        "\nTakeProfit: " + Param.dTakeProfit.ToString() +
                        "\nX: " + Param.dX.ToString() +
                        "\nExpireTime: " + Param.expireTime.ToString();
                    Log(strLog);

                    CandleStick Stick = m_MT4Controller.GetLastCandleStick(Command.Symbol, Command.Period);
                    if (Stick == null)
                    {
                        return;
                    }

                    strLog = "=================== LASTEST CANDLE VALUES =====================\n";
                    strLog += "Low: " + Stick.Low.ToString() +
                        "\nHigh: " + Stick.High.ToString() +
                        "\nOpen: " + Stick.Open.ToString() +
                        "\nClose: " + Stick.Close.ToString();
                    Log(strLog);

                    double dPrice = 0;
                    double dTakeProfit = 0;
                    double dStopLoss = 0;
                    if (Param.strPrice == "Low")
                    {
                        dPrice = Stick.Low;
                    }
                    if (Param.strPrice == "High")
                    {
                        dPrice = Stick.High;
                    }
                    if (Param.strPrice == "Open")
                    {
                        dPrice = Stick.Open;
                    }
                    if (Param.strPrice == "Close")
                    {
                        dPrice = Stick.Close;
                    }

                    dPrice += Param.dX;

                    if (Command.Operation == "BUY")
                    {
                        dTakeProfit = dPrice + Param.dTakeProfit;
                        dStopLoss = dPrice - Param.dStopLoss;
                    }
                    else if (Command.Operation == "SELL")
                    {
                        dTakeProfit = dPrice - Param.dTakeProfit;
                        dStopLoss = dPrice + Param.dStopLoss;
                    }

                    DateTime expireTime = m_MT4Controller.GetCurrentMT4Time();
                    expireTime = expireTime.AddHours(Param.expireTime);

                    strLog = "=================== ORDER PARAMETERS =====================\n";
                    strLog += "Symbol: " + Command.Symbol +
                        "\nOperation: " + Command.Operation +
                        "\nLot: " + Param.dLot.ToString() +
                        "\nPrice: " + dPrice.ToString() +
                        "\nExpireTime: " + expireTime.ToString() +
                        "\nTakeProfit: " + dTakeProfit.ToString() +
                        "\nStopLoss: " + dStopLoss.ToString() +
                        "\nSlippage: 20" + 
                        "\nAskPrice: " + m_MT4Controller.GetAskPrice(Command.Symbol).ToString() + 
                        "\nBidPrice: " + m_MT4Controller.GetBidPrice(Command.Symbol).ToString();
                    Log(strLog);

                    m_MT4Controller.SendOrder(Command.Symbol, Command.Operation, Param.dLot, dPrice, expireTime, dTakeProfit, dStopLoss);
                }
            }
            catch(Exception ex)
            {
                Log("############## SOME ERROR HAPPEND! ##############");
                Log(ex.ToString());
            }
        }

        private void OnChangeMT4Connection(bool bConnection)
        {
            if (bConnection)
                Log("============= EA IS CONNECTED! ============");
            else
            {
                Log("############ EA IS DISCONNECTED! PLEASE RESTART! ###############");
                m_Timer.Enabled = false;
                //m_btnXlsOpen.Enabled = true;
            }
        }

        private void m_btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                string strVal = m_listEmailTitleCount.SelectedItem.ToString();
                string[] sep = { ":" };
                string[] strList = strVal.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                string strTitle = strList[0].Trim();
                m_Dic[strTitle] = 0;
                ShowEmailTitleCount();
            }
            catch
            {

            }
        }

        private void ShowEmailTitleCount()
        {
            m_listEmailTitleCount.Items.Clear();
            for (int i = 0; i < m_Dic.Keys.Count; i++)
            {
                string strEmailCount = m_Dic.Keys.ElementAt(i) + " : " + m_Dic.Values.ElementAt(i).ToString();
                m_listEmailTitleCount.Items.Add(strEmailCount);
            }
        }
    }
}
