using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WriteToCSVFile.Helper
{
    public static class WorkWithFile
    {
        public static void CreateFile()
        {
            FileStream stream = new FileInfo("properties.csv").Create();
            stream.Close();
        }
    }
}
