using System;
using System.IO;
using WritePropertiesToCSV.Entities;
using WritePropertiesToCSV.GetData;
using System.Linq;
using System.Reflection;
using WriteToCSVFile.Helper;

namespace WriteToCSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithFile.CreateFile();
            string[] massOfpropertiesFromUser = Console.ReadLine().Split(',');

            foreach(var property in typeof(Person).GetProperties())
            {
                foreach (var userProperty in massOfpropertiesFromUser)
                {
                    using (StreamWriter file = new StreamWriter("properties.csv", true))
                    {
                        string str = property.Name == userProperty ? property.Name + "\n" + string.Join("\n", PersonList.GetListPerson()
                            .Select(x => typeof(Person)
                            .GetProperty(userProperty, BindingFlags.Instance | BindingFlags.Public)
                            .GetValue(x, null))) : "";

                        file.WriteLine(str);
                    }
                }
            }
        }
    }
}
