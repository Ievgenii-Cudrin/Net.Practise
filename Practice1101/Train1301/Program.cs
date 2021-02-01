using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Train1301.Helper;
using Train1301.ShowData;

namespace Train1301
{
    class Program
    {
        static void Main(string[] args)
        {
            //list with parts of path
            List<string> partOfAllPath = new List<string>() { @"C:\" };
            while (true)
            {
                //create full path from list
                string path = string.Join(@"\", partOfAllPath.Select(x => x));
                DirectoryInfo currentDirectiry = GetInfo.GetDirectory(path);
                //Show all directories
                DirectoryState.ShowDirectories(GetInfo.GetDirectoriesFromSomePath(currentDirectiry));
                //Show all documents
                DirectoryState.ShowFiles(GetInfo.GetFilesFromSomePath(currentDirectiry));
                //get value from user
                Console.Write($"{path}\\");
                string userValue = Console.ReadLine();
                //check: user select directory or file
                bool isDirectory = GetInfo.GetDirectoriesFromSomePath(currentDirectiry).Any(x => x.Name.Equals(userValue));
                bool isFile = GetInfo.GetFilesFromSomePath(currentDirectiry).Any(x => x.Name.Equals(userValue));

                //if directory, we add new part of path to list and in the next step we have new path
                if (isDirectory)
                {
                    partOfAllPath.Add(userValue);
                }
                //if file, create full path to file and show data from file
                else if (isFile)
                {
                    string s = string.Join(@"\", partOfAllPath.Select(x => x));
                    ShowDataFromFile.ShowDataInFile(s + $"\\{userValue}");
                }
                //if ".." we delete last part of path and return to previous directory
                else if (userValue == "..")
                {
                    if(partOfAllPath.Count < 2)
                    {
                        Console.WriteLine("\nIt is root directory\n");
                    }
                    else
                    {
                        partOfAllPath.RemoveAt(partOfAllPath.Count - 1);
                    }
                }
                //No equals names in directory and files
                else
                {
                    Console.WriteLine("\nNo equals names\n");
                }
            }
        }
    }
}
