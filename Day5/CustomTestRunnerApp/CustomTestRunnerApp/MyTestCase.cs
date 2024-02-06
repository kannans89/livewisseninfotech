using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTestRunnerApp
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false)]
    internal class MyTestCase:Attribute
    {

    }
}
