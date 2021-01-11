using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Practice1101
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            GetNumbers();

            //2
            GetPartOfNumber();

            //3
            GetMaximalNumber();

            //4
            GetMinimalNumber();

            //5
            WriteDigitFromString();

            //6
            GetDateInFormatIso();

            //7
            ParseStringToDateTime();

            //8
            GetFirstLetterToUp();

            //9
            GetString();

            //10
            BubleSort();

            //12
            AddMassToZip();

            //13
            QuickSortMassive();

            Console.ReadLine();
        }

        //1
        static void GetNumbers()
        {
            Console.WriteLine("Enter number");
            string numbers = Console.ReadLine();

            foreach(char c in numbers.ToCharArray())
            {
                Console.WriteLine(c);
            }
        }

        //2
        static void GetPartOfNumber()
        {
            decimal decimalNumber;

            decimalNumber = 32.7865m;
            Console.WriteLine(Math.Truncate(decimalNumber));

            decimal decimalNumber2 = decimalNumber - Math.Truncate(decimalNumber);
            Console.WriteLine(decimalNumber2);
        }

        //3
        static void GetMaximalNumber()
        {
            int number = 87651926;
            char[] numberInString = number.ToString().ToCharArray();

            int max = int.Parse(numberInString[0].ToString());
            for (int i = 1; i < numberInString.Length; i++)
            {
                if(max < int.Parse(numberInString[i].ToString()))
                {
                    max = int.Parse(numberInString[i].ToString());
                }
            }

            Console.WriteLine(max);
        }

        //4
        static void GetMinimalNumber()
        {
            int number = 87651926;
            char[] numberInString = number.ToString().ToCharArray();

            int max = int.Parse(numberInString[0].ToString());
            for (int i = 1; i < numberInString.Length; i++)
            {
                if (max > int.Parse(numberInString[i].ToString()))
                {
                    max = int.Parse(numberInString[i].ToString());
                }
            }

            Console.WriteLine(max);
        }

        //5
        static void WriteDigitFromString()
        {
            Console.WriteLine("Enter string: ");
            string stringFromUser = Console.ReadLine();

            char[] charsFromUserString = stringFromUser.ToCharArray();

            for(int i = 0; i < charsFromUserString.Length; i++)
            {
                if (Char.IsDigit(charsFromUserString[i]))
                {
                    Console.WriteLine(charsFromUserString[i]);
                }
            }
        }

        //6
        static void GetDateInFormatIso()
        {
            string dateInIsoFormat = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            Console.WriteLine(dateInIsoFormat);
        }


        //7
        static void ParseStringToDateTime()
        {
            string stringWithDate = "2016 21 - 07";
            char[] charsFromString = stringWithDate.ToCharArray();
            string[] dates = new string[3];
            int pos = 0;
            string currentValue = "";

            for(int i = 0; i < charsFromString.Length; i++)
            {
                if(charsFromString[i] != Char.Parse(" ") && charsFromString[i] != Char.Parse("-"))
                {
                    currentValue = currentValue + charsFromString[i];
                    if(i == charsFromString.Length-1)
                    {
                        dates[pos] = currentValue;
                        currentValue = "";
                    }
                }
                else
                {
                    if(currentValue != "")
                    {
                        dates[pos] = currentValue;
                        currentValue = "";
                        pos++;
                    }
                }
            }

            DateTime date = new DateTime(Convert.ToInt32(dates[0]), Convert.ToInt32(dates[2]), Convert.ToInt32(dates[1]));
        }

        //8
        static void GetFirstLetterToUp()
        {
            string[] names = { "иван иванов", "светлана иванова - петренко" };
            string[] newNames = new string[names.Length];

            for(int i = 0; i < names.Length; i++)
            {
                char[] charsFromName = names[i].ToCharArray();
                char[] newNameChars = new char[charsFromName.Length];
                bool flag = false;
                for (int j = 0; j < charsFromName.Length; j++)
                {
                    if(j == 0 || flag)
                    {
                        newNameChars[j] = Char.ToUpper(charsFromName[j]);
                        flag = false;
                    }
                    else if (Char.IsLetter(charsFromName[j]))
                    {
                        newNameChars[j] = charsFromName[j];
                    }
                    else if(charsFromName[j] == Char.Parse(" ") || charsFromName[j] == Char.Parse("-"))
                    {
                        newNameChars[j] = charsFromName[j];
                        if(Char.IsLetter(charsFromName[j + 1]))
                        {
                            flag = true;
                        }
                    }
                    
                }
                newNames[i] = new string(newNameChars);
            }
        }

        //9
        static void GetString()
        {
            string encoded = "0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C / 0L7Qu9C90LXQvdC + INCy0LXRgNC90L4gOik =";

            var enTextBytes = Convert.FromBase64String(encoded);
            string deText = Encoding.UTF8.GetString(enTextBytes);
        }

        //10
        static void BubleSort()
        {
            int[] array = new int[39];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 100);
            }

            int currentVariable;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        currentVariable = array[i];
                        array[i] = array[j];
                        array[j] = currentVariable;
                    }
                }
            }

        }

        //12
        static void AddMassToZip()
        {

            int[] array = new int[39];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 100);
            }
            string path = "array.txt";
            string pathToZip = "arrayInZip.zip";
            string fileAfterZip = "fileAfterDecompress.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        sw.WriteLine(array[i]);
                    }
                }
            }

            //compress
            using (FileStream sourceStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(pathToZip))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            path, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }

            using (FileStream sourceStream = new FileStream(pathToZip, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(fileAfterZip))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", "fileAfterDecompress");
                    }
                }
            }

            using (StreamReader sr = File.OpenText("fileAfterDecompress"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        //13 it isnt my code, find in internet
        #region
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        static int[] QuickSortMass(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        #endregion

        static void QuickSortMassive()
        {
            int[] array = new int[39];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 100);
            }

            int[] sortMass = QuickSortMass(array);
        }
    }
}
