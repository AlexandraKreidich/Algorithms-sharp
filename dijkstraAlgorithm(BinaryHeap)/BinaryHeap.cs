using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    // наибольший приоритет у наименьего значения (вес ребра в графе)
    internal class BinaryHeap
    {
        private List<BinaryNode> List;

        public int HeapSize => List.Count();

        public void Add(Node node, int priority)
        {
            List.Add(new BinaryNode(node, priority));
            // текущий индекс нового элемента в массиве
            int i = HeapSize - 1;
            // индекс родителя
            int parent = (i - 1) / 2;

            while (i > 0 && List[parent].Priority > List[i].Priority)
            {
                var temp = List[i];
                List[i] = List[parent];
                List[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public BinaryNode GetMin()
        {
            var result = List[0];
            List[0] = List[HeapSize - 1];
            List.RemoveAt(HeapSize - 1);
            return result;
        }

        public void Heapify(int i)
        {
            for (; ; )
            {
                var leftChild = 2 * i + 1;
                var rightChild = 2 * i + 2;
                var largestChild = i;

                if (leftChild < HeapSize && List[leftChild].Priority < List[largestChild].Priority)
                {
                    largestChild = leftChild;
                }

                if (rightChild < HeapSize && List[rightChild].Priority < List[largestChild].Priority)
                {
                    largestChild = rightChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                var temp = List[i];
                List[i] = List[largestChild];
                List[largestChild] = temp;
                i = largestChild;
            }
        }

        public void BuildHeap(BinaryNode[] sourceArray)
        {
            List = sourceArray.ToList();
            for (int i = HeapSize / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void HeapSort(BinaryNode[] array) // O(NlogN)
        {
            BuildHeap(array);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = GetMin();
                Heapify(0);
            }
        }
    }
}
