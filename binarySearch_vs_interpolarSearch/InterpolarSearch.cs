using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_alg
{
    class InterpolarSearch
    {
        public int DeepthOfLastCall = 0;

        public int InterpSearch(int[] array, int left, int right, int val)
        {
            int x = left + ((val - array[left]) * (right - left) / (array[right] - array[left]));
            //Console.WriteLine(x);

            this.DeepthOfLastCall += 1;
         
            if ((array[left] <= val) && (array[right] >= val))
            {
                if (array[x] < val)
                {
                    return InterpSearch(array, x + 1, right, val);
                }
                else if (array[x] > val)
                {
                    return InterpSearch(array, left, x - 1, val);
                }
                else if (array[left] == val)
                {
                    return left;
                }
                else if (array[right] == val)
                {
                    return right;
                }
                else return x;
            }
            else
            {
                return -1;
            }
        }
    }
}
