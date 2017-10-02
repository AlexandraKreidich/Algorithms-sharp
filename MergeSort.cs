using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MergeSort
    {
        public void MergeS(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (right + left) / 2;
                this.MergeS(arr, left, mid);
                this.MergeS(arr, mid + 1, right);
                this.Merge(arr, left, mid, right);
            }
        }

        private void Merge(int[] arr, int left, int mid, int right)
        {
            int[] arrLeft = new int[mid - left + 1];
            int[] arrRight = new int[right - mid];
            int r = 0;
            int l = 0;

            for (int i = left; i <= mid; i++)
            {
                arrLeft[l++] = arr[i];
            }

            for (int j = mid + 1; j <= right; j++)
            {
                arrRight[r++] = arr[j];
            }

            l = 0; r = 0;
            int k = left;
            while (l < arrLeft.Length && r < arrRight.Length)
            {

                if (arrLeft[l] <= arrRight[r])
                {
                    arr[k++] = arrLeft[l++];
                }
                else
                    arr[k++] = arrRight[r++];
            }
            if (l >= arrLeft.Length)
            {
                while (k <= right)
                    arr[k++] = arrRight[r++];
            }
            if (r >= arrRight.Length)
            {
                while (k <= right)
                    arr[k++] = arrLeft[l++];
            }
        }
    }
}
