using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class BinaryHeapPriorityQueue : IPriorityQueue<BinaryNode>
    {
        private BinaryHeap BinaryHeap;

        public BinaryHeapPriorityQueue(BinaryHeap binaryHeap)
        {
            BinaryHeap = binaryHeap;
        }

        public bool TryGetValue(BinaryNode node, out int priority)
        {
            
        }

        public BinaryNode ExtractMin()
        {
            
        }
    }
}
