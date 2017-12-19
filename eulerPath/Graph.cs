using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Graph
    {
        // эйлеров цикл (ответ)
        // 0 - не существует
        // -1 - не связный граф
        public List<int> EulerPath;

        // степени вершин графа
        public List<int> DegV;

        // матрица смежности графа
        public List<List<int>> GraphMatrix;

        public Graph()
        {
            this.GraphMatrix = new List<List<int>>()
            {
                new List<int>(){ 0, 0, 0, 0, 0, 0, 0 },
                new List<int>(){ 1, 0, 1, 1, 1, 0, 0 },
                new List<int>(){ 0, 1, 0, 0, 1, 0, 0 },
                new List<int>(){ 1, 1, 0, 0, 1, 1, 0 },
                new List<int>(){ 0, 1, 1, 1, 0, 0, 1 },
                new List<int>(){ 0, 0, 0, 1, 0, 0, 1 },
                new List<int>(){ 0, 0, 0, 0, 1, 1, 0 }
            };

            this.EulerPath = new List<int>();

            this.DegV = new List<int>();

            this.CountDegV();
        }

        // считает степени вершин графа
        private void CountDegV()
        {
            int len = GraphMatrix.Count;

            for(int i = 0; i < len; i++)
            {
                DegV.Add(0);

                for (int j = 0; j < len; j++)
                {
                    DegV[i] += GraphMatrix[i][j];
                }
            }
        }

        public static void ShowEulerPath(List<int> path)
        {
            if (path.Count > 1)
            {
                Console.Write("Path");

                foreach (var e in path)
                {
                    Console.Write(" -> " + e.ToString());
                }
            }
            else
            {
                if (path[0] == 0)
                    Console.WriteLine("Пути не существует");
                else
                    Console.WriteLine("Граф не связен");
            }
        }

        public static void ShowGraphMatrix(List<List<int>> g)
        {
            for (int i = 0; i < g.Count; i++)
            {
                foreach (var e in g[i])
                    Console.Write(e.ToString() + " ");
                Console.WriteLine();
            }
        }
    }
}
