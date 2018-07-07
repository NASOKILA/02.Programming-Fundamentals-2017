using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.TakeSkipRope
{
    class TakeSkipRope
    {
        static void Main(string[] args)
        {
            string encriptedMessage = Console.ReadLine();

            List<int> numbersOfMesage = new List<int>();

            List<string> lettersOfMessage = new List<string>();

            foreach (var ch in encriptedMessage)
            {
                if (ch > 47 && ch < 58) 
                    numbersOfMesage.Add(int.Parse(ch.ToString()));
                else 
                    lettersOfMessage.Add(ch.ToString());
            }
            
            List<int> takeList = new List<int>();

            List<int> skipList = new List<int>();

            int counter = 0;
            foreach (var item in numbersOfMesage)
            {
                if (counter % 2 == 0)
                    takeList.Add(item);
                else
                    skipList.Add(item);
                counter++;
            }

            List<string> resultList = new List<string>();

            string resultStr = string.Empty;

            
            int total = 0;

            int takenChars = 0;

            int skippedChars = 0;

            for (int i = 0; i < takeList.Count; i++) 
            {
                total += (skippedChars + takenChars);
                skippedChars = skipList[i];
                takenChars = takeList[i];
 
                resultList = lettersOfMessage.Skip(total).Take(takenChars).ToList();
                resultStr += string.Join("", resultList);       
            }

            Console.WriteLine(resultStr);
        }
    }
}
