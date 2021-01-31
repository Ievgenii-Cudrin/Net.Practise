using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice1101.Helper
{
    public static class WorkWithString
    {
        static string[] firstWordsArray = { "aaa", "abb", "ccc", "dap" };
        static string[] secondWordsArray = { "aaa", "xabbx", "abb", "ccc", "dap" };
        static string[] thirdArray = { "aaa", "xabbx", "abb", "ccc", "dap", "zh" };
        static string[] fourthArray = { "baaa", "aabb", "aaa", "xabbx", "abb", "ccc", "dap", "zh" };

        //1
        public static void ShowNumbers()
        {
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 41)));
        }

        //2
        public static void ShowNumbersWhichSplitOnThree()
        {
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 41).Where(x=>x%3==0)));
        }

        //3
        public static void ShowLinq()
        {
            Console.WriteLine(string.Join("\n", Enumerable.Repeat("Linq", 10)));
        }

        //4
        public static void ShpwWordsWIthLetterA()
        {
            
            Console.WriteLine(string.Join("\n", firstWordsArray.Where(x => x.Contains("a"))));
        }

        //5
        public static void ShowCountOfLetterA()
        {
            Console.WriteLine(string.Join(",", firstWordsArray.Select(x => x.Count(f => f == 'a'))));
        }

        //6
        public static void ShowTrueOrFalseIfStringContainABB()
        {
            Console.WriteLine(string.Join(",", secondWordsArray.Select(x => x.Contains("abb") ? true : false)));
        }

        //7
        public static void ShowMostLongerString()
        {
            Console.WriteLine(secondWordsArray.OrderByDescending(x => x.Length).First());
        }

        //8
        public static void ShowAverageStringLength()
        {
            Console.WriteLine(secondWordsArray.Average(x => x.Length));
        }

        //9
        public static void ShowReversShortString()
        {
            Console.WriteLine(thirdArray.OrderBy(x => x.Length).FirstOrDefault().Reverse().ToArray());
        }

        //10
        public static void ShowBoolSTringStartFromAA()
        {
            Console.WriteLine(fourthArray.Where(x => x.StartsWith("aa")).FirstOrDefault().ToCharArray().Skip(2).All(x => x == 'b'));
        }

        //11
        public static void ShowWordsWichStartFromAA()
        {
            Console.WriteLine(string.Join(",", fourthArray.Skip(2).Where(x => x.EndsWith("bb")).LastOrDefault()));
        }
    }
}
