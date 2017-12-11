using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace Lab_2_alg
{
    class Runner
    {
        static int size = 100000;
        static Random rnd = new Random();
        static int valueToSearch = 122;
        static int[] arr;

        static int numberOfCalls = 50;

        public static void ShowArray()
        {
            Console.WriteLine("start arr");
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("end arr");
        }

        public static void GetSortedArray()
        {
            InitArray();
            QuickS(arr, 0, size - 1);
        }

        public static void InitArray()
        {
            for (var i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(0, 40000000);
            }
        }
  
        public static void CreateArray(int[] arr)
        {
            using (FileStream fstream = new FileStream(@"numbersSorted.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(fstream, Encoding.UTF8);
                for (int i = 0; i < size; i++)
                {
                    writer.Write((arr[i]).ToString());
                    writer.WriteLine();
                }
                writer.Close();
            }
        }

        public static int[] GetArray()
        {
            List<int> numbers = new List<int>();
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();
            using (FileStream fstream = File.OpenRead(@"numbersSorted.txt"))
            {
                StreamReader reader = new StreamReader(fstream);
                for (int i = size; i > 0; i--)
                {
                    if (Int32.TryParse(reader.ReadLine(), out int num))
                    {
                        numbers.Add(num);
                    }
                }
                reader.Close();
            }
            sWatch.Stop();
            Console.WriteLine(sWatch.ElapsedMilliseconds);
            int[] values = numbers.ToArray();
            return values;
        }

        public static void QuickS(int[] arr, int left, int right)
        {
            int l = left, r = right;
            int tmp = arr[(left + right) / 2];

            while (l <= r)
            {
                while (arr[l] < tmp)
                {
                    l++;
                }

                while (arr[r] > tmp)
                {
                    r--;
                }

                if (l <= r)
                {
                    int val = arr[l];
                    arr[l] = arr[r];
                    arr[r] = tmp;

                    l++;
                    r--;
                }
            }

            if (left <= r)
            {
                QuickS(arr, left, r);
            }

            if (l <= right)
            {
                QuickS(arr, l, right);
            }
        }

        public static int CountAverageDeepthForInterpolarSearch()
        {
            int deepth = 0;
            InterpolarSearch ISearch = new InterpolarSearch();

            for (var i = 0; i < numberOfCalls; i++)
            {
                GetSortedArray();
                //ShowArray();
                //Console.WriteLine("--");
                int res = ISearch.InterpSearch(arr, 0, arr.Length - 1, valueToSearch);
                //Console.WriteLine("--");
                deepth += ISearch.DeepthOfLastCall;
            }

            return deepth / numberOfCalls;
        }

        public static int CountAverageDeepthForBinarySearch()
        {
            int deepth = 0;
            BinarySearch BSearch = new BinarySearch();

            for (var i = 0; i < numberOfCalls; i++)
            {
                GetSortedArray();
                //Console.WriteLine("--");
                int res = BSearch.BinSearch(arr, valueToSearch, 0, arr.Length - 1);
                //Console.WriteLine("--");
                deepth += BSearch.DeepthOfLastCall;
            }

            return deepth / numberOfCalls;
        }

        static void Main(string[] args)
        {
            arr = new int[size];

            Console.WriteLine("Average Deepth for Interpolar Search: ");
            Console.WriteLine(CountAverageDeepthForInterpolarSearch());
            Console.WriteLine("Average Deepth for Binary Search: ");
            Console.WriteLine(CountAverageDeepthForBinarySearch());

            Console.ReadKey();
        }
    }
}


