namespace MathLib
{
    public class Math
    {

        public int CubeEvenNo(int n)
        {
            if (n % 2 == 0)
            {
                return n * n * n;
            }
            throw new ArgumentException("Number is not even");
        }

        public bool IsPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<int> GetPrimes(int from,int to)
        {
            for (int i = from; i <= to; i++)
            {
                if (IsPrime(i))
                {
                    yield return i;
                }
            }
        }


        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}
