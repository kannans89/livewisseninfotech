using FDCoreLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDFCClientApp
{
    internal class DiwaliPolicy:IRatePolicy
    {
        public double CalcuateRate()
        {
            return .08;
        }
    }
   
}
