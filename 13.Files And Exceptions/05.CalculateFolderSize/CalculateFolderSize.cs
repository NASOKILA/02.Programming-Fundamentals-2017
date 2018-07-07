using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateFolderSize
{
    class CalculateFolderSize
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("..\\..\\..\\05.CalculateFolderSize");

            double sum = 0;

            foreach (var f in files)
            {
                FileInfo fileInfo = new FileInfo(f);

                sum += fileInfo.Length;
            }

            double sumInMegabytes = sum / 1024 / 1024;

            File.WriteAllText("output.txt", sumInMegabytes.ToString());
        }
    }
}
