using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class Runner
    {
        public static void Main()
        {
            var graph = new Graph(4);
            var weights = new Dictionary<Edge, double>();

            weights[graph.Connect(0, 1)] = 1;
            weights[graph.Connect(0, 2)] = 2;
            weights[graph.Connect(0, 3)] = 6;
            weights[graph.Connect(1, 3)] = 4;
            weights[graph.Connect(2, 3)] = 2;

            var DijkstraAlg = new DijkstraAlg(graph, weights);

            var path = DijkstraAlg.Dijkstra(graph[0], graph[3]).Select(n => n.NodeNumber);

            foreach (var v in path)
                Console.WriteLine(v);

            Console.ReadKey();
        }
    }
}
