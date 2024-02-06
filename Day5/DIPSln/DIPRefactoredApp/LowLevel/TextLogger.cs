using DIPRefactoredApp.HighlevelPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPRefactoredApp.Lowlevel
{
    internal class TextLogger : ILogger
    {
        public void Log(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Writing into Text File, Please Wait");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.ResetColor();
        }
    }
}
