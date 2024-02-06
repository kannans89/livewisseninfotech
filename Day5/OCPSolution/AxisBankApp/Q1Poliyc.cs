using FDCoreLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxisBankApp
{
    internal class Q1Poliyc : IRatePolicy
    {
        public double CalcuateRate()
        {
            return .07;
            //dimenstion
        }
    }
}
