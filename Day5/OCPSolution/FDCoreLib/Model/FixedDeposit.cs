using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCoreLib.Model
{
    public class FixedDeposit
    {
        private int _accno;
        private string _name;
        private double _principleAmount;
        private int _duration;
        private IRatePolicy _ratePolicy;

        public FixedDeposit(int accno, string name, double principleAmount, int duration, IRatePolicy ratePolicy)
        {
            _accno = accno;
            _name = name;
            _principleAmount = principleAmount;
            _duration = duration;
            _ratePolicy = ratePolicy;
        }


        public double SimpleInterest
        {
            get
            {
                return _principleAmount * _duration * _ratePolicy.CalcuateRate();
            }
        }
    }
}
