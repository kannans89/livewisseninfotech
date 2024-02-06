using DIPRefactoredApp.HighlevelPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPRefactoredApp.HighlevelPolicy
{
    internal class TaxCalculator
    {
        private ILogger _logger;
        public TaxCalculator(ILogger logger)
        {
            _logger = logger;
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
                _logger.Log(ex);
            }
            return result;
        }

    }
}
