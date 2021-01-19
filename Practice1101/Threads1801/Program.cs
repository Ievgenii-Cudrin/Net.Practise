using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threads1801
{
    class Program
    {
        static Random rnd = new Random();
        static int max;
        static int[] intArray;
        static int[] newIntArray;
        static int min;
        static double average;
        static void Main(string[] args)
        {
            var sv = Stopwatch.StartNew();

            Thread[] threads = new Thread[4];

            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            threads[0] = new Thread(() => CreateMass());
            threads[1] = new Thread(() => CreateNewMass());
            threads[2] = new Thread(() => GetMin());
            threads[3] = new Thread(() => GetAverage());


            Parallel.For(0, 4, parallelOptions, (i) =>
            {
                threads[i].Start();
            });


            threads[1].Join();
            threads[2].Join();
            threads[3].Join();
            threads[0].Join();

            sv.Stop();

            Console.WriteLine(sv.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static void CreateMass()
        {
            intArray = Enumerable.Range(0, 1000000).Select(x => rnd.Next(1, 1000)).ToArray();
        }

        static void CreateNewMass()
        {
            int[] mass = Enumerable.Range(0, 1000000).Select(x => rnd.Next(1, 1000)).ToArray();
            newIntArray = GetMass(123356, 623356, mass);
        }
        static int[] GetMass(int start, int end, int[] mass)
        {
            int[] newMass = new int[end - start];
            for(int i = start; i < end; i++)
            {
                newMass[i - start] = mass[i]; 
            }
            return newMass;
        }

        static void GetMin()
        {
            min = Enumerable.Range(0, 1000000).Select(x => rnd.Next(1, 10000)).ToList().Min();
        }

        static void GetAverage()
        {
            average = Enumerable.Range(0, 1000000).Select(x => rnd.Next(1, 10000)).Average();
        }
    }
}
