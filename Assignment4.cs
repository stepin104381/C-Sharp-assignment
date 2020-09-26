using System;


namespace SampleConApp
{
    
    class Sumevenodd
    {

        public int[] sumOfEvensAndOdds(int[] nums)
        {
            int oddsum = 0, evensum = 0, j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                    evensum += nums[i];
                else
                    oddsum += nums[i];

            }
            int[] sum = new int[3];

            sum[j] = oddsum;
            sum[j + 1] = evensum;

            return sum;
        }
        static void Main()
        {

            Sumevenodd sum = new Sumevenodd();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] nums1 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] result = sum.sumOfEvensAndOdds(nums);
            int[] result1 = sum.sumOfEvensAndOdds(nums1);
            for (int k = 0; k < 2; k++)
                Console.Write(result[k] + " ");
            Console.WriteLine();
            for (int l = 0; l < 2; l++)
                Console.Write(result1[l] + " ");

        }
    }
}
