using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, Dictionary<string, int>>> typeNameAndInfo = new Dictionary<string, Dictionary<string, Dictionary<string,int>>>();

            Dictionary<string, Dictionary<string, int>> nameAndInfo = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> info = new Dictionary<string, int>();
            
            for (int i = 0; i < n; i++)
            {
                int damage = 0;
                int health = 0;
                int armor = 0;

                List<string> command = Console.ReadLine().Split().ToList();
                string typeOfDragon = command.First();

                string nameOfDragon = command[1];

                if(command[2] == "null")
                    damage = 45;
                else
                    damage = int.Parse(command[2]);

                if (command[3] == "null")
                    health = 250;
                else
                    health = int.Parse(command[3]);

                if (command.Last() == "null")
                    armor = 10;
                else
                    armor = int.Parse(command.Last());
                
                if (!typeNameAndInfo.ContainsKey(typeOfDragon))
                {
                    nameAndInfo = new Dictionary<string, Dictionary<string, int>>();
                    info = new Dictionary<string, int>();
                }
                else
                {
                    nameAndInfo = typeNameAndInfo[typeOfDragon];
                    info = new Dictionary<string, int>();
                }
                
                info["damage"] = damage;
                info["health"] = health;
                info["armor"] = armor;
                
                nameAndInfo[nameOfDragon] = info;
  
                typeNameAndInfo[typeOfDragon] = nameAndInfo;
            }
            
            foreach (var type in typeNameAndInfo)
            {
                double averageDamage = 0.0;
                double averageHealth = 0.0;
                double averageArmor = 0.0;

                foreach (var dragon in type.Value)
                {
                    int counter = 0;
                    foreach (var information in dragon.Value)
                    {
                        if (counter == 0)
                            averageDamage += information.Value;
                        else if (counter == 1)
                            averageHealth += information.Value;
                        else if (counter == 2)
                            averageArmor += information.Value;
                        counter++;
                    }
                }

                averageDamage = averageDamage / type.Value.Count;
                averageHealth = averageHealth / type.Value.Count;
                averageArmor = averageArmor / type.Value.Count;
                
                Console.WriteLine($"{type.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragon in type.Value.OrderBy(a => a.Key))
                {
                    Console.Write($"-{dragon.Key} -> ");
                    List<string> dragonValues = new List<string>();
                    foreach (var information in dragon.Value)
                        dragonValues.Add($"{information.Key}: {information.Value}");
                    Console.WriteLine(string.Join(", ", dragonValues));
                }
            }
        }
    }
}
