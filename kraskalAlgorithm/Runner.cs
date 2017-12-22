using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraskalAlgorithm
{
    class Runner
    {
        static void Main(string[] args)
        {

            int[,] matrix1 = new int[,]{
                {0, 3, 0, 0, 1 },
                {3, 0, 5, 0, 4 },
                {0, 5, 0, 2, 6 },
                {0, 0, 2, 0, 7 },
                {1, 4, 6, 7, 0 },
            };

            int[,] matrix2 = new int[,]
            {
                {0, 3, 0, 0, 0, 5, 2},
                {3, 0, 5, 8, 0, 0, 0},
                {0, 5, 0, 1, 0, 0, 6},
                {0, 8, 1, 0, 4, 0, 0},
                {0, 0, 0, 4, 0, 1, 4},
                {5, 0, 0, 0, 1, 0, 2},
                {2, 0, 6, 0, 4, 2, 0}
            };

            Graph graph = new Graph(matrix1);
            Algorithm algorithm = new Algorithm(graph);
            algorithm.DoAlgorithm();

            graph = new Graph(matrix2);
            algorithm = new Algorithm(graph);
            algorithm.DoAlgorithm();

            Console.ReadKey();
        }
    }
}
