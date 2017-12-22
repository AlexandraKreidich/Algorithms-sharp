using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraskalAlgorithm
{
    class Edge : IEquatable<Edge>, IComparable<Edge>
    {
        internal int V1 { get; set; }
        internal int V2 { get; set; }
        internal int Weight { get; set; }

        public Edge(int v1, int v2, int weight)
        {
            V1 = v1;
            V2 = v2;
            Weight = weight;
        }

        public int CompareTo(Edge compareEdge)
        {
            if (compareEdge == null)
                return 1;

            else
                return Weight.CompareTo(compareEdge.Weight);
        }

        public override int GetHashCode()
        {
            return Weight;
        }

        public bool Equals(Edge other)
        {
            if (other == null) return false;
            return (Weight.Equals(other.Weight));
        }

        public override String ToString()
        {
            return "( " + (V1+1).ToString() + ", " + (V2+1).ToString() + ", " + Weight.ToString() + " )";
        }
    }
}
