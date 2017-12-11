using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class InsertionSort
    {
        public void InsertionS(int[] arr, int left, int right)
        {
            int j, current;

            for (int i = left + 1; i < right; i++)
            {
                current = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    --j;
                    arr[j + 1] = current;
                }

            }
        }
    }
}
