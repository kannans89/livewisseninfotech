namespace CalcLib
{
    public class Calculator
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Subtract(int first, int second)
        {
            return first - second;
            
        }

        public int Mulitply(int first, int second)
        {
             return first * second;
            //return first /second;

        }
        
        public (int Result, int Reminder) Divide(int first, int second)
        {
           // if(second==0)
              // throw new DivideByZeroException();

            var result = first / second;
           
            var remainder = first % second;
            return (result, remainder);
        }

    }
}
