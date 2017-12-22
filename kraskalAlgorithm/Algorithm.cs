using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraskalAlgorithm
{
    class Algorithm
    {
        private int[,] Matrix;
        private int Size;
        private DSJ_Set Set;
        private List<Edge> Result;
        private List<Edge> Edges;

        public Algorithm(Graph graph)
        {
            Matrix = graph.Matrix;
            Size = graph.Size;
            Set = new DSJ_Set(Size);
            Result = new List<Edge>();
            Edges = graph.GetEdges();
            InitSet();
        }

        public void InitSet()
        {
            for(var i = 0; i<Size; i++)
            {
                Set.MakeSet(i); 
            }

            //Set.ShowSet();
        }

        public void DoAlgorithm()
        {
            for(int i = 0; i < Edges.Count; i++)
            {
                int a = Edges[i].V1;
                int b = Edges[i].V2;

                if (Set.Find(a) != Set.Find(b))
                {
                    Result.Add(Edges[i]);
                    Set.Unite(a, b);
                }
            }

            ShowResult();
        }

        public void ShowResult()
        {
            Console.WriteLine("Result: ");

            foreach (var edge in Result)
                Console.WriteLine(edge.ToString());
        }
    }
}
