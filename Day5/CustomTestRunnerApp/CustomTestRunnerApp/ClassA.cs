using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTestRunnerApp
{
    internal class ClassA
    {
        [MyTestCase]
        public bool A1() {
            return 1 > 0;
        }

        [MyTestCase]
        public bool A2()
        {
            return 1 > 0;
        }

        [MyTestCase]
        public bool A3()
        {
            return 1 > 0;
        }
    }
}
