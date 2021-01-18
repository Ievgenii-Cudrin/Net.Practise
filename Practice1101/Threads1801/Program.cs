using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading;

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
            Thread thread1 = new Thread(() => CreateMass());
            Thread thread2 = new Thread(() => CreateNewMass());
            Thread thread3 = new Thread(() => GetMin());
            Thread thread4 = new Thread(() => GetAverage());

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

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
