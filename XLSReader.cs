using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;

namespace GmailRead
{
    class OrderParameter
    {
        public string strPrice { get; set; } //Low,High,Open,CLose
        public double dLot { get; set; }
        public double dStopLoss { get; set; }
        public double dTakeProfit { get; set; }
        public double dX { get; set; }
        public double expireTime { get; set; }
    }
    class XLSReader
    {
        private Spreadsheet document = new Spreadsheet();
        private Worksheet sheet;
        private bool m_bOpened = false;
        public bool OpenXLSFile(string strPath)
        {
            try
            {
                document.LoadFromFile(strPath);
                sheet = document.Workbook.Worksheets[0];
                m_bOpened = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OrderParameter ReadOrderParameters(string strTitle, int nCount, int nNumber)
        {
            if (!m_bOpened) return null;
            try
            {
                string strTitleCellName = "A";
                int nIndex = 1;
                bool bFound = false;
                while (true)
                {
                    string CellTitle = sheet.Cell(strTitleCellName + nIndex.ToString()).Value.ToString();
                    if (CellTitle == strTitle)
                    {
                        bFound = true;
                        break;
                    }
                    if (CellTitle == null || CellTitle == "")
                    {
                        break;
                    }
                    nIndex++;
                }
                if (bFound)
                {
                    if (sheet.Cell(nIndex-1, 1).ToInteger() < nCount) return null;
                    string strPrice = sheet.Cell(nIndex-1, 3 + 6 * ((nCount - 1) * 3 + nNumber)).Value.ToString();
                    if (strPrice != "Low" && strPrice != "High" && strPrice != "Open" && strPrice != "Close") return null;
                    double LotSize = sheet.Cell(nIndex-1, 4 + 6 * ((nCount - 1) * 3 + nNumber)).ToDouble();
                    double StopLoss = sheet.Cell(nIndex-1, 5 + 6 * ((nCount - 1) * 3 + nNumber)).ToDouble();
                    double TakeProfit = sheet.Cell(nIndex-1, 6 + 6 * ((nCount - 1) * 3 + nNumber)).ToDouble();
                    double X = sheet.Cell(nIndex-1, 7 + 6 * ((nCount - 1) * 3 + nNumber)).ToDouble();
                    double Expire = sheet.Cell(nIndex-1, 8 + 6 * ((nCount - 1) * 3 + nNumber)).ToDouble();

                    OrderParameter Param = new OrderParameter();
                    Param.strPrice = strPrice;
                    Param.dLot = LotSize;
                    Param.dStopLoss = StopLoss;
                    Param.dTakeProfit = TakeProfit;
                    Param.dX = X;
                    Param.expireTime = Expire;
                    return Param;
                }
            }
            catch
            {

            }
            return null;
        }
    }
}
