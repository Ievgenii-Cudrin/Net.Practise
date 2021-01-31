using System;
using System.Collections.Generic;
using System.Text;
using WritePropertiesToCSV.Entities;

namespace WritePropertiesToCSV.GetData
{
    public static class PersonList
    {
        public static List<Person> GetListPerson()
        {
            return new List<Person>
            {
                new Person
                {
                    Age = 4,
                    EyeColor = "blue",
                    Name = "Juarez Mayo",
                    Gender = "male",
                    Company = "MAGNEATO",
                    Address= "284 Kansas Place, Beyerville, Pennsylvania, 5206",
                    Salary = (decimal?) 345.6
                },
                new Person
                {
                    Age= 26,
                    EyeColor= "green",
                    Name= "Orr Love",
                    Gender= "male",
                    Company= "BULLZONE",
                    Address= "893 Beaver Street, Johnsonburg, Nebraska, 503",
                    Salary = (decimal?) 99.32
                },
                new Person
                {
                    Age= 32,
                    EyeColor= "blue",
                    Name= "Mccall Munoz",
                    Gender= "male",
                    Company= "DOGNOST",
                    Address= "850 Mill Road, Chemung, Mississippi, 2962",
                    Salary = (decimal?) 3000.89
                },
                new Person
                {
                    EyeColor= "green",
                    Name= "Strong Downs",
                    Gender= "male",
                    Company= "BEADZZA",
                    Address= "377 Homecrest Court, Tuskahoma, New Jersey, 3583"
                },
                new Person
                {
                    EyeColor= "brown",
                    Name = "Sarah Pope",
                    Gender = "female"
                }
            };
        }
    }
}
