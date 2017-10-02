using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class QuickSort
    {
        public void QuickS(int[] arr, int left, int right)
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

            if (left < r)
            {
                QuickS(arr, left, r);
            }

            if (l < right)
            {
                QuickS(arr, l, right);
            }
        }

    }
}
