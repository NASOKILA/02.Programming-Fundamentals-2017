using System;
using System.Collections.Generic;
using System.Linq;


namespace _10.SrubskoUnleashed
{
    class SrubskoUnleashed
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> arenaSingersAndTotalPrices = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> singersAndTotalPrices = new Dictionary<string, long>();

            SetVenueSingersAndTotalPrice(input, arenaSingersAndTotalPrices, singersAndTotalPrices);

            PrintResult(arenaSingersAndTotalPrices);
           

        }

        private static void SetVenueSingersAndTotalPrice(string input, Dictionary<string, Dictionary<string, long>> arenaSingersAndTotalPrices, Dictionary<string, long> singersAndTotalPrices)
        {

            while (input != "End")
            {
                string[] inputArr = input.Split('@').ToArray();

                string singer = inputArr[0];

                if (singer.Last() != ' ')
                    input = Console.ReadLine();
                else
                {
                    singer = singer.Trim();

                    List<string> remainingInfo = inputArr[1].Split(' ').ToList();

                    if (remainingInfo.Count < 3) 
                        input = Console.ReadLine();
                    else
                    {
                        long ticketCount = long.Parse(remainingInfo.Last());
                        remainingInfo.RemoveAt(remainingInfo.Count - 1);

                        long ticketPrice = long.Parse(remainingInfo.Last());
                        remainingInfo.RemoveAt(remainingInfo.Count - 1);

                        string arena = string.Empty;
                        foreach (var item in remainingInfo)
                            arena += item.ToString() + " ";
                        arena = arena.Trim();

                        long totalMoney = ticketCount * ticketPrice;

                        if (!arenaSingersAndTotalPrices.ContainsKey(arena))
                            singersAndTotalPrices = new Dictionary<string, long>();
                        else 
                            singersAndTotalPrices = arenaSingersAndTotalPrices[arena];



                        if (!singersAndTotalPrices.ContainsKey(singer))
                            singersAndTotalPrices[singer] = totalMoney;
                        else
                            singersAndTotalPrices[singer] += totalMoney;

                        singersAndTotalPrices = singersAndTotalPrices.OrderByDescending(pair => pair.Value)
                        .ToDictionary(pair => pair.Key, pair => pair.Value);

                        arenaSingersAndTotalPrices[arena] = singersAndTotalPrices;

                        input = Console.ReadLine();
                    }
                }
            }
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> arenaSingersAndTotalPrices)
        {
            foreach (var arena in arenaSingersAndTotalPrices)
            {
                Console.WriteLine(arena.Key);
                foreach (var singerAndPrice in arena.Value)
                {
                    Console.WriteLine($"#  {singerAndPrice.Key} -> {singerAndPrice.Value}");
                }
            }
        }
    }
}
