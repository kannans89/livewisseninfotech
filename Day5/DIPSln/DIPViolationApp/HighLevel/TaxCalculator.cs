using DIPViolationApp.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPViolationApp.HighLevel
{
    internal class TaxCalculator
    {
        private LogTypes _logtype;
        public TaxCalculator(LogTypes logtype)
        {
            _logtype = logtype;
        }
        public int CalculateTax(int income, int rate)
        {
            int result = -1;
            try
            {
                result = income / rate;
            }
            catch (Exception ex)
            {
                if (_logtype == LogTypes.TXT)
                {
                    var txtLogger = new TextLogger();
                    txtLogger.Log(ex);
                }
                else if(_logtype == LogTypes.DB)
                {
                    var xmlLogger = new XmlLogger();
                    xmlLogger.Log(ex);
                }
                else
                {
                    var xmlLogger = new XmlLogger();
                    xmlLogger.Log(ex);
                }
            }
            return result;
        }

    }
}
