using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace ConsoleApp1
{
    class HibridSort
    {
        public int value = 80;

        public void HibridS(int[] arr, int left, int right)
        {
            if (right - left < value)
            {
                this.InsertionS(arr, left, right);
            }
            else
            {
                if (left < right)
                {
                    this.QuickS(arr, left, right - 1);
                }
            }
        }

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
