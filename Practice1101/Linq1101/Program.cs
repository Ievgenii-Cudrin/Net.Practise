using Linq1101.Entities;
using Linq1101.Helper;
using Practice1101.Helper;
using System;
using System.Collections.Generic;

namespace Linq1101
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ 11.01
            //Linq to array

            //1
            WorkWithString.ShowNumbers();

            //2
            WorkWithString.ShowNumbersWhichSplitOnThree();

            //3
            WorkWithString.ShowLinq();

            //4
            WorkWithString.ShpwWordsWIthLetterA();

            //5
            WorkWithString.ShowCountOfLetterA();

            //6
            WorkWithString.ShowTrueOrFalseIfStringContainABB();

            //7
            WorkWithString.ShowMostLongerString();

            //8
            WorkWithString.ShowAverageStringLength();

            //9
            WorkWithString.ShowReversShortString();

            //10
            WorkWithString.ShowBoolSTringStartFromAA();

            //11
            WorkWithString.ShowWordsWichStartFromAA();

            //SecondTask Linq to object

            //1
            WorkWithObject.ShowAllAktorsName();

            //2
            WorkWithObject.ShowActorListWithBirthdayInAugust();

            //3
            WorkWithObject.ShowTwoELderAuthors();

            //4
            WorkWithObject.ShowCountOfArticleByAuthor();

            //5
            WorkWithObject.ShowCountOfArticleByAuthroAndFilmsByAuthor();

            //6
            WorkWithObject.ShowCountOfDifferentLattersInActorsName();

            //7
            WorkWithObject.ShowAllArticleNamesAndSortByAuthor();

            //8
            WorkWithObject.ShowAllActorNamesWithTeirFilms();

            //9
            WorkWithObject.SummOfPagesAndOtherInt();

            //10
            WorkWithObject.GetDictionaryWithArticleAuthorNamesANdArticles();

            Console.ReadLine();
        }
    }
}
