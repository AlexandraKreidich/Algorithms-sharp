using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_alg
{
    class BinarySearch
    {
        public int DeepthOfLastCall = 0;

        public int BinSearch(int[] array, int val, int left, int right)
        {
            DeepthOfLastCall++;
            
            int middle = (right + left) / 2;

            if (left >= right)
                return -1;

            if (array[middle] == val)
            {
                return middle;
            } else if(val > array[middle])
            {
                return BinSearch(array, val, middle + 1, right);
            } else
            {
                return BinSearch(array, val, left, middle);
            }
        }
    }
}
