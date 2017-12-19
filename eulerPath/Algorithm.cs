using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Algorithm
    {
        public static Stack<int> stack;
        public static List<int> queue;

        // вершины для доп ребра
        private static int v1 = -1;
        private static int v2 = -1;

        public Algorithm()
        {
            stack = new Stack<int>();
            queue = new List<int>();
        }

        // проверка на существование Эйлерова цикла
        // 1 - существует
        // 0 - существует путь
        // -1 - не существует
        private static int IsEulerPathExist(List<int> DegV)
        {

            var oddVertCount = 0;
            
            for(int i = 0; i < DegV.Count; i++)
            {
                if (DegV[i] % 2 != 0)
                {
                    if (v1 == -1)
                    {
                        v1 = i;
                    }
                    else if (v2 == -1)
                    {
                        v2 = i;
                    }
                    oddVertCount++;
                }
            }
            

            if (oddVertCount == 0) return 1;
            else if (oddVertCount == 2) return 0;
            return -1;
        }

        // находит цикл и сохраняет его в поле объекта Graph
        public static void SearchEulerPath(Graph graph)
        {

            List<List<int>> GraphMatrix = graph.GraphMatrix;

            // размерность графа
            int len = GraphMatrix.Count;

            var res = IsEulerPathExist(graph.DegV);
            if (res == -1) graph.EulerPath.Add(0);
            else if (res == 0)
            {
                ++GraphMatrix[v1][v2];
                ++GraphMatrix[v2][v1];
            }

            
            int start = 0;
            stack.Push(start);
            while(stack.Count > 0)
            {
                int v = stack.Peek();
                int i;
                for (i = 0; i < len; i++)
                    if (GraphMatrix[v][i] == 1) break;
                if (i == len)
                {
                    queue.Add(v);
                    stack.Pop();
                }
                else
                {
                    --GraphMatrix[v][i];
                    --GraphMatrix[i][v];
                    stack.Push(i);
                }
            }

            // если ответом является Эйлеров путь, а не цикл
            if(v1 != -1 && v2 != -1)
            {
                for(int i = 0; i < queue.Count; i++)
                {
                    if((queue[i] == v1 && queue[i+1] == v2) || (queue[i] == v2 && queue[i + 1] == v1))
                    {
                        for (int j = i + 1; j < queue.Count; j++)
                            graph.EulerPath.Add(++queue[j]);
                        for (int j = 1; j <= i; j++)
                            graph.EulerPath.Add(++queue[j]);
                        break;
                    }
                }
            }
            else
            {
                for(int i = queue.Count - 1; i >= 0; i--)
                    graph.EulerPath.Add(++queue[i]);
            }

            // проверка на несвязность графа
            for(int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                    if (GraphMatrix[i][j] == 1) graph.EulerPath = new List<int>() { -1 };
            }

        }

    }
}
