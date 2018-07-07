using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ParkingValidation
{
    class ParkingValidation
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> namesAndPlates = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                List<string> inputArr = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                Register(inputArr, namesAndPlates);

                Unregister(inputArr, namesAndPlates);
            }

            PrintResult(namesAndPlates);
        }

        private static void Unregister(List<string> inputArr, Dictionary<string, string> namesAndPlates)
        {

            if (inputArr[0] == "unregister")
            {
                string command = inputArr[0];
                string username = inputArr[1];

                if (!namesAndPlates.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: user {username} not found");
                }
                else
                {
                    Console.WriteLine($"user {username} unregistered successfully");
                    
                    foreach (var namePlate in namesAndPlates.Where(kvp => kvp.Key == username))
                    {
                        namesAndPlates.Remove(namePlate.Key);
                        break;
                    }
                }
            }
        }

        private static void Register(List<string> inputArr, Dictionary<string, string> namesAndPlates)
        {
            if (inputArr[0] == "register")
            {

                string command = inputArr[0];
                string username = inputArr[1];
                string licensePlateNumber = inputArr[2];
                
                bool isThePlateValid = true;

                if (licensePlateNumber.Length != 8)
                    isThePlateValid = false
                else if (char.IsLower(licensePlateNumber[0]) || char.IsLower(licensePlateNumber[1]))
                    isThePlateValid = false;
                else if (char.IsLower(licensePlateNumber[6]) || char.IsLower(licensePlateNumber[7]))
                    isThePlateValid = false;
                else if ((licensePlateNumber[2] < 48 || licensePlateNumber[2] > 57) || (licensePlateNumber[3] < 48 || licensePlateNumber[3] > 57)
                    || (licensePlateNumber[4] < 48 || licensePlateNumber[4] > 57) || (licensePlateNumber[5] < 48 || licensePlateNumber[5] > 57))
                    isThePlateValid = false;
                
                if (!isThePlateValid)
                    Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");       
                else if (namesAndPlates.ContainsKey(username))
                    Console.WriteLine($"ERROR: already registered with plate number {namesAndPlates[username]}");
                else if (namesAndPlates.ContainsValue(licensePlateNumber))
                    Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                else
                {
                    namesAndPlates[username] = licensePlateNumber;
                    Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                }
            }
        }

        private static void PrintResult(Dictionary<string, string> namesAndPlates)
        {
            foreach (var namePlate in namesAndPlates)
            {
                string name = namePlate.Key;
                string plate = namePlate.Value;

                Console.WriteLine($"{name} => {plate}");
            }
        }
    }
}
