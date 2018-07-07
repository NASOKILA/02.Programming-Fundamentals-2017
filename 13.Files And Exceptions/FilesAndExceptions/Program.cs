using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("input.txt");

            Console.WriteLine(text);

            File.WriteAllText("input.txt", "Zdr nasko");

            File.AppendAllText("input.txt", "Zakachih te!" + Environment.NewLine);

            var newFile = new FileInfo("input.txt");

            Console.WriteLine(newFile.Length);

            Directory.CreateDirectory("out\\1\\2");

            Directory.Delete("out", true); 

            Directory.CreateDirectory("out\\1\\2"); 
            
            var allDirsInDebug = Directory.GetDirectories(@"C:\Users\nasko\Desktop\FilesAndExceptions\FilesAndExceptions\bin\Debug"); // vzimame papkite ot kudeto mu kajem da gi vzeme
            
            foreach (var dir in allDirsInDebug)
            {
                Console.WriteLine(dir);
            }
        }
    }
}
