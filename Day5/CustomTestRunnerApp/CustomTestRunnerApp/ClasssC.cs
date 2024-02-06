using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTestRunnerApp
{
    internal class ClasssC
    {
        [MyTestCase]
        public bool C1()
        {
            return 1 < 0;
        }

        [MyTestCase]
        public bool C2()
        {
            return 1 < 0;
        }

        [MyTestCase]
        public bool C3()
        {
            return 1 > 0;
        }
    }
}
