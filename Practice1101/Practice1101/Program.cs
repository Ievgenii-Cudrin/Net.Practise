using System;

namespace Practice1101
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            GetNumbers();
            Console.ReadLine();
        }

        static void GetNumbers()
        {
            Console.WriteLine("Enter number");
            string numbers = Console.ReadLine();

            foreach(char c in numbers.ToCharArray())
            {
                Console.WriteLine(c);
            }
        }
    }
}
