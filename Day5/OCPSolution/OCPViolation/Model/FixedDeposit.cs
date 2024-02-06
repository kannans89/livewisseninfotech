using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPViolation.Model
{
    internal class FixedDeposit
    {
        private int _accno;
        private string _name;
        private double _principleAmount;
        private int _duration;
        private FestivalTypes _festivalType;

        public FixedDeposit(int accno, string name, double principleAmount, int duration, FestivalTypes festivalType)
        {
            _accno = accno;
            _name = name;
            _principleAmount = principleAmount;
            _duration = duration;
            _festivalType = festivalType;
        }
        public double CalcuateRate()
        {
            if (_festivalType == FestivalTypes.DIWALI)
                return .09;//complex alogrithm

            else if (_festivalType == FestivalTypes.NEW_YEAR)
                return .08;//complex alogrithm

            else if (_festivalType == FestivalTypes.CRISTMAS)
                return .07;//complex alogrithm

            else if (_festivalType == FestivalTypes.RAMZAN)
                return .06;//complex alogrithm

            else
            return .06;

        }

        public double SimpleInterest
        {
            get
            {
                return _principleAmount * _duration * CalcuateRate();
            }
        }
    }
}
