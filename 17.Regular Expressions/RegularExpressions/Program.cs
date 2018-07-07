using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";  
            Regex regex = new Regex(pattern); 

            string text = "ivan ivanov, Ivan ivanov, ivan Ivanov,IVan Ivanov, Ivan IvAnov, Ivan Ivanov";

            Match match = regex.Match(text);
            
            Console.WriteLine(match); 

            bool isTextMatch = regex.IsMatch(text);   

            Console.WriteLine(isTextMatch); 

            Console.WriteLine(); Console.WriteLine();
            
            string pattern2 = @"(\d{4})-(\d{2})-(\d{2})";

            Regex regex2 = new Regex(pattern2);

            string text2 = "Today is 2016-17-10. Yesterday was 2016-16-10";

            MatchCollection matches = regex2.Matches(text2);

            foreach (Match matched in matches)
            {
                Console.WriteLine(matched);
                Console.WriteLine(matched.Groups[2]);
            }

            string pattern3 = @"\d{3}";

            Regex regex3 = new Regex(pattern3);

            string text3 = "Nakov: 123, Krasi: 456";

            text3 = regex3.Replace(text3, "***");

            Console.WriteLine(text3);
            
            string t = "1     2  3      4";
            string patt = @"\s+";
            string[] results = Regex.Split(t, patt);
            
            Console.WriteLine(string.Join(", ", results)); 
            
            string nums = "2468";    

            if (nums.All(x => x % 2 == 0))   
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            if (nums.Any(n => n % 2 == 1))   
                Console.WriteLine("false");
            else
                Console.WriteLine("false");
        }
    }
}
