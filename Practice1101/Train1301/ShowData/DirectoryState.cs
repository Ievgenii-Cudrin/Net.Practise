using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Train1301.ShowData
{
    public static class DirectoryState
    {
        public static void ShowDirectories(DirectoryInfo[] directories)
        {
            foreach (var directory in directories)
            {
                Console.WriteLine(directory.Name);
            }

            Console.WriteLine("-----------------");
        }

        public static void ShowFiles(FileInfo[] files)
        {
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }

            Console.WriteLine("-----------------");
        }
    }
}
