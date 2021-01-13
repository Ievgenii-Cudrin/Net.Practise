using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Train1301.ShowData
{
    public static class ShowDataFromFile
    {
        private static void ShowDataInFile(string path)
        {
            if (Path.GetExtension(path) == ".txt")
            {
                ShowFileTxtData(path);
            }
            else
            {
                ShowDataOfFileOtherThanTxt(path);
            }
        }

        static void ShowFileTxtData(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                char[] c = null;

                while (sr.Peek() >= 0)
                {
                    c = new char[1024];
                    sr.Read(c, 0, c.Length);
                    Console.WriteLine(c);
                }
            }
        }
    }
}
