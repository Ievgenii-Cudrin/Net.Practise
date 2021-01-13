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

        static void ShowDataOfFileOtherThanTxt(string path)
        {
            using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                int length = fsSource.Length > 2048 ? 2048 : (int)fsSource.Length;
                byte[] bytes = new byte[length];
                int numBytesToRead = length;
                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                    {
                        break;
                    }

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                Console.WriteLine(string.Join(",", bytes.Select(x => x)));
            }
        }
    }
}
