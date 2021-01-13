using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Train1301.Helper;

namespace Train1301
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partOfAllPath = new List<string>() { @"C:\" };
            while (true)
            {
                string path = string.Join(@"\", partOfAllPath.Select(x => x));
                DirectoryInfo currentDirectiry = GetInfo.GetDirectory(path);
                Console.Write($"{path}\n");
                
            }
        }
    }
}
