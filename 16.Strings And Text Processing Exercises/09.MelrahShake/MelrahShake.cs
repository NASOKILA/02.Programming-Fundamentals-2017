using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.MelrahShake
{
    class MelrahShake
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string key = Console.ReadLine();
            
            while (true)
            {
                var leftIndex = input.IndexOf(key);

                var rightIndex = input.LastIndexOf(key);
                
                bool leftIndexExist = leftIndex != -1;

                bool rightIndexExist = rightIndex != -1;
                
                bool okToShake = leftIndex != rightIndex;

                bool keyNotEmpty = key != string.Empty;

                if (leftIndexExist && rightIndexExist && okToShake && keyNotEmpty)
                {
                    input = input.Remove(leftIndex, key.Length);
            
                    input = input.Remove(rightIndex - key.Length, key.Length);

                    Console.WriteLine("Shaked it.");
                    
                    key = key.Remove(key.Length / 2, 1);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }
            }

            Console.WriteLine(input);
        }
    }
}
