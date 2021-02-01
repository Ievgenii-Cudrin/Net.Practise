using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Train1301.Helper
{
    public static class GetInfo
    {
        public static DirectoryInfo[] GetDirectoriesFromSomePath(DirectoryInfo directory) => directory.GetDirectories().Where(folder => (folder.Attributes & FileAttributes.Hidden) == 0).ToArray();

        public static FileInfo[] GetFilesFromSomePath(DirectoryInfo directory) => directory.GetFiles().Where(file => (file.Attributes & FileAttributes.Hidden) == 0).ToArray();
     
        public static DirectoryInfo GetDirectory(string path) => new DirectoryInfo(path);
    }
}
