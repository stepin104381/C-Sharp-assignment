using System;


namespace SampleConApp
{
   
    class DateValidation
    {
        static bool isLeap(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
                return true;
            else
                return false;
        }

        static bool isValidDate(int year, int month, int day)
        {
            if (month < 1 || month > 12)
                return false;

            if (day < 1 || day > 31)
                return false;

            if (month == 2)
            {
                if (isLeap(year))
                {
                    return (day <= 29);
                }
                else
                    return (day <= 28);
            }
            if (month == 4 || month == 6 || month == 9 || month == 11)
                return (day <= 30);

            return true;


        }
        static void Main()
        {
            int day, month, year;
            Console.WriteLine("Enter the day:");
            day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the month:");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the year:");
            year = int.Parse(Console.ReadLine());

            if (isValidDate(year, month, day))
                Console.WriteLine("calender valid");
            else
                Console.WriteLine("calender is in invalid format");
        }
    }
}
