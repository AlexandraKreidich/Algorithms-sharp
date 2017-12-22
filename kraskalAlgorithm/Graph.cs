using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraskalAlgorithm
{
    class Graph
    {
        internal int Size;
        internal int[,] Matrix { get; set; }
        internal List<Edge> Edges = new List<Edge>();

        public Graph(int[,] matrix)
        {
            Matrix = matrix;
            Size = Matrix.GetLength(1);
            SetEdges();
            Edges.Sort();
        }

        private void SetEdges()
        {
            //Console.WriteLine(size);

            for (int i = 1; i < Size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Matrix[i, j] != 0)
                    {
                        Edges.Add(new Edge(j, i, Matrix[i, j]));
                    }
                }
            }
        }

        public List<Edge> GetEdges()
        {
            //foreach (var edge in Edges)
            //    Console.WriteLine(edge.ToString());

            return Edges;
        }
    }
}
