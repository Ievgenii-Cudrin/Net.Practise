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
            Console.WriteLine(string.Join(",", data.Where(x => x is Film)
                .Cast<Film>()
                .SelectMany(x => x.Actors.Select(x => x.Name))));
        }

        //2
        public static void ShowActorListWithBirthdayInAugust()
        {
            Console.WriteLine(string.Join(",", data.Where(x => x is Film)
                .Cast<Film>()
                .SelectMany(x => x.Actors.Where(x => x.Birthdate.Month == 8))
                .Count()));
        }

        //3
        public static void ShowTwoELderAuthors()
        {
            Console.WriteLine(string.Join(",", data.Where(x => x is Film).Cast<Film>()
                .SelectMany(x => x.Actors)
                .OrderBy(x => x.Birthdate)
                .Take(2)
                .Select(x => x.Name)));
        }

        //4
        public static void ShowCountOfArticleByAuthor()
        {
            Console.WriteLine(string.Join(",", data.Where(x => x is Article).Cast<Article>()
                .Select(x => x.Author)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count())
                .OrderByDescending(x => x.Value)));
        }

        //5
        public static void ShowCountOfArticleByAuthroAndFilmsByAuthor()
        {
            Console.WriteLine(string.Join(",", data
                .Where(x => x is Article).Cast<Article>()
                .Select(x => x.Author)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count())
                .OrderByDescending(x => x.Value)
                .Concat(data
                .Where(x => x is Film).Cast<Film>()
                .Select(x => x.Author)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count())
                .OrderByDescending(x => x.Value))));
        }

        //6
        public static void ShowCountOfDifferentLattersInActorsName()
        {
            Console.WriteLine(string.Join(",", data.Where(x => x is Film)
                .Cast<Film>()
                .SelectMany(x => x.Actors.Select(x => x.Name))
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Key.Replace(" ", "").Distinct().Count())));
        }

        //7
        public static void ShowAllArticleNamesAndSortByAuthor()
        {
            Console.WriteLine(string.Join("\n", data.Where(x => x is Article)
                .Cast<Article>()
                .OrderBy(x => x.Author)
                .ThenBy(x => x.Pages)
                .Select(x => x.Name)));
        }

        //8
        public static void ShowAllActorNamesWithTeirFilms()
        {
            Console.WriteLine(string.Join("\n", data.Where(x => x is Film)
                .Cast<Film>()
                .SelectMany(x => x.Actors.Select(x => x.Name))
                .Distinct()
                .GroupBy(p => p)
                .Select(g => new
                {
                    Name = g.Key,
                    Films = string.Join("\n", data.Where(x => x is Film)
                    .Cast<Film>()
                    .Select(x => x)
                    .Where(x => x.Actors.Any(x => x.Name == g.Key))
                    .Select(x => new
                    {
                        FilmName = x.Name
                    }))
                })
            ));
        }

        //9
        public static void SummOfPagesAndOtherInt()
        {
            Console.WriteLine(
                data.Where(x => x is Article)
                .Cast<Article>()
                .Select(x => x.Pages)
                .Sum()
                +
                data.Where(x => x is List<int>)
                .Cast<List<int>>()
                .Select(x => x.Sum())
                .Sum());
        }

        //10
        public static void GetDictionaryWithArticleAuthorNamesANdArticles()
        {
            var q = data.Where(x => x is Article)
                .Cast<Article>()
                .Select(x => x.Author)
                .Distinct()
                .GroupBy(p => p)
                .Select(g => new
                {
                    Authors = g.Key,
                    Articles = string.Join("\n", data.Where(x => x is Article)
                    .Cast<Article>()
                    .Select(x => x)
                    .Where(x => x.Author.Equals(g.Key))
                    .Select(x => new
                    {
                        ArticleName = x.Name
                    }))
                }).ToDictionary(x => x.Authors, x => x.Articles);
        }
    }
}
