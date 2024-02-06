using DIPViolationApp.HighlevelPolicy;

namespace DIPViolationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new TaxCalculator(LogTypes.TXT);
            Console.WriteLine(calc.CalculateTax(10, 2));
            Console.WriteLine(calc.CalculateTax(10, 0));
        }
    }
}