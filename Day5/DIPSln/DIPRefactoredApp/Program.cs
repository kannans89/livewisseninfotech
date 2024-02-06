using DIPRefactoredApp.HighlevelPolicy;
using DIPRefactoredApp.Lowlevel;
using DIPRefactoredApp.LowLevel;

namespace DIPRefactoredApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new TaxCalculator(new XmlLogger());
            Console.WriteLine(calc.CalculateTax(10, 2));
            Console.WriteLine(calc.CalculateTax(10, 0));
        }
    }
}