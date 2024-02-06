using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPRefactoredApp.HighlevelPolicy
{
    internal interface ILogger
    {
        void Log(Exception ex);
    }
}
