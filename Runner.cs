using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Runner
    {
        private int SizeOfArray;

        public Runner(int sizeOfArray)
        {
            this.SizeOfArray = sizeOfArray;

            //this.CreateFileWithNumbers();

            InsertionSort IS = new InsertionSort();
            QuickSort QS = new QuickSort();
            HibridSort HS = new HibridSort();
            MergeSort MS = new MergeSort();

            int[] array = this.GetArray();

            DateTime start = DateTime.Now;
            QS.QuickS(array, 0, array.Length - 1);
            DateTime end = DateTime.Now;
            Console.Write("QS time: ");
            Console.WriteLine((end - start).Milliseconds);

            array = this.GetArray();
            start = DateTime.Now;
            IS.InsertionS(array, 0, array.Length);
            end = DateTime.Now;
            Console.Write("IS time: ");
            Console.WriteLine((end - start).Milliseconds);

            array = this.GetArray();
            start = DateTime.Now;
            HS.HibridS(array, 0, array.Length);
            end = DateTime.Now;
            Console.Write("HS time: ");
            Console.WriteLine((end - start).Milliseconds);

            array = this.GetArray();
            start = DateTime.Now;
            MS.MergeS(array, 0, array.Length - 1);
            end = DateTime.Now;
            Console.Write("MS time: ");
            Console.WriteLine((end - start).Milliseconds);

            /*for(int i=0; i<array.Length; i++)
            {
                Console.Write(array[i]);
                Console.WriteLine();
            }*/
        }

        public int[] GetArray()
        {
            List<int> numbers = new List<int>();
            FileStream file = new FileStream("numbers.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                for (int i = this.SizeOfArray; i > 0; i--)
                {
                    if (Int32.TryParse(reader.ReadLine(), out int num))
                    {
                        numbers.Add(num);
                    }
                }
                reader.Close();
            }
            int[] values = numbers.ToArray();
            return values;
        }

        public void CreateFileWithNumbers()
        {
            Random getrandom = new Random();
            using (FileStream numbers = new FileStream("numbers.txt", FileMode.Create, FileAccess.Write))
            {
                StreamWriter writer = new StreamWriter(numbers, Encoding.UTF8);
                for (int i = 0; i < 1000; i++)
                {
                    int num = getrandom.Next(1, 1000);
                    writer.Write((num).ToString());
                    writer.WriteLine();
                }
                writer.Close();
            }
        }

        public static void Main(String[] args)
        {
            int size = 0;
            if (args.Length == 0)
            {
                size = 50;
            }
            else
            {
                size = int.Parse(args[0]);
            }
            new Runner(size);
        }
    }
}
