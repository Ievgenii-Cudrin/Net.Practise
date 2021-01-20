using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threads1801
{
    class Program
    {
        static Random rnd = new Random();
        static int[] massForFirstTask = new int[1200000];
        static int[][] jaggedArrayForTemporary = new int[Environment.ProcessorCount][];
        static int[] minDigits = new int[Environment.ProcessorCount];
        static double[] averageDigits = new double[Environment.ProcessorCount];
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[Environment.ProcessorCount];

            //1 TASK
            var sv1 = Stopwatch.StartNew();
            int[] mass = new int[1200000];
            for (int i = 0; i <= threads.Length - 1; i++)
            {
                int k = i;
                threads[k] = new Thread(() => CreateMass(k * 100000, ((k + 1) * 100000) - 1, massForFirstTask));
            }

            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                threads[k].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                threads[k].Join();
            }

            sv1.Stop();
            Console.WriteLine(sv1.ElapsedMilliseconds);


            //2 TASK


            var sv2 = Stopwatch.StartNew();

            Thread[] threadsSecondArray = new Thread[Environment.ProcessorCount];

            Console.Write("Enter start index: ");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter start index: ");
            int finish = Convert.ToInt32(Console.ReadLine());
            //массив с количеством итерраций на поток
            int[] countOnThread = new int[Environment.ProcessorCount];
            //новый массив
            int[] timesMass = new int[finish - start];
            //Распределяем количество итерациq на каждый поток
            for (int i = 0; i< countOnThread.Length; i++)
            {
                if(i == countOnThread.Length - 1)
                {
                    countOnThread[i] = finish - countOnThread.Sum() - start;
                }
                else
                {
                    countOnThread[i] = ((finish - start) / 12) + 1;
                }
                
            }

            //переменная, которая хранит последний индекс передаваемый в предпоследий поток, для поиска количества итераций в последнем потоке
            int lastIdx = 0;

            //создаем потоки
            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                if (i == threads.Length - 1)
                {
                    threadsSecondArray[k] = new Thread(() => CreateTimesMass(k, start, lastIdx, finish, massForFirstTask));
                }
                else
                {
                    lastIdx = start + ((k * countOnThread[k]) + countOnThread[k + 1]);
                    threadsSecondArray[k] = new Thread(() => CreateTimesMass(k, start, start + (k * countOnThread[k]), start + ((k * countOnThread[k]) + countOnThread[k + 1]), massForFirstTask));
                }
            }
            //start
            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                threadsSecondArray[k].Start();
            }
            //join
            for (int i = 0; i < threads.Length - 1; i++)
            {
                int k = i;
                threadsSecondArray[k].Join();
            }

            timesMass = jaggedArrayForTemporary.SelectMany(inner => inner).ToArray();
            sv2.Stop();
            Console.WriteLine(sv2.ElapsedMilliseconds);



            //3 TASK


            var sv3 = Stopwatch.StartNew();
            //create threads whith min task
            for (int i = 0; i <= threads.Length - 1; i++)
            {
                int k = i;
                threads[k] = new Thread(() => GetMin(k, k * 100000, ((k + 1) * 100000) - 1, massForFirstTask));
            }
            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                threads[k].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                threads[k].Join();
            }
            sv3.Stop();

            Console.WriteLine(minDigits.Min());
            Console.WriteLine(sv3.ElapsedMilliseconds);



            //4 TASK


            var sv4 = Stopwatch.StartNew();
            //create threads whith average task
            for (int i = 0; i <= threads.Length - 1; i++)
            {
                int k = i;
                threads[k] = new Thread(() => GetAverage(k, k * 100000, ((k + 1) * 100000) - 1, massForFirstTask));
            }
            //start
            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                threads[k].Start();
            }
            //join
            for (int i = 0; i < threads.Length; i++)
            {
                int k = i;
                threads[k].Join();
            }
            Console.WriteLine(averageDigits.Average());
            sv4.Stop();

            Console.WriteLine(sv4.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static void CreateMass(int firstIndex, int lastIndex, int[] arr)
        {
            for(int i = firstIndex; i < lastIndex; i++)
            {
                arr[i] = rnd.Next(1, 1000);
            }
        }

        static object obj = new object();


        static void CreateTimesMass(int index, int start, int firstIndex, int lastIndex, int[] arr)
        {
            jaggedArrayForTemporary[index] = arr.Skip(firstIndex).Take(lastIndex - firstIndex).ToArray();
        }

        static void GetMin(int index, int firstIndex, int lastIndex, int[] arr)
        {
            minDigits[index] = arr.Skip(0).Take(lastIndex).Min();
        }

        static void GetAverage(int index, int firstIndex, int lastIndex, int[] arr)
        {
            averageDigits[index] = arr.Skip(0).Take(lastIndex).Average();
        }

        static void CreateNewMass()
        {
            int[] mass = Enumerable.Range(0, 1000000).Select(x => rnd.Next(1, 1000)).ToArray();
            //newIntArray = GetMass(123356, 623356, mass);
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
            //min = Enumerable.Range(0, 1000000).Select(x => rnd.Next(1, 10000)).ToList().Min();
        }

        static void GetAverage()
        {
            //average = Enumerable.Range(0, 1000000).Select(x => rnd.Next(1, 10000)).Average();
        }
    }
}
