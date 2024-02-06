using FDCoreLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDFCClientApp
{
    internal class RamzanFestivalPolicy:IRatePolicy
    {
        public double CalcuateRate()
        {
            //algorithm
            return .06;
        }
    }
  
}
