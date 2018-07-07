using System;
using System.Globalization;

namespace _01.DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string format = "d-M-yyyy";

            var date = DateTime.ParseExact(input, 
                format, 
                CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
