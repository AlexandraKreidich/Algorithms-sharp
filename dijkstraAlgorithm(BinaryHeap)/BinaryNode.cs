using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class BinaryNode
    {
        public Node Node { get; set; }
        public int Priority { get; set; }

        public BinaryNode(Node node, int priority)
        {
            Node = node;
            Priority = priority;
        }

    }
}
