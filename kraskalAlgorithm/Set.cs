using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraskalAlgorithm
{
    class DSJ_Set
    {
        // p - массив, в котором указаны предки для каждого элемента
        private int[] p;

        // n - в этом случае будет равно количеству вершин графа
        public DSJ_Set(int n) 
        {
            p = new int[n]; 
        }

        public void MakeSet(int x) // id set
        {
            p[x] = x;
        }

        public int Find(int x)
        {
            if (p[x] == x) return x;
            return p[x] = Find(p[x]);
        }

        public void Unite(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (new Random().Next() % 2 == 0)
                Swap(ref x, ref y);
            p[x] = y;
        }

        public void Swap(ref int x, ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }

        public void ShowSet()
        {
            for(var i=0; i<p.Length; i++)
            {
                Console.WriteLine("vertex " + (i+1).ToString() + " -> setID = " + (p[i] + 1).ToString());
            }
        }
    }
}
