using System;

namespace _01.CharityMarathon
{
    class CharityMarathon
    {
        static void Main(string[] args)
        {
            short daysOFMarathon = short.Parse(Console.ReadLine());
            long runnersCount = long.Parse(Console.ReadLine());
            byte lapsCount = byte.Parse(Console.ReadLine());
            long trackLength = long.Parse(Console.ReadLine());
            short trackCpacity = short.Parse(Console.ReadLine());
            decimal moneyPerKm = decimal.Parse(Console.ReadLine());

            long maxRunners = daysOFMarathon * trackCpacity;
            long runners = Math.Min(maxRunners, runnersCount);

            decimal totalMeters = runners * lapsCount * trackLength;
            long totalKilometers = (long)(totalMeters / 1000);
            decimal moneyRaisedForTheMarathon = moneyPerKm * totalKilometers;

            Console.WriteLine($"Money raised: {moneyRaisedForTheMarathon:F2}");
        }
    }
}
