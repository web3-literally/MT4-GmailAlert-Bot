using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace GmailRead
{

    class TitleCommand
    {
        public string OriginTitle { get; set; }
        public string Operation { get; set; }
        public string Period { get; set; }
        public string Symbol { get; set; }
    }
    class GmailReader
    {
        public string m_strGmail { get; set; }
        public string m_strPassword { get; set; }
        private string m_lastModifiedTime { get; set; }

        public TitleCommand ReadGmail()
        {
            var Url = @"https://mail.google.com/mail/feed/atom";
            var encoded = TextToBase64(m_strGmail + ":" + m_strPassword);
            var request = HttpWebRequest.Create(Url);
            request.Method = "POST";
            request.ContentLength = 0;
            request.Headers.Add("Authorization", "Basic" + encoded);
            try
            {
                var respone = request.GetResponse();
                var stream = respone.GetResponseStream();
                XmlReader reader = XmlReader.Create(stream);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                XmlNodeList emailList = doc.GetElementsByTagName("entry");

                for (int i = 0; i < emailList.Count; i++)
                {
                    string emailTitle = emailList[i].ChildNodes.Item(0).InnerText.Trim();
                    if (emailTitle.Contains("TradingView Alert:"))
                    {
                        string[] spearator = { ":", "_" };
                        string[] strlist = emailTitle.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                        string strOperation = strlist[1].Trim();
                        if (strOperation == "BUY" || strOperation == "SELL")
                        {
                            TitleCommand Command = new TitleCommand();
                            Command.Operation = strOperation;
                            Command.Period = strlist[2];
                            Command.Symbol = strlist[3];
                            Command.OriginTitle = Command.Operation + "_" + Command.Period + "_" + Command.Symbol;
                            string strModifiedTime = emailList[i].ChildNodes.Item(3).InnerText.Trim();
                            if (m_lastModifiedTime == strModifiedTime)
                            {
                                return null;
                            }
                            else
                            {
                                m_lastModifiedTime = strModifiedTime;
                                return Command;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public static string TextToBase64(string S)
        {
            System.Text.ASCIIEncoding encode = new System.Text.ASCIIEncoding();
            byte[] bytes = encode.GetBytes(S);
            return System.Convert.ToBase64String(bytes, 0, bytes.Length);
        }
    }
}
