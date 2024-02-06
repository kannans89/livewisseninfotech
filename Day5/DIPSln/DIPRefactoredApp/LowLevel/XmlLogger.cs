using DIPRefactoredApp.HighlevelPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPRefactoredApp.Lowlevel
{
    internal class XmlLogger:ILogger
    {
        public void Log(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Writing into XML File, Please Wait");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.ResetColor();
        }
    }
}
