using System;


namespace SampleConApp
{
    
    class Primenumber
    {

        static bool isPrimeNumber(int num)
        {
            if (num <= 1)
                return false;
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        static void Main()
        {

            Console.WriteLine("enter number");
            int number = int.Parse(Console.ReadLine());
            bool status = isPrimeNumber(number);
            if (status == true)
                Console.WriteLine("number is prime");
            else
                Console.WriteLine("number is not prime");


        }
    }
}
