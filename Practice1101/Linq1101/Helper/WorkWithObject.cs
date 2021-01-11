using Linq1101.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq1101.Helper
{
    public static class WorkWithObject
    {
        static List<object> data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
            };

        //1
        public static void ShowAllAktorsName()
        {
            Console.WriteLine(string.Join(",", data.Where(x => x is Film).Cast<Film>().SelectMany(x => x.Actors.Select(x => x.Name))));
        }

        //2
        public static void ShowActorListWithBirthdayInAugust()
        {
            Console.WriteLine(string.Join(",", data.Where(x => x is Film).Cast<Film>().SelectMany(x => x.Actors.Where(x => x.Birthdate.Month == 8)).Count()));
        }

        //3



    }
}
