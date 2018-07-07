using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ByteFlip
{
    class ByteFlip
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ')
                .Where(n => n.Length == 2)
                .ToList();

            list.Reverse();
            
            foreach (var elem in list)
            {
                string reversedElem = new string(elem.ToCharArray().Reverse().ToArray());
                char ch = (char)Int16.Parse(reversedElem, NumberStyles.AllowHexSpecifier);
                Console.Write(ch);
            }

            Console.WriteLine();
        }
    }
}
