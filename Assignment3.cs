using System;

namespace SampleConApp
{
   
    class PrimeRange
    {

        public int sumOfPrimes(int from, int to)
        {
            
            int range=to+1;
            int[] array = new int[range];
            for (int i = from; i <= to; i++)
            {
                if (i == 1 || i == 0)
                    continue;

                int flag = 1;

                for (int j = 2; j <= i / 2; ++j)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }

                if (flag == 1)
                    array[i] = i;
            }
            int sum = 0;
            foreach (int elem in array)
            {
                sum = sum + elem;
            }
            return sum;
        }

        static void Main()
        {
            Console.WriteLine("Enter starting range of prime numbers:");
            int from = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter starting range of prime numbers:");
            int to = int.Parse(Console.ReadLine());

            PrimeRange p = new PrimeRange();
            int value = p.sumOfPrimes(from, to);
            Console.WriteLine("sum of prime numbers:" + value);


        }
    }
}
